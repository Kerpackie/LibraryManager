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

namespace LibraryManager.Views.BookForms.Statistics
{
    public partial class BookStatisticsForm : Form
    {
        private readonly IBookService _bookService;
        private BindingList<Book> _books = new();

        public BookStatisticsForm(IBookService bookService)
        {
            _bookService = bookService;
            InitializeComponent();

            Load += PrepareForm;
        }

        private async void PrepareForm(object? sender, EventArgs e)
        {
            var allBooks = await _bookService.GetAllBooksAsync();

            if (allBooks.Success)
            {
                _books = new BindingList<Book>(allBooks.Data.ToList());
                listBoxBooks.DataSource = _books;
                listBoxBooks.DisplayMember = "Title";
            }

            tbTotalBooks.Text = _books.Count.ToString();

            tbTotalPagesRead.Text = _books.Sum(book => book.PagesRead).ToString();

            // Get Average Pages Read as a % of Total Pages
            var averagePagesPerBook = _books.Sum(book => book.PagesRead) / _books.Count;
            tbAveragePagesPerBook.Text = averagePagesPerBook.ToString();

            tbAveragePagesPerBook.ReadOnly = true;
            tbTotalPagesRead.ReadOnly = true;
            tbTotalBooks.ReadOnly = true;
        }

        private void listBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var book = (Book)listBoxBooks.SelectedItem;

            lblBookTitle.Text = book.Title;

            // Prevent div by 0 error.
            if (book.PageCount == 0)
            {
                book.PageCount = 1;
            }
            // Set Progress bar to show % of book read
            if (book.PageCount < book.PagesRead)
            {
                book.PagesRead = book.PageCount;
            }

            double percentageRead = ((double)book.PagesRead / book.PageCount) * 100;
            progressBar.Value = (int)Math.Round(percentageRead);
        }
    }
}
