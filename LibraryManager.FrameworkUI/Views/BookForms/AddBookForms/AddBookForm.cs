using System.Windows.Forms;
using LibraryManager.FrameworkUI.Controls;
using LibraryManager.FrameworkUI.Controls.BookFormControls;
using LibraryManager.FrameworkUI.Views.BookForms.BaseBookForms;

namespace LibraryManager.FrameworkUI.Views.BookForms.AddBookForms
{
	public partial class AddBookForm : BaseBookForm
	{
		public AddBookForm()
		{
			InitializeComponent();

			var subjectList = SubjectControls.CreateListBoxBookSubjectsViewMode();
			panelBody.Controls.Add(subjectList);
			
			var collectionList = CollectionControls.CreateListBoxBookCollectionsViewMode();
			panelBody.Controls.Add(collectionList);

			panelBody.Enabled = false;
			
		}

		private static ListBox CreateListBoxSubjects()
		{
			var listBoxSubjects = new ListBox
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				ItemHeight = 20,
				Location = new System.Drawing.Point(58, 190),
				Name = "listBoxSubjects",
				Size = new System.Drawing.Size(366, 124)
			};

			return listBoxSubjects;
		}

		private static ListBox CreateListBoxCollections()
		{
			var listBoxCollections = new ListBox
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				ItemHeight = 20,
				Location = new System.Drawing.Point(463, 190),
				Name = "listBoxCollections",
				Size = new System.Drawing.Size(366, 124)
			};

			return listBoxCollections;
		}
		
		
		
	}
}