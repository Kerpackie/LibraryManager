namespace LibraryManager.Views.Collections.GenericCollections
{
    partial class GenericCollectionForm
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
            components = new System.ComponentModel.Container();
            panelControls = new Panel();
            cbCollections = new ComboBox();
            collectionMappingBindingSource = new BindingSource(components);
            label1 = new Label();
            panelContent = new Panel();
            listWishListResults = new ListBox();
            panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)collectionMappingBindingSource).BeginInit();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelControls
            // 
            panelControls.BackColor = SystemColors.Highlight;
            panelControls.Controls.Add(cbCollections);
            panelControls.Controls.Add(label1);
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(0, 0);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(908, 77);
            panelControls.TabIndex = 0;
            // 
            // cbCollections
            // 
            cbCollections.FormattingEnabled = true;
            cbCollections.Location = new Point(102, 28);
            cbCollections.Name = "cbCollections";
            cbCollections.Size = new Size(191, 28);
            cbCollections.TabIndex = 1;
            cbCollections.SelectedIndexChanged += cbCollections_SelectedIndexChanged;
            // 
            // collectionMappingBindingSource
            // 
            collectionMappingBindingSource.DataSource = typeof(Core.Data.EntityMapping.CollectionMapping);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 31);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Collection:";
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
            // GenericCollectionForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(908, 558);
            Controls.Add(panelContent);
            Controls.Add(panelControls);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "GenericCollectionForm";
            Text = "SearchBookForm";
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)collectionMappingBindingSource).EndInit();
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        private ListBox listWishListResults;



        private Panel panelContent;

        private Panel panelControls;
        #endregion

        private ComboBox cbCollections;
        private Label label1;
        private BindingSource collectionMappingBindingSource;
    }
}