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

namespace LibraryManager.Views.Collections.GenericCollections
{
    public partial class GenericCollectionForm : Form
    {
        private readonly Panel _parentPanel;
        private readonly IFormService _formService;
        private readonly ICollectionService _collectionService;
        private readonly IBookService _bookService;

        public GenericCollectionForm(IFormService formService, ICollectionService collectionService, IBookService bookService, Panel parentPanel)
        {
            _formService = formService;
            _collectionService = collectionService;
            _bookService = bookService;
            _parentPanel = parentPanel;
            InitializeComponent();

            SetupCollectionComboBox();
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

        private async void SetupCollectionComboBox()
        {
            var collections = await _collectionService.GetAllCollectionsAsync();

            if (collections is {Data: not null} && collections.Data.Any())
            {
                cbCollections.DataSource = collections.Data;
                cbCollections.DisplayMember = "Name";
            }
        }

        private async void cbCollections_SelectedIndexChanged(object sender, EventArgs e)
        {
            var collection = (Collection)cbCollections.SelectedItem;

            if (collection.Books.Count > 0)
            {
                listWishListResults.DisplayMember = "Title";
                listWishListResults.DataSource = collection.Books.ToList();
            }
            else
            {
                MessageBox.Show($"No books found in the collection {collection.Name}.");
            }
        }
    }
}
