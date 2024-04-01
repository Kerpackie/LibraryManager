using System.Windows.Forms;

namespace LibraryManager.FrameworkUI.Services.FormService
{
	/// <summary>
	/// Provides an interface for managing forms.
	/// </summary>
	public interface IFormService
	{
		/// <summary>
		/// Occurs when a form is opened.
		/// </summary>
		event FormOpenedHandler FormOpened;

		/// <summary>
		/// Occurs when a form is closed.
		/// </summary>
		event FormClosedHandler FormClosed;

		/// <summary>
		/// Opens a form of the specified type.
		/// </summary>
		/// <typeparam name="T">The type of the form to open.</typeparam>
		void OpenForm<T>() where T : Form;

		/// <summary>
		/// Opens a form of the specified type with the specified argument.
		/// </summary>
		/// <typeparam name="T">The type of the form to open.</typeparam>
		/// <typeparam name="TArg">The type of the argument.</typeparam>
		/// <param name="arg">The argument to pass to the form.</param>
		void OpenFormWithArgument<T, TArg>(TArg arg) where T : Form;
		
		void OpenChildForm<T>(Panel panel) where T : Form;

		void OpenChildFormWithArgument<T, TArg>(Panel panel, TArg arg) where T : Form;
		
		void OpenChildFormWithParentPanelAndArguments<T>(Panel panel, params object[] args) where T : Form;
	}
}