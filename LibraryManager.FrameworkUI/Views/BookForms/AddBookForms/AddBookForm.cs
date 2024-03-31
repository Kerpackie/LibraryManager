using System.Windows.Forms;
using System.Xml.Serialization;
using LibraryManager.FrameworkUI.Controls;
using LibraryManager.FrameworkUI.Controls.BookFormControls;
using LibraryManager.FrameworkUI.Controls.ControlBarControls;
using LibraryManager.FrameworkUI.Views.BookForms.BaseBookForms;

namespace LibraryManager.FrameworkUI.Views.BookForms.AddBookForms
{
	public partial class AddBookForm : BaseBookForm
	{
		public AddBookForm(object args)
		{
			if (args is string arg)
			{
				switch(arg)
				{
					case "Import":
						AddImportControlControls();
						AddImportBodyControls();
						panelBody.Enabled = false;
						break;
					case "Manual":
						AddManualBodyControls();
						panelBody.Enabled = true;
						break;
				}
			}
			
			InitializeComponent();
		}

		private void AddManualBodyControls()
		{
			var subjectControls = SubjectControls.CreateBookSubjectControlsEditMode();
			panelBody.Controls.AddRange(subjectControls);
			
			var collectionControls = CollectionControls.CreateBookCollectionControlsEditMode();
			panelBody.Controls.AddRange(collectionControls);
		}

		private void AddImportBodyControls()
		{
			var subjectControls = SubjectControls.CreateListBoxBookSubjectsViewMode();
			panelBody.Controls.Add(subjectControls);
			
			var collectionControls = CollectionControls.CreateListBoxBookCollectionsViewMode();
			panelBody.Controls.Add(collectionControls);
		}
		
		private void AddImportControlControls()
		{
			var isbnLabel = ImportControls.IsbnSearchLabel();
			panelControl.Controls.Add(isbnLabel);
			
			var isbnTextBox = ImportControls.IsbnSearchTextBox();
			panelControl.Controls.Add(isbnTextBox);

			var importButton = ImportControls.ImportButton();
			panelControl.Controls.Add(importButton);

			var isOwnedCheckBox = ImportControls.BookOwnedOnImportCheckBox();
			panelControl.Controls.Add(isOwnedCheckBox);
		}
		
	}
}