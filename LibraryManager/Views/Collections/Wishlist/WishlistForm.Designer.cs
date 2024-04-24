namespace LibraryManager.Views.Collections.Wishlist
{
    partial class WishlistForm
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
            listWishListResults = new ListBox();
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
            // panelContent
            // 
            panelContent.Controls.Add(listWishListResults);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 77);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(908, 481);
            panelContent.TabIndex = 1;
            // 
            // listWishListResults
            // 
            listWishListResults.FormattingEnabled = true;
            listWishListResults.ItemHeight = 20;
            listWishListResults.Location = new Point(14, 6);
            listWishListResults.Name = "listWishListResults";
            listWishListResults.Size = new Size(882, 444);
            listWishListResults.TabIndex = 0;
            listWishListResults.DoubleClick += listWishListResults_DoubleClick;
            // 
            // WishlistForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(908, 558);
            Controls.Add(panelContent);
            Controls.Add(panelControls);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "WishlistForm";
            Text = "SearchBookForm";
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        private ListBox listWishListResults;



        private Panel panelContent;

        private Panel panelControls;

        #endregion
    }
}