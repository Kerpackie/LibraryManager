namespace LibraryManager.Views.BookForms.UpdateAuthorPublisherForms
{
    partial class UpdateAuthorPublisher
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
            panelControls = new Panel();
            tbSearchPublisher = new TextBox();
            lblPublisher = new Label();
            tbAuthor = new TextBox();
            lblAuthor = new Label();
            btnAddAuthor = new Button();
            btnAddPublisher = new Button();
            panelContent = new Panel();
            tbCollection = new TextBox();
            lblCollection = new Label();
            btnAddCollection = new Button();
            tbSubject = new TextBox();
            lblSubject = new Label();
            btnAddSubject = new Button();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelControls
            // 
            panelControls.BackColor = SystemColors.Highlight;
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(0, 0);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(908, 77);
            panelControls.TabIndex = 0;
            // 
            // tbSearchPublisher
            // 
            tbSearchPublisher.Location = new Point(136, 38);
            tbSearchPublisher.Name = "tbSearchPublisher";
            tbSearchPublisher.Size = new Size(413, 26);
            tbSearchPublisher.TabIndex = 12;
            // 
            // lblPublisher
            // 
            lblPublisher.BackColor = Color.Transparent;
            lblPublisher.Location = new Point(49, 41);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(81, 23);
            lblPublisher.TabIndex = 11;
            lblPublisher.Text = "Publisher:";
            lblPublisher.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbAuthor
            // 
            tbAuthor.Location = new Point(136, 83);
            tbAuthor.Name = "tbAuthor";
            tbAuthor.Size = new Size(413, 26);
            tbAuthor.TabIndex = 10;
            // 
            // lblAuthor
            // 
            lblAuthor.Location = new Point(57, 86);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(73, 23);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "Author:";
            lblAuthor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.Location = new Point(572, 76);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(144, 33);
            btnAddAuthor.TabIndex = 6;
            btnAddAuthor.Text = "Search Author";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;
            // 
            // btnAddPublisher
            // 
            btnAddPublisher.Location = new Point(573, 31);
            btnAddPublisher.Name = "btnAddPublisher";
            btnAddPublisher.Size = new Size(144, 33);
            btnAddPublisher.TabIndex = 3;
            btnAddPublisher.Text = "Search Publisher";
            btnAddPublisher.UseVisualStyleBackColor = true;
            btnAddPublisher.Click += btnAddPublisher_Click;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(tbCollection);
            panelContent.Controls.Add(lblCollection);
            panelContent.Controls.Add(btnAddCollection);
            panelContent.Controls.Add(tbSubject);
            panelContent.Controls.Add(lblSubject);
            panelContent.Controls.Add(btnAddSubject);
            panelContent.Controls.Add(tbSearchPublisher);
            panelContent.Controls.Add(lblPublisher);
            panelContent.Controls.Add(tbAuthor);
            panelContent.Controls.Add(lblAuthor);
            panelContent.Controls.Add(btnAddAuthor);
            panelContent.Controls.Add(btnAddPublisher);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 77);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(908, 481);
            panelContent.TabIndex = 1;
            // 
            // tbCollection
            // 
            tbCollection.Location = new Point(136, 178);
            tbCollection.Name = "tbCollection";
            tbCollection.Size = new Size(413, 26);
            tbCollection.TabIndex = 18;
            // 
            // lblCollection
            // 
            lblCollection.Location = new Point(49, 181);
            lblCollection.Name = "lblCollection";
            lblCollection.Size = new Size(81, 23);
            lblCollection.TabIndex = 17;
            lblCollection.Text = "Collection:";
            lblCollection.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnAddCollection
            // 
            btnAddCollection.Location = new Point(572, 171);
            btnAddCollection.Name = "btnAddCollection";
            btnAddCollection.Size = new Size(144, 33);
            btnAddCollection.TabIndex = 16;
            btnAddCollection.Text = "Search Author";
            btnAddCollection.UseVisualStyleBackColor = true;
            btnAddCollection.Click += btnAddCollection_Click;
            // 
            // tbSubject
            // 
            tbSubject.Location = new Point(136, 133);
            tbSubject.Name = "tbSubject";
            tbSubject.Size = new Size(413, 26);
            tbSubject.TabIndex = 15;
            // 
            // lblSubject
            // 
            lblSubject.Location = new Point(57, 136);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(73, 23);
            lblSubject.TabIndex = 14;
            lblSubject.Text = "Subject:";
            lblSubject.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnAddSubject
            // 
            btnAddSubject.Location = new Point(572, 126);
            btnAddSubject.Name = "btnAddSubject";
            btnAddSubject.Size = new Size(144, 33);
            btnAddSubject.TabIndex = 13;
            btnAddSubject.Text = "Search Author";
            btnAddSubject.UseVisualStyleBackColor = true;
            btnAddSubject.Click += btnAddSubject_Click;
            // 
            // UpdateAuthorPublisher
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(908, 558);
            Controls.Add(panelContent);
            Controls.Add(panelControls);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "UpdateAuthorPublisher";
            Text = "SearchBookForm";
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox tbSearchPublisher;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Button btnAddPublisher;
        private System.Windows.Forms.Button btnAddAuthor;

        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Panel panelControls;

        #endregion

        private TextBox tbCollection;
        private Label lblCollection;
        private Button btnAddCollection;
        private TextBox tbSubject;
        private Label lblSubject;
        private Button btnAddSubject;
    }
}