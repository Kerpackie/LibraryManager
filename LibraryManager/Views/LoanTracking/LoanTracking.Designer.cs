namespace LibraryManager.Views.LoanTracking
{
    partial class LoanTracking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            panelControls = new Panel();
            panelContent = new Panel();
            listBoxLoans = new ListBox();
            panelBottom = new Panel();
            btnUpdateLoan = new Button();
            btnReturnLoan = new Button();
            lblAllBooks = new Label();
            listBoxAllBooks = new ListBox();
            lblBooksInLoan = new Label();
            lblBorrower = new Label();
            lblReturnDate = new Label();
            tbBorrower = new TextBox();
            dtpReturnDate = new DateTimePicker();
            btnCreateLoan = new Button();
            btnRemoveBook = new Button();
            btnAddBook = new Button();
            listBoxBooksInLoan = new ListBox();
            panelContent.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelControls
            // 
            panelControls.BackColor = SystemColors.Highlight;
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(0, 0);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(908, 40);
            panelControls.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(listBoxLoans);
            panelContent.Dock = DockStyle.Left;
            panelContent.Location = new Point(0, 40);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(300, 518);
            panelContent.TabIndex = 1;
            // 
            // listBoxLoans
            // 
            listBoxLoans.FormattingEnabled = true;
            listBoxLoans.ItemHeight = 15;
            listBoxLoans.Location = new Point(12, 13);
            listBoxLoans.Name = "listBoxLoans";
            listBoxLoans.Size = new Size(276, 484);
            listBoxLoans.TabIndex = 0;
            listBoxLoans.SelectedIndexChanged += listBoxLoans_SelectedIndexChanged;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnUpdateLoan);
            panelBottom.Controls.Add(btnReturnLoan);
            panelBottom.Controls.Add(lblAllBooks);
            panelBottom.Controls.Add(listBoxAllBooks);
            panelBottom.Controls.Add(lblBooksInLoan);
            panelBottom.Controls.Add(lblBorrower);
            panelBottom.Controls.Add(lblReturnDate);
            panelBottom.Controls.Add(tbBorrower);
            panelBottom.Controls.Add(dtpReturnDate);
            panelBottom.Controls.Add(btnCreateLoan);
            panelBottom.Controls.Add(btnRemoveBook);
            panelBottom.Controls.Add(btnAddBook);
            panelBottom.Controls.Add(listBoxBooksInLoan);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(300, 40);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(608, 518);
            panelBottom.TabIndex = 2;
            // 
            // btnUpdateLoan
            // 
            btnUpdateLoan.Location = new Point(279, 446);
            btnUpdateLoan.Name = "btnUpdateLoan";
            btnUpdateLoan.Size = new Size(150, 36);
            btnUpdateLoan.TabIndex = 13;
            btnUpdateLoan.Text = "Update Loan";
            btnUpdateLoan.UseVisualStyleBackColor = true;
            btnUpdateLoan.Click += btnUpdateLoan_Click;
            // 
            // btnReturnLoan
            // 
            btnReturnLoan.Location = new Point(110, 446);
            btnReturnLoan.Name = "btnReturnLoan";
            btnReturnLoan.Size = new Size(150, 36);
            btnReturnLoan.TabIndex = 12;
            btnReturnLoan.Text = "Return Loan";
            btnReturnLoan.UseVisualStyleBackColor = true;
            btnReturnLoan.Click += btnReturnLoan_Click;
            // 
            // lblAllBooks
            // 
            lblAllBooks.AutoSize = true;
            lblAllBooks.Location = new Point(14, 57);
            lblAllBooks.Name = "lblAllBooks";
            lblAllBooks.Size = new Size(59, 15);
            lblAllBooks.TabIndex = 10;
            lblAllBooks.Text = "All Books:";
            // 
            // listBoxAllBooks
            // 
            listBoxAllBooks.FormattingEnabled = true;
            listBoxAllBooks.ItemHeight = 15;
            listBoxAllBooks.Location = new Point(18, 80);
            listBoxAllBooks.Name = "listBoxAllBooks";
            listBoxAllBooks.Size = new Size(242, 154);
            listBoxAllBooks.TabIndex = 9;
            // 
            // lblBooksInLoan
            // 
            lblBooksInLoan.AutoSize = true;
            lblBooksInLoan.Location = new Point(350, 57);
            lblBooksInLoan.Name = "lblBooksInLoan";
            lblBooksInLoan.Size = new Size(84, 15);
            lblBooksInLoan.TabIndex = 8;
            lblBooksInLoan.Text = "Books in Loan:";
            // 
            // lblBorrower
            // 
            lblBorrower.AutoSize = true;
            lblBorrower.Location = new Point(14, 16);
            lblBorrower.Name = "lblBorrower";
            lblBorrower.Size = new Size(58, 15);
            lblBorrower.TabIndex = 7;
            lblBorrower.Text = "Borrower:";
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Location = new Point(14, 89);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(72, 15);
            lblReturnDate.TabIndex = 6;
            lblReturnDate.Text = "Return Date:";
            // 
            // tbBorrower
            // 
            tbBorrower.Location = new Point(118, 13);
            tbBorrower.Name = "tbBorrower";
            tbBorrower.Size = new Size(216, 23);
            tbBorrower.TabIndex = 5;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(118, 50);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(216, 23);
            dtpReturnDate.TabIndex = 4;
            // 
            // btnCreateLoan
            // 
            btnCreateLoan.Location = new Point(446, 446);
            btnCreateLoan.Name = "btnCreateLoan";
            btnCreateLoan.Size = new Size(150, 36);
            btnCreateLoan.TabIndex = 3;
            btnCreateLoan.Text = "Add New Loan";
            btnCreateLoan.UseVisualStyleBackColor = true;
            btnCreateLoan.Click += btnCreateLoan_Click;
            // 
            // btnRemoveBook
            // 
            btnRemoveBook.Location = new Point(279, 195);
            btnRemoveBook.Name = "btnRemoveBook";
            btnRemoveBook.Size = new Size(55, 32);
            btnRemoveBook.TabIndex = 2;
            btnRemoveBook.Text = "<";
            btnRemoveBook.UseVisualStyleBackColor = true;
            btnRemoveBook.Click += btnRemoveBook_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(279, 139);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(55, 32);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = ">";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // listBoxBooksInLoan
            // 
            listBoxBooksInLoan.FormattingEnabled = true;
            listBoxBooksInLoan.ItemHeight = 15;
            listBoxBooksInLoan.Location = new Point(354, 80);
            listBoxBooksInLoan.Name = "listBoxBooksInLoan";
            listBoxBooksInLoan.Size = new Size(242, 154);
            listBoxBooksInLoan.TabIndex = 0;
            listBoxBooksInLoan.SelectedIndexChanged += listBoxBooksInLoan_SelectedIndexChanged;
            // 
            // LoanTracking
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(908, 558);
            Controls.Add(panelBottom);
            Controls.Add(panelContent);
            Controls.Add(panelControls);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoanTracking";
            Text = "Loan Tracking";
            panelContent.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelControls;
        private Panel panelContent;
        private ListBox listBoxLoans;
        private Panel panelBottom;
        private Label lblAllBooks;
        private ListBox listBoxAllBooks;
        private Label lblBooksInLoan;
        private Label lblBorrower;
        private Label lblReturnDate;
        private TextBox tbBorrower;
        private DateTimePicker dtpReturnDate;
        private Button btnCreateLoan;
        private Button btnRemoveBook;
        private Button btnAddBook;
        private ListBox listBoxBooksInLoan;
        private Button btnUpdateLoan;
        private Button btnReturnLoan;
    }
}