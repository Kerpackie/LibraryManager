using System.Windows.Forms;
using LibraryManager.FrameworkUI.Controls;
using LibraryManager.FrameworkUI.Controls.BookFormControls;
using LibraryManager.FrameworkUI.Views.BookForms.BaseBookForms;

namespace LibraryManager.FrameworkUI.Views.BookForms.ViewBookForms
{
	public partial class ViewBookForm : BaseBookForm
	{
		public ViewBookForm()
		{
			InitializeComponent();

			var controls = SubjectControls.CreateBookSubjectControlsEditMode();
			panelBody.Controls.AddRange(controls);
			
			var collectionControls = CollectionControls.CreateBookCollectionControlsEditMode();
			panelBody.Controls.AddRange(collectionControls);
			
			panelBody.Enabled = false;
		}
	}
}