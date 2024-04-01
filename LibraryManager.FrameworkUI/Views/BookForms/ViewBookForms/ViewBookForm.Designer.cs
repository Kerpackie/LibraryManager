using System.ComponentModel;

namespace LibraryManager.FrameworkUI.Views.BookForms.ViewBookForms
{
	partial class ViewBookForm
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
			this.SuspendLayout();
			// 
			// panelControl
			// 
			this.panelControl.Size = new System.Drawing.Size(906, 77);
			// 
			// panelBody
			// 
			this.panelBody.Size = new System.Drawing.Size(906, 490);
			// 
			// ViewBookForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(906, 567);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "ViewBookForm";
			this.Text = "ViewBookForm";
			this.ResumeLayout(false);
		}

		#endregion
	}
}