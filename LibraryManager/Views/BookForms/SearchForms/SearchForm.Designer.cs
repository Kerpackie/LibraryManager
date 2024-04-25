namespace LibraryManager.Views.BookForms.SearchForms
{
    partial class SearchForm
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
            btnSearchISBN = new Button();
            btnSearchTitle = new Button();
            cbIsLoaned = new CheckBox();
            cbIsOwned = new CheckBox();
            tbSearchPublisher = new TextBox();
            lblPublisher = new Label();
            tbAuthor = new TextBox();
            lblAuthor = new Label();
            tbSearchTitle = new TextBox();
            lblSearchTitle = new Label();
            btnSearchOwned = new Button();
            btnSearchAuthor = new Button();
            btnSearchPublisher = new Button();
            btnSearchLoaned = new Button();
            tbSearchISBN = new TextBox();
            lblISBN = new Label();
            panelContent = new Panel();
            listBoxSearchResults = new ListBox();
            panelControls.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelControls
            // 
            panelControls.BackColor = SystemColors.Highlight;
            panelControls.Controls.Add(btnSearchISBN);
            panelControls.Controls.Add(btnSearchTitle);
            panelControls.Controls.Add(cbIsLoaned);
            panelControls.Controls.Add(cbIsOwned);
            panelControls.Controls.Add(tbSearchPublisher);
            panelControls.Controls.Add(lblPublisher);
            panelControls.Controls.Add(tbAuthor);
            panelControls.Controls.Add(lblAuthor);
            panelControls.Controls.Add(tbSearchTitle);
            panelControls.Controls.Add(lblSearchTitle);
            panelControls.Controls.Add(btnSearchOwned);
            panelControls.Controls.Add(btnSearchAuthor);
            panelControls.Controls.Add(btnSearchPublisher);
            panelControls.Controls.Add(btnSearchLoaned);
            panelControls.Controls.Add(tbSearchISBN);
            panelControls.Controls.Add(lblISBN);
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(0, 0);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(908, 77);
            panelControls.TabIndex = 0;
            // 
            // btnSearchISBN
            // 
            btnSearchISBN.Location = new Point(495, 2);
            btnSearchISBN.Name = "btnSearchISBN";
            btnSearchISBN.Size = new Size(124, 33);
            btnSearchISBN.TabIndex = 16;
            btnSearchISBN.Text = "Search ISBN";
            btnSearchISBN.UseVisualStyleBackColor = true;
            btnSearchISBN.Click += btnSearchISBN_Click;
            // 
            // btnSearchTitle
            // 
            btnSearchTitle.Location = new Point(495, 37);
            btnSearchTitle.Name = "btnSearchTitle";
            btnSearchTitle.Size = new Size(124, 33);
            btnSearchTitle.TabIndex = 15;
            btnSearchTitle.Text = "Search Title";
            btnSearchTitle.UseVisualStyleBackColor = true;
            btnSearchTitle.Click += btnSearchTitle_Click;
            // 
            // cbIsLoaned
            // 
            cbIsLoaned.CheckAlign = ContentAlignment.MiddleRight;
            cbIsLoaned.Location = new Point(400, 42);
            cbIsLoaned.Name = "cbIsLoaned";
            cbIsLoaned.RightToLeft = RightToLeft.No;
            cbIsLoaned.Size = new Size(89, 24);
            cbIsLoaned.TabIndex = 14;
            cbIsLoaned.Text = "Loaned:";
            cbIsLoaned.TextAlign = ContentAlignment.MiddleRight;
            cbIsLoaned.UseVisualStyleBackColor = true;
            // 
            // cbIsOwned
            // 
            cbIsOwned.CheckAlign = ContentAlignment.MiddleRight;
            cbIsOwned.Location = new Point(400, 10);
            cbIsOwned.Name = "cbIsOwned";
            cbIsOwned.RightToLeft = RightToLeft.No;
            cbIsOwned.Size = new Size(89, 24);
            cbIsOwned.TabIndex = 13;
            cbIsOwned.Text = "Owned:";
            cbIsOwned.TextAlign = ContentAlignment.MiddleRight;
            cbIsOwned.UseVisualStyleBackColor = true;
            // 
            // tbSearchPublisher
            // 
            tbSearchPublisher.Location = new Point(278, 40);
            tbSearchPublisher.Name = "tbSearchPublisher";
            tbSearchPublisher.Size = new Size(116, 26);
            tbSearchPublisher.TabIndex = 12;
            // 
            // lblPublisher
            // 
            lblPublisher.BackColor = Color.Transparent;
            lblPublisher.Location = new Point(191, 43);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(81, 23);
            lblPublisher.TabIndex = 11;
            lblPublisher.Text = "Publisher:";
            lblPublisher.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbAuthor
            // 
            tbAuthor.Location = new Point(278, 8);
            tbAuthor.Name = "tbAuthor";
            tbAuthor.Size = new Size(116, 26);
            tbAuthor.TabIndex = 10;
            // 
            // lblAuthor
            // 
            lblAuthor.Location = new Point(199, 11);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(73, 23);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "Author:";
            lblAuthor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbSearchTitle
            // 
            tbSearchTitle.Location = new Point(74, 40);
            tbSearchTitle.Name = "tbSearchTitle";
            tbSearchTitle.Size = new Size(116, 26);
            tbSearchTitle.TabIndex = 8;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.Location = new Point(12, 41);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(56, 23);
            lblSearchTitle.TabIndex = 7;
            lblSearchTitle.Text = "Title:";
            lblSearchTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSearchOwned
            // 
            btnSearchOwned.Location = new Point(772, 3);
            btnSearchOwned.Name = "btnSearchOwned";
            btnSearchOwned.Size = new Size(133, 33);
            btnSearchOwned.TabIndex = 6;
            btnSearchOwned.Text = "Search Owned";
            btnSearchOwned.UseVisualStyleBackColor = true;
            btnSearchOwned.Click += btnSearchOwned_Click;
            // 
            // btnSearchAuthor
            // 
            btnSearchAuthor.Location = new Point(625, 2);
            btnSearchAuthor.Name = "btnSearchAuthor";
            btnSearchAuthor.Size = new Size(141, 33);
            btnSearchAuthor.TabIndex = 5;
            btnSearchAuthor.Text = "Search Author";
            btnSearchAuthor.UseVisualStyleBackColor = true;
            btnSearchAuthor.Click += btnSearchAuthor_Click;
            // 
            // btnSearchPublisher
            // 
            btnSearchPublisher.Location = new Point(625, 37);
            btnSearchPublisher.Name = "btnSearchPublisher";
            btnSearchPublisher.Size = new Size(141, 33);
            btnSearchPublisher.TabIndex = 4;
            btnSearchPublisher.Text = "Search Publisher";
            btnSearchPublisher.UseVisualStyleBackColor = true;
            btnSearchPublisher.Click += btnSearchPublisher_Click;
            // 
            // btnSearchLoaned
            // 
            btnSearchLoaned.Location = new Point(772, 38);
            btnSearchLoaned.Name = "btnSearchLoaned";
            btnSearchLoaned.Size = new Size(133, 33);
            btnSearchLoaned.TabIndex = 3;
            btnSearchLoaned.Text = "Search Loaned";
            btnSearchLoaned.UseVisualStyleBackColor = true;
            btnSearchLoaned.Click += btnSearchLoaned_Click;
            // 
            // tbSearchISBN
            // 
            tbSearchISBN.Location = new Point(74, 6);
            tbSearchISBN.Name = "tbSearchISBN";
            tbSearchISBN.Size = new Size(116, 26);
            tbSearchISBN.TabIndex = 1;
            // 
            // lblISBN
            // 
            lblISBN.Location = new Point(12, 9);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(56, 23);
            lblISBN.TabIndex = 0;
            lblISBN.Text = "ISBN:";
            lblISBN.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(listBoxSearchResults);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 77);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(908, 481);
            panelContent.TabIndex = 1;
            // 
            // listBoxSearchResults
            // 
            listBoxSearchResults.FormattingEnabled = true;
            listBoxSearchResults.ItemHeight = 20;
            listBoxSearchResults.Location = new Point(14, 10);
            listBoxSearchResults.Name = "listBoxSearchResults";
            listBoxSearchResults.Size = new Size(882, 464);
            listBoxSearchResults.TabIndex = 0;
            listBoxSearchResults.DoubleClick += listBoxSearchResults_DoubleClick;
            // 
            // SearchForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(908, 558);
            Controls.Add(panelContent);
            Controls.Add(panelControls);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "SearchForm";
            Text = "SearchBookForm";
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listBoxSearchResults;

        private System.Windows.Forms.TextBox tbSearchPublisher;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label lblAuthor;

        private System.Windows.Forms.TextBox tbSearchTitle;
        private System.Windows.Forms.Label lblSearchTitle;

        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox tbSearchISBN;
        private System.Windows.Forms.Button btnSearchPublisher;
        private System.Windows.Forms.Button btnSearchLoaned;
        private System.Windows.Forms.Button btnSearchAuthor;
        private System.Windows.Forms.Button btnSearchOwned;

        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Panel panelControls;

        #endregion

        private Button btnSearchISBN;
        private Button btnSearchTitle;
        private CheckBox cbIsLoaned;
        private CheckBox cbIsOwned;
    }
}