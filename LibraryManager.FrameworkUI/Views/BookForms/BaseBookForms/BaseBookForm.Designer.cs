using System.ComponentModel;

namespace LibraryManager.FrameworkUI.Views.BookForms.BaseBookForms
{
	partial class BaseBookForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		
		protected System.Windows.Forms.Panel panelControl;
		protected System.Windows.Forms.Panel panelBody;


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelControl = new System.Windows.Forms.Panel();
			this.panelBody = new System.Windows.Forms.Panel();
			this.btnRemoveNote = new System.Windows.Forms.Button();
			this.btnSaveNote = new System.Windows.Forms.Button();
			this.btnUpdateBook = new System.Windows.Forms.Button();
			this.comboBoxAuthor = new System.Windows.Forms.ComboBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lblNotesTitle = new System.Windows.Forms.Label();
			this.listBoxNotes = new System.Windows.Forms.ListBox();
			this.lblNotes = new System.Windows.Forms.Label();
			this.lblCollections = new System.Windows.Forms.Label();
			this.lblSubjects = new System.Windows.Forms.Label();
			this.cbOnLoan = new System.Windows.Forms.CheckBox();
			this.cbOwned = new System.Windows.Forms.CheckBox();
			this.tbPagesRead = new System.Windows.Forms.TextBox();
			this.lblPagesRead = new System.Windows.Forms.Label();
			this.tbPageCount = new System.Windows.Forms.TextBox();
			this.lblPageCount = new System.Windows.Forms.Label();
			this.tbPublisher = new System.Windows.Forms.TextBox();
			this.lblPublisher = new System.Windows.Forms.Label();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.tbTitle = new System.Windows.Forms.TextBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.tbISBN = new System.Windows.Forms.TextBox();
			this.lblISBN = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.listBoxAllSubjects = new System.Windows.Forms.ListBox();
			this.listBoxBookSubjects = new System.Windows.Forms.ListBox();
			this.listBoxAllCollections = new System.Windows.Forms.ListBox();
			this.listBoxBookCollections = new System.Windows.Forms.ListBox();
			this.btnRemoveSubjectFromBook = new System.Windows.Forms.Button();
			this.btnAddSubjectToBook = new System.Windows.Forms.Button();
			this.btnRemoveCollectionFromBook = new System.Windows.Forms.Button();
			this.btnAddCollectionToBook = new System.Windows.Forms.Button();
			this.panelBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl
			// 
			this.panelControl.BackColor = System.Drawing.SystemColors.HotTrack;
			this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl.Location = new System.Drawing.Point(0, 0);
			this.panelControl.Name = "panelControl";
			this.panelControl.Size = new System.Drawing.Size(895, 77);
			this.panelControl.TabIndex = 0;
			// 
			// panelBody
			// 
			this.panelBody.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panelBody.Controls.Add(this.btnRemoveNote);
			this.panelBody.Controls.Add(this.btnSaveNote);
			this.panelBody.Controls.Add(this.btnUpdateBook);
			this.panelBody.Controls.Add(this.comboBoxAuthor);
			this.panelBody.Controls.Add(this.richTextBox1);
			this.panelBody.Controls.Add(this.textBox1);
			this.panelBody.Controls.Add(this.lblNotesTitle);
			this.panelBody.Controls.Add(this.listBoxNotes);
			this.panelBody.Controls.Add(this.lblNotes);
			this.panelBody.Controls.Add(this.lblCollections);
			this.panelBody.Controls.Add(this.lblSubjects);
			this.panelBody.Controls.Add(this.cbOnLoan);
			this.panelBody.Controls.Add(this.cbOwned);
			this.panelBody.Controls.Add(this.tbPagesRead);
			this.panelBody.Controls.Add(this.lblPagesRead);
			this.panelBody.Controls.Add(this.tbPageCount);
			this.panelBody.Controls.Add(this.lblPageCount);
			this.panelBody.Controls.Add(this.tbPublisher);
			this.panelBody.Controls.Add(this.lblPublisher);
			this.panelBody.Controls.Add(this.lblAuthor);
			this.panelBody.Controls.Add(this.tbTitle);
			this.panelBody.Controls.Add(this.lblTitle);
			this.panelBody.Controls.Add(this.tbISBN);
			this.panelBody.Controls.Add(this.lblISBN);
			this.panelBody.Controls.Add(this.pictureBox1);/*
			this.panelBody.Controls.Add(this.listBoxAllSubjects);
			this.panelBody.Controls.Add(this.listBoxBookSubjects);
			this.panelBody.Controls.Add(this.listBoxAllCollections);
			this.panelBody.Controls.Add(this.listBoxBookCollections);
			this.panelBody.Controls.Add(this.btnRemoveSubjectFromBook);
			this.panelBody.Controls.Add(this.btnAddSubjectToBook);
			this.panelBody.Controls.Add(this.btnRemoveCollectionFromBook);
			this.panelBody.Controls.Add(this.btnAddCollectionToBook);*/
			this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBody.Location = new System.Drawing.Point(0, 77);
			this.panelBody.Name = "panelBody";
			this.panelBody.Size = new System.Drawing.Size(895, 455);
			this.panelBody.TabIndex = 1;
			// 
			// btnRemoveNote
			// 
			this.btnRemoveNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnRemoveNote.Location = new System.Drawing.Point(731, 421);
			this.btnRemoveNote.Name = "btnRemoveNote";
			this.btnRemoveNote.Size = new System.Drawing.Size(114, 30);
			this.btnRemoveNote.TabIndex = 35;
			this.btnRemoveNote.Text = "Remove Note";
			this.btnRemoveNote.UseVisualStyleBackColor = true;
			// 
			// btnSaveNote
			// 
			this.btnSaveNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnSaveNote.Location = new System.Drawing.Point(731, 385);
			this.btnSaveNote.Name = "btnSaveNote";
			this.btnSaveNote.Size = new System.Drawing.Size(114, 30);
			this.btnSaveNote.TabIndex = 34;
			this.btnSaveNote.Text = "Save Note";
			this.btnSaveNote.UseVisualStyleBackColor = true;
			// 
			// btnUpdateBook
			// 
			this.btnUpdateBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnUpdateBook.Location = new System.Drawing.Point(731, 349);
			this.btnUpdateBook.Name = "btnUpdateBook";
			this.btnUpdateBook.Size = new System.Drawing.Size(114, 30);
			this.btnUpdateBook.TabIndex = 33;
			this.btnUpdateBook.Text = "Update Book";
			this.btnUpdateBook.UseVisualStyleBackColor = true;
			// 
			// comboBoxAuthor
			// 
			this.comboBoxAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.comboBoxAuthor.FormattingEnabled = true;
			this.comboBoxAuthor.Location = new System.Drawing.Point(226, 71);
			this.comboBoxAuthor.Name = "comboBoxAuthor";
			this.comboBoxAuthor.Size = new System.Drawing.Size(335, 28);
			this.comboBoxAuthor.TabIndex = 32;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.richTextBox1.Location = new System.Drawing.Point(278, 380);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(446, 75);
			this.richTextBox1.TabIndex = 23;
			this.richTextBox1.Text = "";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.textBox1.Location = new System.Drawing.Point(322, 349);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(403, 26);
			this.textBox1.TabIndex = 22;
			// 
			// lblNotesTitle
			// 
			this.lblNotesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblNotesTitle.Location = new System.Drawing.Point(271, 352);
			this.lblNotesTitle.Name = "lblNotesTitle";
			this.lblNotesTitle.Size = new System.Drawing.Size(45, 27);
			this.lblNotesTitle.TabIndex = 21;
			this.lblNotesTitle.Text = "Title:";
			// 
			// listBoxNotes
			// 
			this.listBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.listBoxNotes.FormattingEnabled = true;
			this.listBoxNotes.ItemHeight = 20;
			this.listBoxNotes.Location = new System.Drawing.Point(58, 352);
			this.listBoxNotes.Name = "listBoxNotes";
			this.listBoxNotes.Size = new System.Drawing.Size(207, 104);
			this.listBoxNotes.TabIndex = 20;
			// 
			// lblNotes
			// 
			this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblNotes.Location = new System.Drawing.Point(52, 326);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.Size = new System.Drawing.Size(102, 23);
			this.lblNotes.TabIndex = 19;
			// 
			// lblCollections
			// 
			this.lblCollections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblCollections.Location = new System.Drawing.Point(463, 155);
			this.lblCollections.Name = "lblCollections";
			this.lblCollections.Size = new System.Drawing.Size(102, 23);
			this.lblCollections.TabIndex = 16;
			this.lblCollections.Text = "Collections:";
			// 
			// lblSubjects
			// 
			this.lblSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblSubjects.Location = new System.Drawing.Point(58, 155);
			this.lblSubjects.Name = "lblSubjects";
			this.lblSubjects.Size = new System.Drawing.Size(102, 23);
			this.lblSubjects.TabIndex = 15;
			this.lblSubjects.Text = "Subjects:";
			// 
			// cbOnLoan
			// 
			this.cbOnLoan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbOnLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.cbOnLoan.Location = new System.Drawing.Point(725, 109);
			this.cbOnLoan.Name = "cbOnLoan";
			this.cbOnLoan.Size = new System.Drawing.Size(103, 43);
			this.cbOnLoan.TabIndex = 14;
			this.cbOnLoan.Text = "On Loan:";
			this.cbOnLoan.UseVisualStyleBackColor = true;
			// 
			// cbOwned
			// 
			this.cbOwned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbOwned.Checked = true;
			this.cbOwned.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbOwned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.cbOwned.Location = new System.Drawing.Point(576, 109);
			this.cbOwned.Name = "cbOwned";
			this.cbOwned.Size = new System.Drawing.Size(85, 43);
			this.cbOwned.TabIndex = 13;
			this.cbOwned.Text = "Owned:";
			this.cbOwned.UseVisualStyleBackColor = true;
			// 
			// tbPagesRead
			// 
			this.tbPagesRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.tbPagesRead.Location = new System.Drawing.Point(425, 116);
			this.tbPagesRead.Name = "tbPagesRead";
			this.tbPagesRead.Size = new System.Drawing.Size(58, 26);
			this.tbPagesRead.TabIndex = 12;
			// 
			// lblPagesRead
			// 
			this.lblPagesRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblPagesRead.Location = new System.Drawing.Point(322, 119);
			this.lblPagesRead.Name = "lblPagesRead";
			this.lblPagesRead.Size = new System.Drawing.Size(102, 23);
			this.lblPagesRead.TabIndex = 11;
			this.lblPagesRead.Text = "Pages Read:";
			// 
			// tbPageCount
			// 
			this.tbPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.tbPageCount.Location = new System.Drawing.Point(258, 116);
			this.tbPageCount.Name = "tbPageCount";
			this.tbPageCount.Size = new System.Drawing.Size(58, 26);
			this.tbPageCount.TabIndex = 10;
			// 
			// lblPageCount
			// 
			this.lblPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblPageCount.Location = new System.Drawing.Point(163, 119);
			this.lblPageCount.Name = "lblPageCount";
			this.lblPageCount.Size = new System.Drawing.Size(102, 23);
			this.lblPageCount.TabIndex = 9;
			this.lblPageCount.Text = "Page Count:";
			// 
			// tbPublisher
			// 
			this.tbPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.tbPublisher.Location = new System.Drawing.Point(650, 71);
			this.tbPublisher.Name = "tbPublisher";
			this.tbPublisher.Size = new System.Drawing.Size(178, 26);
			this.tbPublisher.TabIndex = 8;
			// 
			// lblPublisher
			// 
			this.lblPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblPublisher.Location = new System.Drawing.Point(567, 74);
			this.lblPublisher.Name = "lblPublisher";
			this.lblPublisher.Size = new System.Drawing.Size(81, 23);
			this.lblPublisher.TabIndex = 7;
			this.lblPublisher.Text = "Publisher:";
			this.lblPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAuthor
			// 
			this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblAuthor.Location = new System.Drawing.Point(163, 74);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(63, 23);
			this.lblAuthor.TabIndex = 5;
			this.lblAuthor.Text = "Author:";
			// 
			// tbTitle
			// 
			this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.tbTitle.Location = new System.Drawing.Point(226, 21);
			this.tbTitle.Name = "tbTitle";
			this.tbTitle.Size = new System.Drawing.Size(350, 26);
			this.tbTitle.TabIndex = 4;
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblTitle.Location = new System.Drawing.Point(172, 24);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(54, 23);
			this.lblTitle.TabIndex = 3;
			this.lblTitle.Text = "Title:";
			// 
			// tbISBN
			// 
			this.tbISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.tbISBN.Location = new System.Drawing.Point(650, 21);
			this.tbISBN.Name = "tbISBN";
			this.tbISBN.Size = new System.Drawing.Size(178, 26);
			this.tbISBN.TabIndex = 2;
			// 
			// lblISBN
			// 
			this.lblISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblISBN.Location = new System.Drawing.Point(582, 24);
			this.lblISBN.Name = "lblISBN";
			this.lblISBN.Size = new System.Drawing.Size(66, 23);
			this.lblISBN.TabIndex = 1;
			this.lblISBN.Text = "ISBN:";
			this.lblISBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Red;
			this.pictureBox1.Location = new System.Drawing.Point(52, 21);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(92, 121);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// listBoxAllSubjects
			// 
			this.listBoxAllSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.listBoxAllSubjects.FormattingEnabled = true;
			this.listBoxAllSubjects.ItemHeight = 20;
			this.listBoxAllSubjects.Location = new System.Drawing.Point(58, 190);
			this.listBoxAllSubjects.Name = "listBoxAllSubjects";
			this.listBoxAllSubjects.Size = new System.Drawing.Size(152, 124);
			this.listBoxAllSubjects.TabIndex = 24;
			// 
			// listBoxBookSubjects
			// 
			this.listBoxBookSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.listBoxBookSubjects.FormattingEnabled = true;
			this.listBoxBookSubjects.ItemHeight = 20;
			this.listBoxBookSubjects.Location = new System.Drawing.Point(271, 190);
			this.listBoxBookSubjects.Name = "listBoxBookSubjects";
			this.listBoxBookSubjects.Size = new System.Drawing.Size(153, 124);
			this.listBoxBookSubjects.TabIndex = 25;
			// 
			// listBoxAllCollections
			// 
			this.listBoxAllCollections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.listBoxAllCollections.FormattingEnabled = true;
			this.listBoxAllCollections.ItemHeight = 20;
			this.listBoxAllCollections.Location = new System.Drawing.Point(463, 190);
			this.listBoxAllCollections.Name = "listBoxAllCollections";
			this.listBoxAllCollections.Size = new System.Drawing.Size(153, 124);
			this.listBoxAllCollections.TabIndex = 26;
			// 
			// listBoxBookCollections
			// 
			this.listBoxBookCollections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.listBoxBookCollections.FormattingEnabled = true;
			this.listBoxBookCollections.ItemHeight = 20;
			this.listBoxBookCollections.Location = new System.Drawing.Point(677, 190);
			this.listBoxBookCollections.Name = "listBoxBookCollections";
			this.listBoxBookCollections.Size = new System.Drawing.Size(153, 124);
			this.listBoxBookCollections.TabIndex = 27;
			// 
			// btnRemoveSubjectFromBook
			// 
			this.btnRemoveSubjectFromBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnRemoveSubjectFromBook.Location = new System.Drawing.Point(216, 258);
			this.btnRemoveSubjectFromBook.Name = "btnRemoveSubjectFromBook";
			this.btnRemoveSubjectFromBook.Size = new System.Drawing.Size(49, 46);
			this.btnRemoveSubjectFromBook.TabIndex = 28;
			this.btnRemoveSubjectFromBook.Text = "<<";
			this.btnRemoveSubjectFromBook.UseVisualStyleBackColor = true;
			// 
			// btnAddSubjectToBook
			// 
			this.btnAddSubjectToBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnAddSubjectToBook.Location = new System.Drawing.Point(216, 206);
			this.btnAddSubjectToBook.Name = "btnAddSubjectToBook";
			this.btnAddSubjectToBook.Size = new System.Drawing.Size(49, 46);
			this.btnAddSubjectToBook.TabIndex = 29;
			this.btnAddSubjectToBook.Text = ">>";
			this.btnAddSubjectToBook.UseVisualStyleBackColor = true;
			// 
			// btnRemoveCollectionFromBook
			// 
			this.btnRemoveCollectionFromBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnRemoveCollectionFromBook.Location = new System.Drawing.Point(622, 258);
			this.btnRemoveCollectionFromBook.Name = "btnRemoveCollectionFromBook";
			this.btnRemoveCollectionFromBook.Size = new System.Drawing.Size(49, 46);
			this.btnRemoveCollectionFromBook.TabIndex = 30;
			this.btnRemoveCollectionFromBook.Text = "<<";
			this.btnRemoveCollectionFromBook.UseVisualStyleBackColor = true;
			// 
			// btnAddCollectionToBook
			// 
			this.btnAddCollectionToBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnAddCollectionToBook.Location = new System.Drawing.Point(622, 206);
			this.btnAddCollectionToBook.Name = "btnAddCollectionToBook";
			this.btnAddCollectionToBook.Size = new System.Drawing.Size(49, 46);
			this.btnAddCollectionToBook.TabIndex = 31;
			this.btnAddCollectionToBook.Text = ">>";
			this.btnAddCollectionToBook.UseVisualStyleBackColor = true;
			// 
			// BaseBookForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(895, 532);
			this.Controls.Add(this.panelBody);
			this.Controls.Add(this.panelControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(15, 15);
			this.Name = "BaseBookForm";
			this.panelBody.ResumeLayout(false);
			this.panelBody.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.ListBox listBoxBookCollections;
		private System.Windows.Forms.Button btnRemoveCollectionFromBook;
		private System.Windows.Forms.Button btnAddCollectionToBook;
		private System.Windows.Forms.ListBox listBoxAllCollections;
		private System.Windows.Forms.ListBox listBoxBookSubjects;
		private System.Windows.Forms.Button btnRemoveSubjectFromBook;
		private System.Windows.Forms.Button btnAddSubjectToBook;
		private System.Windows.Forms.ListBox listBoxAllSubjects;

		private System.Windows.Forms.Button btnSaveNote;
		private System.Windows.Forms.Button btnRemoveNote;

		private System.Windows.Forms.Button btnUpdateBook;

		private System.Windows.Forms.ComboBox comboBoxAuthor;

		private System.Windows.Forms.RichTextBox richTextBox1;

		private System.Windows.Forms.TextBox textBox1;

		private System.Windows.Forms.Label lblNotesTitle;

		private System.Windows.Forms.Label lblNotes;
		private System.Windows.Forms.ListBox listBoxNotes;

		private System.Windows.Forms.Label lblSubjects;
		private System.Windows.Forms.Label lblCollections;

		private System.Windows.Forms.CheckBox cbOnLoan;

		private System.Windows.Forms.CheckBox cbOwned;

		private System.Windows.Forms.TextBox tbTitle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.TextBox tbPublisher;
		private System.Windows.Forms.Label lblPublisher;
		private System.Windows.Forms.TextBox tbPageCount;
		private System.Windows.Forms.Label lblPageCount;
		private System.Windows.Forms.TextBox tbPagesRead;
		private System.Windows.Forms.Label lblPagesRead;

		private System.Windows.Forms.TextBox tbISBN;

		private System.Windows.Forms.Label lblISBN;

		private System.Windows.Forms.PictureBox pictureBox1;

		#endregion
	}
}