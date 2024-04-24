namespace LibraryManager.Views.BookForms.Statistics
{
    partial class BookStatisticsForm
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
            lblProgress = new Label();
            progressBar = new ProgressBar();
            lblBookTitle = new Label();
            tbAveragePagesPerBook = new TextBox();
            tbTotalPagesRead = new TextBox();
            tbTotalBooks = new TextBox();
            lblAveragePagesPerBook = new Label();
            lblTotalPagesRead = new Label();
            lblTotalBooks = new Label();
            panelContent = new Panel();
            listBoxBooks = new ListBox();
            panelControls.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelControls
            // 
            panelControls.BackColor = SystemColors.Highlight;
            panelControls.Controls.Add(lblProgress);
            panelControls.Controls.Add(progressBar);
            panelControls.Controls.Add(lblBookTitle);
            panelControls.Controls.Add(tbAveragePagesPerBook);
            panelControls.Controls.Add(tbTotalPagesRead);
            panelControls.Controls.Add(tbTotalBooks);
            panelControls.Controls.Add(lblAveragePagesPerBook);
            panelControls.Controls.Add(lblTotalPagesRead);
            panelControls.Controls.Add(lblTotalBooks);
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(0, 0);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(908, 150);
            panelControls.TabIndex = 0;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.ForeColor = Color.White;
            lblProgress.Location = new Point(419, 83);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(90, 18);
            lblProgress.TabIndex = 9;
            lblProgress.Text = "Progress %";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(16, 121);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(876, 23);
            progressBar.TabIndex = 8;
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblBookTitle.ForeColor = Color.White;
            lblBookTitle.Location = new Point(19, 83);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(126, 22);
            lblBookTitle.TabIndex = 7;
            lblBookTitle.Text = "Current Title";
            // 
            // tbAveragePagesPerBook
            // 
            tbAveragePagesPerBook.Location = new Point(798, 20);
            tbAveragePagesPerBook.Name = "tbAveragePagesPerBook";
            tbAveragePagesPerBook.Size = new Size(100, 26);
            tbAveragePagesPerBook.TabIndex = 6;
            // 
            // tbTotalPagesRead
            // 
            tbTotalPagesRead.Location = new Point(316, 50);
            tbTotalPagesRead.Name = "tbTotalPagesRead";
            tbTotalPagesRead.Size = new Size(100, 26);
            tbTotalPagesRead.TabIndex = 5;
            // 
            // tbTotalBooks
            // 
            tbTotalBooks.Location = new Point(316, 18);
            tbTotalBooks.Name = "tbTotalBooks";
            tbTotalBooks.Size = new Size(100, 26);
            tbTotalBooks.TabIndex = 4;
            // 
            // lblAveragePagesPerBook
            // 
            lblAveragePagesPerBook.AutoSize = true;
            lblAveragePagesPerBook.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAveragePagesPerBook.ForeColor = Color.White;
            lblAveragePagesPerBook.Location = new Point(458, 23);
            lblAveragePagesPerBook.Name = "lblAveragePagesPerBook";
            lblAveragePagesPerBook.Size = new Size(251, 22);
            lblAveragePagesPerBook.TabIndex = 2;
            lblAveragePagesPerBook.Text = "Average Pages per Book: ";
            // 
            // lblTotalPagesRead
            // 
            lblTotalPagesRead.AutoSize = true;
            lblTotalPagesRead.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalPagesRead.ForeColor = Color.White;
            lblTotalPagesRead.Location = new Point(12, 54);
            lblTotalPagesRead.Name = "lblTotalPagesRead";
            lblTotalPagesRead.Size = new Size(183, 22);
            lblTotalPagesRead.TabIndex = 1;
            lblTotalPagesRead.Text = "Total Pages Read: ";
            // 
            // lblTotalBooks
            // 
            lblTotalBooks.AutoSize = true;
            lblTotalBooks.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalBooks.ForeColor = Color.White;
            lblTotalBooks.Location = new Point(12, 22);
            lblTotalBooks.Name = "lblTotalBooks";
            lblTotalBooks.Size = new Size(133, 22);
            lblTotalBooks.TabIndex = 0;
            lblTotalBooks.Text = "Total Books: ";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(listBoxBooks);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 150);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(908, 408);
            panelContent.TabIndex = 1;
            // 
            // listBoxBooks
            // 
            listBoxBooks.FormattingEnabled = true;
            listBoxBooks.ItemHeight = 18;
            listBoxBooks.Location = new Point(16, 13);
            listBoxBooks.Name = "listBoxBooks";
            listBoxBooks.Size = new Size(876, 382);
            listBoxBooks.TabIndex = 0;
            listBoxBooks.SelectedIndexChanged += listBoxBooks_SelectedIndexChanged;
            // 
            // BookStatisticsForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(908, 558);
            Controls.Add(panelContent);
            Controls.Add(panelControls);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "BookStatisticsForm";
            Text = "BookReadingStatisticsForm";
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label lblTotalPagesRead;
        private System.Windows.Forms.Label lblAveragePagesPerBook;
        private System.Windows.Forms.TextBox tbTotalBooks;
        private System.Windows.Forms.TextBox tbTotalPagesRead;
        private System.Windows.Forms.TextBox tbAveragePagesPerBook;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ListBox listBoxBooks;



        #endregion

        private Label lblProgress;
        private ProgressBar progressBar;
        private Label lblBookTitle;
    }
}