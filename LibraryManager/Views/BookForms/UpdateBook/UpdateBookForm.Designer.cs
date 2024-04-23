namespace LibraryManager.Views.BookForms.UpdateBook
{
    partial class UpdateBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
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
            panelControl = new Panel();
            btnToggleEdit = new Button();
            btnImportBook = new Button();
            checkBoxSearchOwned = new CheckBox();
            tbISBNSearch = new TextBox();
            lblISBNSearch = new Label();
            panelBody = new Panel();
            listBoxAllSubjects = new ListBox();
            btnAddCollectionToBook = new Button();
            btnRemoveCollectionFromBook = new Button();
            btnAddSubjectToBook = new Button();
            btnRemoveSubjectFromBook = new Button();
            listBoxBookCollections = new ListBox();
            listBoxAllCollections = new ListBox();
            listBoxBookSubjects = new ListBox();
            comboBoxPublisher = new ComboBox();
            btnRemoveNote = new Button();
            btnSaveNote = new Button();
            btnUpdateBook = new Button();
            comboBoxAuthor = new ComboBox();
            richTextBox1 = new RichTextBox();
            tbNoteTitle = new TextBox();
            lblNotesTitle = new Label();
            listBoxNotes = new ListBox();
            lblNotes = new Label();
            lblCollections = new Label();
            lblSubjects = new Label();
            cbOnLoan = new CheckBox();
            cbOwned = new CheckBox();
            tbPagesRead = new TextBox();
            lblPagesRead = new Label();
            tbPageCount = new TextBox();
            lblPageCount = new Label();
            lblPublisher = new Label();
            lblAuthor = new Label();
            tbTitle = new TextBox();
            lblTitle = new Label();
            tbISBN = new TextBox();
            lblISBN = new Label();
            pictureBox1 = new PictureBox();
            panelControl.SuspendLayout();
            panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelControl
            // 
            panelControl.BackColor = SystemColors.HotTrack;
            panelControl.Controls.Add(btnToggleEdit);
            panelControl.Dock = DockStyle.Top;
            panelControl.Location = new Point(0, 0);
            panelControl.Margin = new Padding(4, 3, 4, 3);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(1059, 89);
            panelControl.TabIndex = 0;
            // 
            // btnToggleEdit
            // 
            btnToggleEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnToggleEdit.Location = new Point(840, 12);
            btnToggleEdit.Name = "btnToggleEdit";
            btnToggleEdit.Size = new Size(146, 60);
            btnToggleEdit.TabIndex = 0;
            btnToggleEdit.Text = "Toggle Edit";
            btnToggleEdit.UseVisualStyleBackColor = true;
            btnToggleEdit.Click += btnToggleEdit_Click;
            // 
            // btnImportBook
            // 
            btnImportBook.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnImportBook.Location = new Point(769, 12);
            btnImportBook.Name = "btnImportBook";
            btnImportBook.Size = new Size(114, 59);
            btnImportBook.TabIndex = 37;
            btnImportBook.Text = "Import Book";
            btnImportBook.UseVisualStyleBackColor = true;
            // 
            // checkBoxSearchOwned
            // 
            checkBoxSearchOwned.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxSearchOwned.Checked = true;
            checkBoxSearchOwned.CheckState = CheckState.Checked;
            checkBoxSearchOwned.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSearchOwned.Location = new Point(12, 41);
            checkBoxSearchOwned.Name = "checkBoxSearchOwned";
            checkBoxSearchOwned.Size = new Size(85, 36);
            checkBoxSearchOwned.TabIndex = 14;
            checkBoxSearchOwned.Text = "Owned:";
            checkBoxSearchOwned.UseVisualStyleBackColor = true;
            // 
            // tbISBNSearch
            // 
            tbISBNSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbISBNSearch.Location = new Point(74, 12);
            tbISBNSearch.Name = "tbISBNSearch";
            tbISBNSearch.Size = new Size(260, 26);
            tbISBNSearch.TabIndex = 6;
            // 
            // lblISBNSearch
            // 
            lblISBNSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblISBNSearch.Location = new Point(20, 15);
            lblISBNSearch.Name = "lblISBNSearch";
            lblISBNSearch.Size = new Size(54, 23);
            lblISBNSearch.TabIndex = 5;
            lblISBNSearch.Text = "ISBN:";
            // 
            // panelBody
            // 
            panelBody.BackColor = SystemColors.ControlLight;
            panelBody.Controls.Add(listBoxAllSubjects);
            panelBody.Controls.Add(btnAddCollectionToBook);
            panelBody.Controls.Add(btnRemoveCollectionFromBook);
            panelBody.Controls.Add(btnAddSubjectToBook);
            panelBody.Controls.Add(btnRemoveSubjectFromBook);
            panelBody.Controls.Add(listBoxBookCollections);
            panelBody.Controls.Add(listBoxAllCollections);
            panelBody.Controls.Add(listBoxBookSubjects);
            panelBody.Controls.Add(comboBoxPublisher);
            panelBody.Controls.Add(btnRemoveNote);
            panelBody.Controls.Add(btnSaveNote);
            panelBody.Controls.Add(btnUpdateBook);
            panelBody.Controls.Add(comboBoxAuthor);
            panelBody.Controls.Add(richTextBox1);
            panelBody.Controls.Add(tbNoteTitle);
            panelBody.Controls.Add(lblNotesTitle);
            panelBody.Controls.Add(listBoxNotes);
            panelBody.Controls.Add(lblNotes);
            panelBody.Controls.Add(lblCollections);
            panelBody.Controls.Add(lblSubjects);
            panelBody.Controls.Add(cbOnLoan);
            panelBody.Controls.Add(cbOwned);
            panelBody.Controls.Add(tbPagesRead);
            panelBody.Controls.Add(lblPagesRead);
            panelBody.Controls.Add(tbPageCount);
            panelBody.Controls.Add(lblPageCount);
            panelBody.Controls.Add(lblPublisher);
            panelBody.Controls.Add(lblAuthor);
            panelBody.Controls.Add(tbTitle);
            panelBody.Controls.Add(lblTitle);
            panelBody.Controls.Add(tbISBN);
            panelBody.Controls.Add(lblISBN);
            panelBody.Controls.Add(pictureBox1);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 89);
            panelBody.Margin = new Padding(4, 3, 4, 3);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1059, 555);
            panelBody.TabIndex = 1;
            // 
            // listBoxAllSubjects
            // 
            listBoxAllSubjects.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxAllSubjects.FormattingEnabled = true;
            listBoxAllSubjects.ItemHeight = 20;
            listBoxAllSubjects.Location = new Point(93, 225);
            listBoxAllSubjects.Name = "listBoxAllSubjects";
            listBoxAllSubjects.Size = new Size(152, 124);
            listBoxAllSubjects.TabIndex = 24;
            // 
            // btnAddCollectionToBook
            // 
            btnAddCollectionToBook.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddCollectionToBook.Location = new Point(739, 241);
            btnAddCollectionToBook.Name = "btnAddCollectionToBook";
            btnAddCollectionToBook.Size = new Size(49, 46);
            btnAddCollectionToBook.TabIndex = 31;
            btnAddCollectionToBook.Text = ">>";
            btnAddCollectionToBook.UseVisualStyleBackColor = true;
            btnAddCollectionToBook.Click += btnAddCollectionToBook_Click;
            // 
            // btnRemoveCollectionFromBook
            // 
            btnRemoveCollectionFromBook.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveCollectionFromBook.Location = new Point(739, 293);
            btnRemoveCollectionFromBook.Name = "btnRemoveCollectionFromBook";
            btnRemoveCollectionFromBook.Size = new Size(49, 46);
            btnRemoveCollectionFromBook.TabIndex = 30;
            btnRemoveCollectionFromBook.Text = "<<";
            btnRemoveCollectionFromBook.UseVisualStyleBackColor = true;
            btnRemoveCollectionFromBook.Click += btnRemoveCollectionFromBook_Click;
            // 
            // btnAddSubjectToBook
            // 
            btnAddSubjectToBook.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddSubjectToBook.Location = new Point(251, 241);
            btnAddSubjectToBook.Name = "btnAddSubjectToBook";
            btnAddSubjectToBook.Size = new Size(49, 46);
            btnAddSubjectToBook.TabIndex = 29;
            btnAddSubjectToBook.Text = ">>";
            btnAddSubjectToBook.UseVisualStyleBackColor = true;
            btnAddSubjectToBook.Click += btnAddSubjectToBook_Click;
            // 
            // btnRemoveSubjectFromBook
            // 
            btnRemoveSubjectFromBook.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveSubjectFromBook.Location = new Point(251, 293);
            btnRemoveSubjectFromBook.Name = "btnRemoveSubjectFromBook";
            btnRemoveSubjectFromBook.Size = new Size(49, 46);
            btnRemoveSubjectFromBook.TabIndex = 28;
            btnRemoveSubjectFromBook.Text = "<<";
            btnRemoveSubjectFromBook.UseVisualStyleBackColor = true;
            btnRemoveSubjectFromBook.Click += btnRemoveSubjectFromBook_Click;
            // 
            // listBoxBookCollections
            // 
            listBoxBookCollections.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxBookCollections.FormattingEnabled = true;
            listBoxBookCollections.ItemHeight = 20;
            listBoxBookCollections.Location = new Point(794, 225);
            listBoxBookCollections.Name = "listBoxBookCollections";
            listBoxBookCollections.Size = new Size(153, 124);
            listBoxBookCollections.TabIndex = 27;
            // 
            // listBoxAllCollections
            // 
            listBoxAllCollections.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxAllCollections.FormattingEnabled = true;
            listBoxAllCollections.ItemHeight = 20;
            listBoxAllCollections.Location = new Point(580, 225);
            listBoxAllCollections.Name = "listBoxAllCollections";
            listBoxAllCollections.Size = new Size(153, 124);
            listBoxAllCollections.TabIndex = 26;
            // 
            // listBoxBookSubjects
            // 
            listBoxBookSubjects.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxBookSubjects.FormattingEnabled = true;
            listBoxBookSubjects.ItemHeight = 20;
            listBoxBookSubjects.Location = new Point(306, 225);
            listBoxBookSubjects.Name = "listBoxBookSubjects";
            listBoxBookSubjects.Size = new Size(153, 124);
            listBoxBookSubjects.TabIndex = 25;
            // 
            // comboBoxPublisher
            // 
            comboBoxPublisher.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxPublisher.FormattingEnabled = true;
            comboBoxPublisher.Location = new Point(758, 83);
            comboBoxPublisher.Margin = new Padding(4, 3, 4, 3);
            comboBoxPublisher.Name = "comboBoxPublisher";
            comboBoxPublisher.Size = new Size(207, 28);
            comboBoxPublisher.TabIndex = 36;
            // 
            // btnRemoveNote
            // 
            btnRemoveNote.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveNote.Location = new Point(853, 486);
            btnRemoveNote.Margin = new Padding(4, 3, 4, 3);
            btnRemoveNote.Name = "btnRemoveNote";
            btnRemoveNote.Size = new Size(133, 35);
            btnRemoveNote.TabIndex = 35;
            btnRemoveNote.Text = "Remove Note";
            btnRemoveNote.UseVisualStyleBackColor = true;
            btnRemoveNote.Click += btnRemoveNote_Click;
            // 
            // btnSaveNote
            // 
            btnSaveNote.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveNote.Location = new Point(853, 444);
            btnSaveNote.Margin = new Padding(4, 3, 4, 3);
            btnSaveNote.Name = "btnSaveNote";
            btnSaveNote.Size = new Size(133, 35);
            btnSaveNote.TabIndex = 34;
            btnSaveNote.Text = "Save Note";
            btnSaveNote.UseVisualStyleBackColor = true;
            btnSaveNote.Click += btnSaveNote_Click;
            // 
            // btnUpdateBook
            // 
            btnUpdateBook.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateBook.Location = new Point(853, 403);
            btnUpdateBook.Margin = new Padding(4, 3, 4, 3);
            btnUpdateBook.Name = "btnUpdateBook";
            btnUpdateBook.Size = new Size(133, 35);
            btnUpdateBook.TabIndex = 33;
            btnUpdateBook.Text = "Update Book";
            btnUpdateBook.UseVisualStyleBackColor = true;
            btnUpdateBook.Click += btnUpdateBook_Click;
            // 
            // comboBoxAuthor
            // 
            comboBoxAuthor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxAuthor.FormattingEnabled = true;
            comboBoxAuthor.Location = new Point(264, 82);
            comboBoxAuthor.Margin = new Padding(4, 3, 4, 3);
            comboBoxAuthor.Name = "comboBoxAuthor";
            comboBoxAuthor.Size = new Size(390, 28);
            comboBoxAuthor.TabIndex = 32;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(324, 438);
            richTextBox1.Margin = new Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(520, 86);
            richTextBox1.TabIndex = 23;
            richTextBox1.Text = "";
            // 
            // tbNoteTitle
            // 
            tbNoteTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbNoteTitle.Location = new Point(376, 403);
            tbNoteTitle.Margin = new Padding(4, 3, 4, 3);
            tbNoteTitle.Name = "tbNoteTitle";
            tbNoteTitle.Size = new Size(469, 26);
            tbNoteTitle.TabIndex = 22;
            // 
            // lblNotesTitle
            // 
            lblNotesTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNotesTitle.Location = new Point(316, 406);
            lblNotesTitle.Margin = new Padding(4, 0, 4, 0);
            lblNotesTitle.Name = "lblNotesTitle";
            lblNotesTitle.Size = new Size(52, 31);
            lblNotesTitle.TabIndex = 21;
            lblNotesTitle.Text = "Title:";
            // 
            // listBoxNotes
            // 
            listBoxNotes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxNotes.FormattingEnabled = true;
            listBoxNotes.ItemHeight = 20;
            listBoxNotes.Location = new Point(68, 406);
            listBoxNotes.Margin = new Padding(4, 3, 4, 3);
            listBoxNotes.Name = "listBoxNotes";
            listBoxNotes.Size = new Size(241, 104);
            listBoxNotes.TabIndex = 20;
            // 
            // lblNotes
            // 
            lblNotes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNotes.Location = new Point(61, 376);
            lblNotes.Margin = new Padding(4, 0, 4, 0);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(119, 27);
            lblNotes.TabIndex = 19;
            // 
            // lblCollections
            // 
            lblCollections.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCollections.Location = new Point(580, 179);
            lblCollections.Margin = new Padding(4, 0, 4, 0);
            lblCollections.Name = "lblCollections";
            lblCollections.Size = new Size(119, 27);
            lblCollections.TabIndex = 16;
            lblCollections.Text = "Collections:";
            // 
            // lblSubjects
            // 
            lblSubjects.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubjects.Location = new Point(93, 179);
            lblSubjects.Margin = new Padding(4, 0, 4, 0);
            lblSubjects.Name = "lblSubjects";
            lblSubjects.Size = new Size(119, 27);
            lblSubjects.TabIndex = 15;
            lblSubjects.Text = "Subjects:";
            // 
            // cbOnLoan
            // 
            cbOnLoan.CheckAlign = ContentAlignment.MiddleRight;
            cbOnLoan.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbOnLoan.Location = new Point(846, 126);
            cbOnLoan.Margin = new Padding(4, 3, 4, 3);
            cbOnLoan.Name = "cbOnLoan";
            cbOnLoan.Size = new Size(120, 50);
            cbOnLoan.TabIndex = 14;
            cbOnLoan.Text = "On Loan:";
            cbOnLoan.UseVisualStyleBackColor = true;
            // 
            // cbOwned
            // 
            cbOwned.CheckAlign = ContentAlignment.MiddleRight;
            cbOwned.Checked = true;
            cbOwned.CheckState = CheckState.Checked;
            cbOwned.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbOwned.Location = new Point(672, 126);
            cbOwned.Margin = new Padding(4, 3, 4, 3);
            cbOwned.Name = "cbOwned";
            cbOwned.Size = new Size(99, 50);
            cbOwned.TabIndex = 13;
            cbOwned.Text = "Owned:";
            cbOwned.UseVisualStyleBackColor = true;
            // 
            // tbPagesRead
            // 
            tbPagesRead.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPagesRead.Location = new Point(496, 134);
            tbPagesRead.Margin = new Padding(4, 3, 4, 3);
            tbPagesRead.Name = "tbPagesRead";
            tbPagesRead.Size = new Size(67, 26);
            tbPagesRead.TabIndex = 12;
            // 
            // lblPagesRead
            // 
            lblPagesRead.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPagesRead.Location = new Point(376, 137);
            lblPagesRead.Margin = new Padding(4, 0, 4, 0);
            lblPagesRead.Name = "lblPagesRead";
            lblPagesRead.Size = new Size(119, 27);
            lblPagesRead.TabIndex = 11;
            lblPagesRead.Text = "Pages Read:";
            // 
            // tbPageCount
            // 
            tbPageCount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPageCount.Location = new Point(301, 134);
            tbPageCount.Margin = new Padding(4, 3, 4, 3);
            tbPageCount.Name = "tbPageCount";
            tbPageCount.Size = new Size(67, 26);
            tbPageCount.TabIndex = 10;
            // 
            // lblPageCount
            // 
            lblPageCount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPageCount.Location = new Point(190, 137);
            lblPageCount.Margin = new Padding(4, 0, 4, 0);
            lblPageCount.Name = "lblPageCount";
            lblPageCount.Size = new Size(119, 27);
            lblPageCount.TabIndex = 9;
            lblPageCount.Text = "Page Count:";
            // 
            // lblPublisher
            // 
            lblPublisher.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPublisher.Location = new Point(662, 85);
            lblPublisher.Margin = new Padding(4, 0, 4, 0);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(94, 27);
            lblPublisher.TabIndex = 7;
            lblPublisher.Text = "Publisher:";
            lblPublisher.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAuthor
            // 
            lblAuthor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAuthor.Location = new Point(190, 85);
            lblAuthor.Margin = new Padding(4, 0, 4, 0);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(74, 27);
            lblAuthor.TabIndex = 5;
            lblAuthor.Text = "Author:";
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbTitle.Location = new Point(264, 24);
            tbTitle.Margin = new Padding(4, 3, 4, 3);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(408, 26);
            tbTitle.TabIndex = 4;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(201, 28);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(63, 27);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Title:";
            // 
            // tbISBN
            // 
            tbISBN.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbISBN.Location = new Point(758, 24);
            tbISBN.Margin = new Padding(4, 3, 4, 3);
            tbISBN.Name = "tbISBN";
            tbISBN.Size = new Size(207, 26);
            tbISBN.TabIndex = 2;
            // 
            // lblISBN
            // 
            lblISBN.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblISBN.Location = new Point(679, 28);
            lblISBN.Margin = new Padding(4, 0, 4, 0);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(77, 27);
            lblISBN.TabIndex = 1;
            lblISBN.Text = "ISBN:";
            lblISBN.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Red;
            pictureBox1.Location = new Point(61, 24);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 140);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // UpdateBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1059, 644);
            Controls.Add(panelBody);
            Controls.Add(panelControl);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(15, 15);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UpdateBookForm";
            panelControl.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            panelBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox tbISBNSearch;
        private System.Windows.Forms.Label lblISBNSearch;
        private System.Windows.Forms.CheckBox checkBoxSearchOwned;
        private System.Windows.Forms.ComboBox comboBoxPublisher;
        private System.Windows.Forms.Button btnImportBook;

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

        private System.Windows.Forms.TextBox tbNoteTitle;

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
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox tbPageCount;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.TextBox tbPagesRead;
        private System.Windows.Forms.Label lblPagesRead;

        private System.Windows.Forms.TextBox tbISBN;

        private System.Windows.Forms.Label lblISBN;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion

        private Button btnToggleEdit;
    }
}