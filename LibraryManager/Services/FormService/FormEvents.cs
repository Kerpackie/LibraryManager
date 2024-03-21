namespace LibraryManager.Services.FormService
{
	/// <summary>
	/// Contains delegate handlers for form events.
	/// </summary>
	public delegate void FormOpenedHandler(object sender, EventArgs e, Form openedForm);

	/// <summary>
	/// Delegate for handling the event when a form is closed.
	/// </summary>
	public delegate void FormClosedHandler(object sender, EventArgs e, Form closedFormName);
}