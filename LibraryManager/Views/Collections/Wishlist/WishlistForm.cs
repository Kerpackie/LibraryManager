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
using LibraryManager.Core.Services.CollectionService;
using LibraryManager.Services.FormService;
using LibraryManager.Views.BookForms.UpdateBook;

namespace LibraryManager.Views.Collections.Wishlist
{
    public partial class WishlistForm : Form
    {
        private readonly ICollectionService _collectionService;
        private readonly IFormService _formService;
        private readonly IBookService _bookService;
        private readonly Panel _parentPanel;

        public WishlistForm(ICollectionService collectionService, IFormService formService, IBookService bookService, Panel parentPanel)
        {
            _collectionService = collectionService;
            _formService = formService;
            _parentPanel = parentPanel;
            _bookService = bookService;
            InitializeComponent();
            SetupListboxAsync();
        }

        private async void SetupListboxAsync()
        {
            var x = await _collectionService.GetCollectionAsync(1);

            if (x is { Data.Books: not null } && x.Data.Books.Any())
            {
                listWishListResults.DisplayMember = "Title";
                listWishListResults.DataSource = x.Data.Books.ToList();
            }
            else
            {
                MessageBox.Show("No books found in the wish list.");
            }
        }

        private void listWishListResults_DoubleClick(object sender, EventArgs e)
        {
            if (listWishListResults.SelectedItem is not null)
            {
                var selected = listWishListResults.SelectedItem as Book;


                _formService.OpenChildFormWithArgument<UpdateBookForm, Book>(_parentPanel, selected);

                Close();
            }
        }
    }
}
