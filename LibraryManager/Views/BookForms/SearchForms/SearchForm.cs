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
using LibraryManager.Core.Services.BookService;
using LibraryManager.Services.FormService;
using LibraryManager.Views.BookForms.UpdateBook;

namespace LibraryManager.Views.BookForms.SearchForms
{
    public partial class SearchForm : Form
    {
        private readonly IBookService _bookService;
        private readonly IFormService _formService;
        private readonly Panel _parentPanel;

        public SearchForm(IBookService bookService, IFormService formService, Panel parentPanel)
        {
            _bookService = bookService;
            _formService = formService;
            _parentPanel = parentPanel;
            InitializeComponent();

            listBoxSearchResults.DataSource = new List<string>();
            listBoxSearchResults.DisplayMember = "Title";
        }

        private async void btnSearchISBN_Click(object sender, EventArgs e)
        {
            var result = await _bookService.GetBookByIsbnAsync(tbSearchISBN.Text);

            if (result.Success)
            {
                listBoxSearchResults.DataSource = new List<string> { result.Data.Title };
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void btnSearchTitle_Click(object sender, EventArgs e)
        {
            var result = await _bookService.GetBookByTitleAsync(tbSearchTitle.Text);

            if (result.Success)
            {
                listBoxSearchResults.DataSource = new List<string> { result.Data.Title };
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            var result = await _bookService.GetBooksByAuthorAsync(tbAuthor.Text);

            if (result.Success)
            {
                listBoxSearchResults.DataSource = result.Data.Select(b => b.Title).ToList();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void btnSearchPublisher_Click(object sender, EventArgs e)
        {
            var result = await _bookService.GetBooksByPublisherAsync(tbSearchPublisher.Text);

            if (result.Success)
            {
                listBoxSearchResults.DataSource = result.Data.Select(b => b.Title).ToList();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void btnSearchOwned_Click(object sender, EventArgs e)
        {
            var result = await _bookService.GetAllBooksAsync();

            if (result.Success)
            {
                var books = result.Data
                    .Where(b => b.Owned == cbIsOwned.Checked)
                    .Select(b => b.Title)
                    .ToList();

                if (books.Count > 0)
                {
                    listBoxSearchResults.DataSource = books;
                }
                else
                {
                    MessageBox.Show("No books found.");
                }

            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void btnSearchLoaned_Click(object sender, EventArgs e)
        {
            var result = await _bookService.GetAllBooksAsync();

            if (result.Success)
            {
                var books = result.Data
                    .Where(b => b.Loaned == cbIsLoaned.Checked)
                    .Select(b => b.Title)
                    .ToList();

                if (books.Count > 0)
                {
                    listBoxSearchResults.DataSource = books;
                }
                else
                {
                    MessageBox.Show("No books found.");
                }

            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void listBoxSearchResults_DoubleClick(object? sender, EventArgs e)
        {
            if (listBoxSearchResults.SelectedItem is not null)
            {
                var book = await _bookService.GetBookByTitleAsync(listBoxSearchResults.SelectedItem.ToString());

                _formService.OpenChildFormWithArgument<UpdateBookForm, Book>(_parentPanel, book.Data); // Modify this line

                Close();
            }
        }
    }
}
