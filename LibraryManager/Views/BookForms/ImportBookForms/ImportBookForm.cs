using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.BookAPIService;
using LibraryManager.Core.Services.BookService;

namespace LibraryManager.Views.BookForms.ImportBookForms
{
    public partial class ImportBookForm : Form
    {
        private readonly IBookService _bookService;

        public ImportBookForm(IBookService bookService)
        {
            _bookService = bookService;

            InitializeComponent();

            panelBody.Enabled = false;
        }

        private async void btnImportBook_Click(object sender, EventArgs e)
        {
            var apiResponse = await _bookService.LoadBookFromApiWithIsbnAsync(tbISBNSearch.Text);

            MessageBox.Show(apiResponse.Success ? "Book imported successfully" : "Book not found");

            if (apiResponse.Success)
            {
                LoadBookToForm(apiResponse.Data);
            }
        }

        private void LoadBookToForm(Book book)
        {
            tbISBN.Text = book.Isbn;
            tbTitle.Text = book.Title;
            tbPageCount.Text = book.PageCount.ToString();
            comboBoxAuthor.Text = book.Author.Name;
            comboBoxPublisher.Text = book.Publisher.Name;
            tbPagesRead.Text = book.PagesRead.ToString();
            lbSubjectsAllImport.DisplayMember = "Name";
            lbSubjectsAllImport.ValueMember = null;
            lbSubjectsAllImport.DataSource = book.Subjects.ToList();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Set the picture box to scale the image
            pictureBox1.ImageLocation = book.Cover.Medium; // Set the image to the cover URL
        }
    }
}
