using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManager.Services.FormService;
using LibraryManager.Views.BookForms.AddBookForms;

namespace LibraryManager.Views
{
    public partial class MainForm : Form
    {
        private readonly IFormService _formService;

        public MainForm(IFormService formService)
        {
            _formService = formService;
            InitializeComponent();
        }

        private void btnImportBook_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelContent.Controls)
            {
                if (control is Form form)
                {
                    form.Dispose();
                }
            }

            _formService.OpenChildForm<AddBookForm>(panelContent);
            /*_formService.OpenChildFormWithArgument<AddBookForm, string>(panelContent, "Import");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelContent.Controls)
            {
                if (control is Form form)
                {
                    form.Dispose();
                }
            }

            /*_formService.OpenChildFormWithParentPanelAndArguments<ViewBookForm>(panelContent);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelContent.Controls)
            {
                if (control is Form form)
                {
                    form.Dispose();
                }
            }

            _formService.OpenChildFormWithArgument<AddBookForm, string>(panelContent, "Manual");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelContent.Controls)
            {
                if (control is Form form)
                {
                    form.Dispose();
                }
            }

            /*_formService.OpenChildFormWithParentPanelAndArguments<SearchBookForm>(panelContent);*/
        }
    }
}
