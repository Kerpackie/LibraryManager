using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Services.FormService
{
    public class FormService : IFormService
    {

        private readonly IServiceProvider _serviceProvider;

        public FormService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public event FormOpenedHandler? FormOpened;
        public event FormClosedHandler? FormClosed;

        public void OpenForm<T>() where T : Form
        {
            var form = _serviceProvider.GetRequiredService<T>();
            form.Show();
        }

        public void OpenFormWithArgument<T, TArg>(TArg arg) where T : Form
        {
            var form = ActivatorUtilities.CreateInstance<T>(_serviceProvider, arg);
            form.Show();
            FormOpened?.Invoke(this, EventArgs.Empty, form);
        }

    }
}
