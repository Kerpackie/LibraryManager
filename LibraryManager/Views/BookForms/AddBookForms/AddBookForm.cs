using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.AuthorService;
using LibraryManager.Core.Services.BookService;
using LibraryManager.Core.Services.CollectionService;
using LibraryManager.Core.Services.PublisherService;
using LibraryManager.Core.Services.SubjectService;
using static System.Int32;

namespace LibraryManager.Views.BookForms.AddBookForms
{
    public partial class AddBookForm : Form
    {
        private Book _book = new();
        private BindingList<Subject> _subjects = new();
        private BindingList<Subject> _bookSubjects = new();
        private BindingList<Collection> _collections = new();
        private BindingList<Collection> _bookCollections = new();
        private List<Author> _authors = new();
        private List<Publisher> _publishers = new();

        private readonly ISubjectService _subjectService;
        private readonly IPublisherService _publisherService;
        private readonly ICollectionService _collectionService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AddBookForm(ISubjectService subjectService, IPublisherService publisherService, ICollectionService collectionService, IAuthorService authorService, IBookService bookService)
        {
            _subjectService = subjectService;
            _publisherService = publisherService;
            _collectionService = collectionService;
            _authorService = authorService;
            _bookService = bookService;

            InitializeComponent();

            DisableNoteControls();

            Load += AddBookForm_Load;
        }

        private void DisableNoteControls()
        {
            tbNoteTitle.Enabled = false;
            btnSaveNote.Enabled = false;
            btnRemoveNote.Enabled = false;
            richTextBox1.Enabled = false;
        }

        private async void AddBookForm_Load(object? sender, EventArgs e)
        {
            // Load all subjects
            var subjects = await _subjectService.GetAllSubjectsAsync();
            if (subjects.Success)
            {
                _subjects = new BindingList<Subject>(subjects.Data);
                listBoxAllSubjects.DataSource = _subjects;
                listBoxAllSubjects.DisplayMember = "Name";
            }

            _bookSubjects = new BindingList<Subject>(_book.Subjects.ToList());
            listBoxBookSubjects.DataSource = _bookSubjects;
            listBoxBookSubjects.DisplayMember = "Name";

            // Load all collections
            var collections = await _collectionService.GetAllCollectionsAsync();
            if (collections.Success)
            {
                _collections = new BindingList<Collection>(collections.Data);
                listBoxAllCollections.DataSource = _collections;
                listBoxAllCollections.DisplayMember = "Name";
            }
            _bookCollections = new BindingList<Collection>(_book.Collections.ToList());
            listBoxBookCollections.DataSource = _bookCollections;
            listBoxBookCollections.DisplayMember = "Name";

            // Load all publishers

            var publishers = await _publisherService.GetAllPublishersAsync();
            if (publishers.Success && publishers.Data.Any())
            {
                comboBoxPublisher.DataSource = publishers.Data;
                comboBoxPublisher.DisplayMember = "Name";
                comboBoxPublisher.SelectedIndex = 0; // Set the first item as the default selected item

                // Bind the updated value to _book.Publisher
                comboBoxPublisher.SelectedValueChanged += (s, e) =>
                {
                    _book.Publisher = (Publisher)comboBoxPublisher.SelectedItem;
                };
            }
            else
            {
                MessageBox.Show(publishers.Message);
            }

            // Load all authors
            var authors = await _authorService.GetAllAuthorsAsync();
            if (authors.Success && authors.Data.Any())
            {
                comboBoxAuthor.DataSource = authors.Data;
                comboBoxAuthor.DisplayMember = "Name";
                comboBoxAuthor.SelectedIndex = 0; // Set the first item as the default selected item

                // Bind the updated value to _book.Author
                comboBoxAuthor.SelectedValueChanged += async (s, e) =>
                {
                    var auth = await _authorService.GetAuthorByNameAsync(comboBoxAuthor.Text);
                    _book.Author = auth.Data;
                    _book.AuthorId = auth.Data.Id;
                };
            }
            else
            {
                MessageBox.Show(authors.Message);
            }
        }


        private void btnAddSubjectToBook_Click(object sender, EventArgs e)
        {
            // Get the selected subject from the listBox
            var selectedSubject = (Subject)listBoxAllSubjects.SelectedItem;

            if (selectedSubject is null) return;

            // Check if the subject is already in the book
            if (_book.Subjects.Contains(selectedSubject))
            {
                MessageBox.Show("This subject is already in the book.");
                return;
            }

            // Add the subject to the book
            _book.Subjects.Add(selectedSubject);
            _subjects.Remove(selectedSubject);
            _bookSubjects.Add(selectedSubject);
        }

        private void btnRemoveSubjectFromBook_Click(object sender, EventArgs e)
        {
            // Get the selected subject from the listBox
            var selectedSubject = (Subject)listBoxBookSubjects.SelectedItem;

            if (selectedSubject is null) return;

            // Remove the subject from the book
            _book.Subjects.Remove(selectedSubject);
            _subjects.Add(selectedSubject);
            _bookSubjects.Remove(selectedSubject);
        }

        private void btnAddCollectionToBook_Click(object sender, EventArgs e)
        {
            var selectedCollection = (Collection)listBoxAllCollections.SelectedItem;

            if (selectedCollection is null) return;

            if (_book.Collections.Contains(selectedCollection))
            {
                MessageBox.Show("This collection is already in the book.");
                return;
            }

            _book.Collections.Add(selectedCollection);
            _collections.Remove(selectedCollection);
            _bookCollections.Add(selectedCollection);
        }

        private void btnRemoveCollectionFromBook_Click(object sender, EventArgs e)
        {
            var selectedCollection = (Collection)listBoxBookCollections.SelectedItem;

            if (selectedCollection is null) return;

            _book.Collections.Remove(selectedCollection);
            _collections.Add(selectedCollection);
            _bookCollections.Remove(selectedCollection);
        }

        private async void btnUpdateBook_Click(object sender, EventArgs e)
        {
            var publisher = (Publisher)comboBoxPublisher.SelectedItem;
            var author = (Author)comboBoxAuthor.SelectedItem;
            
            _book.Title = tbTitle.Text;
            _book.Isbn = tbISBN.Text;
            _book.PublisherId = publisher.Id;
            _book.AuthorId = author.Id;
            _book.PageCount = TryParse(tbPageCount.Text, out var pageCount) ? pageCount : 0;
            _book.PagesRead = TryParse(tbPagesRead.Text, out var pagesRead) ? pagesRead : 0;
            _book.Owned = cbOwned.Checked;
            _book.Loaned = cbOnLoan.Checked;
            _book.CoverId = 1;

            await _bookService.InsertOrIgnoreBookAsync(_book);
            DialogResult = DialogResult.OK;
            MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Close();
        }

    }
}
