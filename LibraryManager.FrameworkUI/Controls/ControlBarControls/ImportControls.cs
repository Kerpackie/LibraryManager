using System.Windows.Forms;

namespace LibraryManager.FrameworkUI.Controls.ControlBarControls
{
	public static class ImportControls
	{
		public static Button ImportButton()
		{
			var btnImportBook = new Button();
			
			btnImportBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			btnImportBook.Location = new System.Drawing.Point(769, 12);
			btnImportBook.Name = "btnImportBook";
			btnImportBook.Size = new System.Drawing.Size(114, 59);
			btnImportBook.TabIndex = 37;
			btnImportBook.Text = "Import Book";
			btnImportBook.UseVisualStyleBackColor = true;

			return btnImportBook;
		}

		public static TextBox IsbnSearchTextBox()
		{
			var tbIsbnSearch = new TextBox();
			
			tbIsbnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			tbIsbnSearch.Location = new System.Drawing.Point(74, 12);
			tbIsbnSearch.Name = "tbISBNSearch";
			tbIsbnSearch.Size = new System.Drawing.Size(260, 26);
			tbIsbnSearch.TabIndex = 6;

			return tbIsbnSearch;
		}

		public static Label IsbnSearchLabel()
		{
			var lblIsbnSearch = new Label();
			
			lblIsbnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			lblIsbnSearch.Location = new System.Drawing.Point(20, 15);
			lblIsbnSearch.Name = "lblISBNSearch";
			lblIsbnSearch.Size = new System.Drawing.Size(54, 23);
			lblIsbnSearch.TabIndex = 5;
			lblIsbnSearch.Text = "ISBN:";

			return lblIsbnSearch;
		}
		
		public static CheckBox BookOwnedOnImportCheckBox()
		{
			var importCheckBox = new CheckBox();
			
			importCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			importCheckBox.Checked = true;
			importCheckBox.CheckState = CheckState.Checked;
			importCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			importCheckBox.Location = new System.Drawing.Point(12, 41);
			importCheckBox.Name = "checkBoxSearchOwned";
			importCheckBox.Size = new System.Drawing.Size(85, 36);
			importCheckBox.TabIndex = 14;
			importCheckBox.Text = "Owned:";
			importCheckBox.UseVisualStyleBackColor = true;

			return importCheckBox;
		}
	}
}