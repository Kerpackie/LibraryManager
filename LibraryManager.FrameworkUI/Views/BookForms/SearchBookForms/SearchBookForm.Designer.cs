using System.ComponentModel;

namespace LibraryManager.FrameworkUI.Views.BookForms.SearchBookForms
{
	partial class SearchBookForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

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
			this.panelControls = new System.Windows.Forms.Panel();
			this.cbIsLoaned = new System.Windows.Forms.CheckBox();
			this.cbIsOwned = new System.Windows.Forms.CheckBox();
			this.tbSearchPublisher = new System.Windows.Forms.TextBox();
			this.lblPublisher = new System.Windows.Forms.Label();
			this.tbAuthor = new System.Windows.Forms.TextBox();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.tbSearchTitle = new System.Windows.Forms.TextBox();
			this.lblSearchTitle = new System.Windows.Forms.Label();
			this.btnSearchAuthor = new System.Windows.Forms.Button();
			this.btnSearchISBN = new System.Windows.Forms.Button();
			this.btnSearchTitle = new System.Windows.Forms.Button();
			this.btnSearchPublisher = new System.Windows.Forms.Button();
			this.tbSearchISBN = new System.Windows.Forms.TextBox();
			this.lblISBN = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.listBoxSearchResults = new System.Windows.Forms.ListBox();
			this.panelControls.SuspendLayout();
			this.panelContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelControls
			// 
			this.panelControls.BackColor = System.Drawing.SystemColors.Highlight;
			this.panelControls.Controls.Add(this.cbIsLoaned);
			this.panelControls.Controls.Add(this.cbIsOwned);
			this.panelControls.Controls.Add(this.tbSearchPublisher);
			this.panelControls.Controls.Add(this.lblPublisher);
			this.panelControls.Controls.Add(this.tbAuthor);
			this.panelControls.Controls.Add(this.lblAuthor);
			this.panelControls.Controls.Add(this.tbSearchTitle);
			this.panelControls.Controls.Add(this.lblSearchTitle);
			this.panelControls.Controls.Add(this.btnSearchAuthor);
			this.panelControls.Controls.Add(this.btnSearchISBN);
			this.panelControls.Controls.Add(this.btnSearchTitle);
			this.panelControls.Controls.Add(this.btnSearchPublisher);
			this.panelControls.Controls.Add(this.tbSearchISBN);
			this.panelControls.Controls.Add(this.lblISBN);
			this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControls.Location = new System.Drawing.Point(0, 0);
			this.panelControls.Name = "panelControls";
			this.panelControls.Size = new System.Drawing.Size(908, 77);
			this.panelControls.TabIndex = 0;
			// 
			// cbIsLoaned
			// 
			this.cbIsLoaned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbIsLoaned.Location = new System.Drawing.Point(484, 42);
			this.cbIsLoaned.Name = "cbIsLoaned";
			this.cbIsLoaned.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbIsLoaned.Size = new System.Drawing.Size(89, 24);
			this.cbIsLoaned.TabIndex = 14;
			this.cbIsLoaned.Text = "Loaned:";
			this.cbIsLoaned.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbIsLoaned.UseVisualStyleBackColor = true;
			// 
			// cbIsOwned
			// 
			this.cbIsOwned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbIsOwned.Location = new System.Drawing.Point(484, 10);
			this.cbIsOwned.Name = "cbIsOwned";
			this.cbIsOwned.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbIsOwned.Size = new System.Drawing.Size(89, 24);
			this.cbIsOwned.TabIndex = 13;
			this.cbIsOwned.Text = "Owned:";
			this.cbIsOwned.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbIsOwned.UseVisualStyleBackColor = true;
			// 
			// tbSearchPublisher
			// 
			this.tbSearchPublisher.Location = new System.Drawing.Point(310, 39);
			this.tbSearchPublisher.Name = "tbSearchPublisher";
			this.tbSearchPublisher.Size = new System.Drawing.Size(149, 26);
			this.tbSearchPublisher.TabIndex = 12;
			// 
			// lblPublisher
			// 
			this.lblPublisher.BackColor = System.Drawing.Color.Transparent;
			this.lblPublisher.Location = new System.Drawing.Point(223, 42);
			this.lblPublisher.Name = "lblPublisher";
			this.lblPublisher.Size = new System.Drawing.Size(81, 23);
			this.lblPublisher.TabIndex = 11;
			this.lblPublisher.Text = "Publisher:";
			this.lblPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbAuthor
			// 
			this.tbAuthor.Location = new System.Drawing.Point(310, 7);
			this.tbAuthor.Name = "tbAuthor";
			this.tbAuthor.Size = new System.Drawing.Size(149, 26);
			this.tbAuthor.TabIndex = 10;
			// 
			// lblAuthor
			// 
			this.lblAuthor.Location = new System.Drawing.Point(231, 10);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(73, 23);
			this.lblAuthor.TabIndex = 9;
			this.lblAuthor.Text = "Author:";
			this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbSearchTitle
			// 
			this.tbSearchTitle.Location = new System.Drawing.Point(74, 40);
			this.tbSearchTitle.Name = "tbSearchTitle";
			this.tbSearchTitle.Size = new System.Drawing.Size(149, 26);
			this.tbSearchTitle.TabIndex = 8;
			// 
			// lblSearchTitle
			// 
			this.lblSearchTitle.Location = new System.Drawing.Point(12, 41);
			this.lblSearchTitle.Name = "lblSearchTitle";
			this.lblSearchTitle.Size = new System.Drawing.Size(56, 23);
			this.lblSearchTitle.TabIndex = 7;
			this.lblSearchTitle.Text = "Title:";
			this.lblSearchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSearchAuthor
			// 
			this.btnSearchAuthor.Location = new System.Drawing.Point(752, 3);
			this.btnSearchAuthor.Name = "btnSearchAuthor";
			this.btnSearchAuthor.Size = new System.Drawing.Size(144, 33);
			this.btnSearchAuthor.TabIndex = 6;
			this.btnSearchAuthor.Text = "Search Author";
			this.btnSearchAuthor.UseVisualStyleBackColor = true;
			// 
			// btnSearchISBN
			// 
			this.btnSearchISBN.Location = new System.Drawing.Point(602, 3);
			this.btnSearchISBN.Name = "btnSearchISBN";
			this.btnSearchISBN.Size = new System.Drawing.Size(144, 33);
			this.btnSearchISBN.TabIndex = 5;
			this.btnSearchISBN.Text = "Search ISBN";
			this.btnSearchISBN.UseVisualStyleBackColor = true;
			// 
			// btnSearchTitle
			// 
			this.btnSearchTitle.Location = new System.Drawing.Point(602, 38);
			this.btnSearchTitle.Name = "btnSearchTitle";
			this.btnSearchTitle.Size = new System.Drawing.Size(144, 33);
			this.btnSearchTitle.TabIndex = 4;
			this.btnSearchTitle.Text = "Search Title";
			this.btnSearchTitle.UseVisualStyleBackColor = true;
			// 
			// btnSearchPublisher
			// 
			this.btnSearchPublisher.Location = new System.Drawing.Point(752, 38);
			this.btnSearchPublisher.Name = "btnSearchPublisher";
			this.btnSearchPublisher.Size = new System.Drawing.Size(144, 33);
			this.btnSearchPublisher.TabIndex = 3;
			this.btnSearchPublisher.Text = "Search Publisher";
			this.btnSearchPublisher.UseVisualStyleBackColor = true;
			// 
			// tbSearchISBN
			// 
			this.tbSearchISBN.Location = new System.Drawing.Point(74, 6);
			this.tbSearchISBN.Name = "tbSearchISBN";
			this.tbSearchISBN.Size = new System.Drawing.Size(149, 26);
			this.tbSearchISBN.TabIndex = 1;
			// 
			// lblISBN
			// 
			this.lblISBN.Location = new System.Drawing.Point(12, 9);
			this.lblISBN.Name = "lblISBN";
			this.lblISBN.Size = new System.Drawing.Size(56, 23);
			this.lblISBN.TabIndex = 0;
			this.lblISBN.Text = "ISBN:";
			this.lblISBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.listBoxSearchResults);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 77);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(908, 481);
			this.panelContent.TabIndex = 1;
			// 
			// listBoxSearchResults
			// 
			this.listBoxSearchResults.FormattingEnabled = true;
			this.listBoxSearchResults.ItemHeight = 20;
			this.listBoxSearchResults.Location = new System.Drawing.Point(14, 10);
			this.listBoxSearchResults.Name = "listBoxSearchResults";
			this.listBoxSearchResults.Size = new System.Drawing.Size(882, 464);
			this.listBoxSearchResults.TabIndex = 0;
			// 
			// SearchBookForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(908, 558);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelControls);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "SearchBookForm";
			this.Text = "SearchBookForm";
			this.panelControls.ResumeLayout(false);
			this.panelControls.PerformLayout();
			this.panelContent.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.ListBox listBoxSearchResults;

		private System.Windows.Forms.CheckBox cbIsLoaned;

		private System.Windows.Forms.CheckBox cbIsOwned;

		private System.Windows.Forms.TextBox tbSearchPublisher;
		private System.Windows.Forms.Label lblPublisher;
		private System.Windows.Forms.TextBox tbAuthor;
		private System.Windows.Forms.Label lblAuthor;

		private System.Windows.Forms.TextBox tbSearchTitle;
		private System.Windows.Forms.Label lblSearchTitle;

		private System.Windows.Forms.Label lblISBN;
		private System.Windows.Forms.TextBox tbSearchISBN;
		private System.Windows.Forms.Button btnSearchTitle;
		private System.Windows.Forms.Button btnSearchPublisher;
		private System.Windows.Forms.Button btnSearchISBN;
		private System.Windows.Forms.Button btnSearchAuthor;

		private System.Windows.Forms.Panel panelContent;

		private System.Windows.Forms.Panel panelControls;

		#endregion
	}
}