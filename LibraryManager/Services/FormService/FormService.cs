using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Services.FormService
{
    /// <summary>
    /// Provides services for managing forms.
    /// </summary>
    public class FormService : IFormService
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider to resolve services.</param>
        public FormService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Occurs when a form is opened.
        /// </summary>
        public event FormOpenedHandler FormOpened;

        /// <summary>
        /// Occurs when a form is closed.
        /// </summary>
        public event FormClosedHandler FormClosed;

        /// <summary>
        /// Opens a form of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the form to open.</typeparam>
        public void OpenForm<T>() where T : Form
        {
            var form = _serviceProvider.GetRequiredService<T>();
            form.Show();
        }

        /// <summary>
        /// Opens a form of the specified type with the specified argument.
        /// </summary>
        /// <typeparam name="T">The type of the form to open.</typeparam>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="arg">The argument to pass to the form.</param>
        public void OpenFormWithArgument<T, TArg>(TArg arg) where T : Form
        {
            var form = ActivatorUtilities.CreateInstance<T>(_serviceProvider, arg);
            form.Show();
            FormOpened?.Invoke(this, EventArgs.Empty, form);
        }

        public void OpenChildForm<T>(Panel panel) where T : Form
        {
            var form = _serviceProvider.GetRequiredService<T>();
            form.TopLevel = false;

            // Set Form Properties
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel.Controls.Add(form);
            form.Show();
            FormOpened?.Invoke(this, EventArgs.Empty, form);
        }

        public void OpenChildFormWithArgument<T, TArg>(Panel panel, TArg arg) where T : Form
        {
            var form = ActivatorUtilities.CreateInstance<T>(_serviceProvider, arg);
            form.TopLevel = false;

            // Set Form Properties
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel.Controls.Add(form);
            form.Show();
            FormOpened?.Invoke(this, EventArgs.Empty, form);
        }

        public void OpenChildFormWithParentPanelAndArguments<T>(Panel panel, params object[] args) where T : Form
        {
            var formService = _serviceProvider.GetRequiredService<IFormService>();
            var form = (Form)Activator.CreateInstance(typeof(T), panel, formService, args);
            form.TopLevel = false;

            // Set Form Properties
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel.Controls.Add(form);
            form.Show();
            FormOpened?.Invoke(this, EventArgs.Empty, form);
        }
    }
}