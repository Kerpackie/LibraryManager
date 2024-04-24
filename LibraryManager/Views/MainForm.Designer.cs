using System.ComponentModel;

namespace LibraryManager.Views
{
    partial class MainForm
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
            panelSidebar = new Panel();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button2 = new Button();
            button1 = new Button();
            btnImportBook = new Button();
            panelContent = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(64, 64, 64);
            panelSidebar.Controls.Add(button6);
            panelSidebar.Controls.Add(button7);
            panelSidebar.Controls.Add(button8);
            panelSidebar.Controls.Add(button3);
            panelSidebar.Controls.Add(button4);
            panelSidebar.Controls.Add(button5);
            panelSidebar.Controls.Add(button2);
            panelSidebar.Controls.Add(button1);
            panelSidebar.Controls.Add(btnImportBook);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(4, 3, 4, 3);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(243, 659);
            panelSidebar.TabIndex = 0;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(64, 64, 64);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = SystemColors.ControlLight;
            button6.Location = new Point(0, 605);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(243, 51);
            button6.TabIndex = 8;
            button6.Text = "Utilities";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(64, 64, 64);
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button7.ForeColor = SystemColors.ControlLight;
            button7.Location = new Point(0, 547);
            button7.Margin = new Padding(4, 3, 4, 3);
            button7.Name = "button7";
            button7.Size = new Size(243, 51);
            button7.TabIndex = 7;
            button7.Text = "Statistics";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(64, 64, 64);
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button8.ForeColor = SystemColors.ControlLight;
            button8.Location = new Point(0, 489);
            button8.Margin = new Padding(4, 3, 4, 3);
            button8.Name = "button8";
            button8.Size = new Size(243, 51);
            button8.TabIndex = 6;
            button8.Text = "Loans";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(64, 64, 64);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ControlLight;
            button3.Location = new Point(-1, 433);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(243, 51);
            button3.TabIndex = 5;
            button3.Text = "Collections";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(64, 64, 64);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ControlLight;
            button4.Location = new Point(-1, 375);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(243, 51);
            button4.TabIndex = 4;
            button4.Text = "WishList";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(64, 64, 64);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.ControlLight;
            button5.Location = new Point(-1, 317);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(243, 51);
            button5.TabIndex = 3;
            button5.Text = "Recommended";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ControlLight;
            button2.Location = new Point(0, 260);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(243, 51);
            button2.TabIndex = 2;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlLight;
            button1.Location = new Point(0, 202);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(243, 51);
            button1.TabIndex = 1;
            button1.Text = "Add Book";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnImportBook
            // 
            btnImportBook.BackColor = Color.FromArgb(64, 64, 64);
            btnImportBook.FlatAppearance.BorderSize = 0;
            btnImportBook.FlatStyle = FlatStyle.Flat;
            btnImportBook.Font = new Font("Bell MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnImportBook.ForeColor = SystemColors.ControlLight;
            btnImportBook.Location = new Point(0, 144);
            btnImportBook.Margin = new Padding(4, 3, 4, 3);
            btnImportBook.Name = "btnImportBook";
            btnImportBook.Size = new Size(243, 51);
            btnImportBook.TabIndex = 0;
            btnImportBook.Text = "Import Book";
            btnImportBook.UseVisualStyleBackColor = false;
            btnImportBook.Click += btnImportBook_Click;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(243, 0);
            panelContent.Margin = new Padding(4, 3, 4, 3);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1063, 659);
            panelContent.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1306, 659);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = "LibraryManager";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button btnImportBook;

        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Panel panelSidebar;

        #endregion

        private Button button6;
        private Button button7;
        private Button button8;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}