namespace LibraryManager.Controls.ControlBarControls
{
	public static class SearchControls
	{
		public static Label CreateLabelSearchIsbn()
		{
			var lblIsbn = new Label();
			
			lblIsbn.Location = new System.Drawing.Point(12, 9);
			lblIsbn.Name = "lblISBN";
			lblIsbn.Size = new System.Drawing.Size(56, 23);
			lblIsbn.Text = "ISBN:";
			lblIsbn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return lblIsbn;
		}
		
		public static TextBox CreateTextBoxSearchIsbn()
		{
			var tbIsbn = new TextBox();
			
			tbIsbn.Location = new System.Drawing.Point(74, 6);
			tbIsbn.Name = "tbSearchISBN";
			tbIsbn.Size = new System.Drawing.Size(149, 26);
			tbIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return tbIsbn;
		}

		public static Button CreateSearchIsbnButton()
		{
			var btnSearchIsbn = new Button();
			
			btnSearchIsbn.Location = new System.Drawing.Point(602, 3);
			btnSearchIsbn.Name = "btnSearchISBN";
			btnSearchIsbn.Size = new System.Drawing.Size(144, 33);
			btnSearchIsbn.Text = "Search ISBN";
			btnSearchIsbn.UseVisualStyleBackColor = true;
			btnSearchIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return btnSearchIsbn;
		}

		public static Label CreateLabelSearchTitle()
		{
			var lblSearchTitle = new Label();
			
			lblSearchTitle.Location = new System.Drawing.Point(12, 41);
			lblSearchTitle.Name = "lblSearchTitle";
			lblSearchTitle.Size = new System.Drawing.Size(56, 23);
			lblSearchTitle.Text = "Title:";
			lblSearchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblSearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return lblSearchTitle;
		}

		public static TextBox CreateTextBoxSearchTitle()
		{
			var tbSearchTitle = new TextBox();
			
			tbSearchTitle.Location = new System.Drawing.Point(74, 40);
			tbSearchTitle.Name = "tbSearchTitle";
			tbSearchTitle.Size = new System.Drawing.Size(149, 26);
			tbSearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return tbSearchTitle;
		}
		
		public static Button CreateSearchTitleButton()
		{
			var btnSearchTitle = new Button();
			
			btnSearchTitle.Location = new System.Drawing.Point(602, 38);
			btnSearchTitle.Name = "btnSearchTitle";
			btnSearchTitle.Size = new System.Drawing.Size(144, 33);
			btnSearchTitle.Text = "Search Title";
			btnSearchTitle.UseVisualStyleBackColor = true;
			btnSearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return btnSearchTitle;
		}

		public static Label CreateSearchAuthorLabel()
		{
			var lblAuthor = new Label();
			
			lblAuthor.Location = new System.Drawing.Point(231, 10);
			lblAuthor.Name = "lblAuthor";
			lblAuthor.Size = new System.Drawing.Size(73, 23);
			lblAuthor.Text = "Author:";
			lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return lblAuthor;
		}
		
		public static TextBox CreateSearchAuthorTextBox()
		{
			var tbAuthor = new TextBox();
			
			tbAuthor.Location = new System.Drawing.Point(310, 7);
			tbAuthor.Name = "tbAuthor";
			tbAuthor.Size = new System.Drawing.Size(149, 26);
			tbAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return tbAuthor;
		}
		
		public static Button CreateSearchAuthorButton()
		{
			var btnSearchAuthor = new Button();
			
			btnSearchAuthor.Location = new System.Drawing.Point(752, 3);
			btnSearchAuthor.Name = "btnSearchAuthor";
			btnSearchAuthor.Size = new System.Drawing.Size(144, 33);
			btnSearchAuthor.Text = "Search Author";
			btnSearchAuthor.UseVisualStyleBackColor = true;
			btnSearchAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return btnSearchAuthor;
		}
		
		public static Label CreateSearchPublisherLabel()
		{
			var lblPublisher = new Label();
			
			lblPublisher.Location = new System.Drawing.Point(231, 41);
			lblPublisher.Name = "lblPublisher";
			lblPublisher.Size = new System.Drawing.Size(81, 23);
			lblPublisher.Text = "Publisher:";
			lblPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return lblPublisher;
		}
		
		public static TextBox CreateSearchPublisherTextBox()
		{
			var tbPublisher = new TextBox();
			
			tbPublisher.Location = new System.Drawing.Point(310, 38);
			tbPublisher.Name = "tbPublisher";
			tbPublisher.Size = new System.Drawing.Size(149, 26);
			tbPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return tbPublisher;
		}
		
		public static Button CreateSearchPublisherButton()
		{
			var btnSearchPublisher = new Button();
			
			btnSearchPublisher.Location = new System.Drawing.Point(752, 38);
			btnSearchPublisher.Name = "btnSearchPublisher";
			btnSearchPublisher.Size = new System.Drawing.Size(144, 33);
			btnSearchPublisher.Text = "Search Publisher";
			btnSearchPublisher.UseVisualStyleBackColor = true;
			btnSearchPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return btnSearchPublisher;
		}
		
		public static CheckBox CreateSearchIsLoanedCheckBox()
		{
			var cbIsLoaned = new CheckBox();
			
			cbIsLoaned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			cbIsLoaned.Location = new System.Drawing.Point(484, 42);
			cbIsLoaned.Name = "cbIsLoaned";
			cbIsLoaned.RightToLeft = RightToLeft.No;
			cbIsLoaned.Size = new System.Drawing.Size(89, 24);
			cbIsLoaned.Text = "Loaned:";
			cbIsLoaned.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			cbIsLoaned.UseVisualStyleBackColor = true;
			cbIsLoaned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return cbIsLoaned;
		}

		public static CheckBox CreateSearchIsOwnedCheckBox()
		{
			var cbIsOwned = new CheckBox();
			
			cbIsOwned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			cbIsOwned.Location = new System.Drawing.Point(484, 10);
			cbIsOwned.Name = "cbIsOwned";
			cbIsOwned.RightToLeft = RightToLeft.No;
			cbIsOwned.Size = new System.Drawing.Size(89, 24);
			cbIsOwned.Text = "Owned:";
			cbIsOwned.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			cbIsOwned.UseVisualStyleBackColor = true;
			cbIsOwned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));

			return cbIsOwned;
		}
	}
}