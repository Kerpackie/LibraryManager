using System.ComponentModel;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.AuthorService;
using LibraryManager.Core.Services.BookService;
using LibraryManager.Core.Services.CollectionService;
using LibraryManager.Core.Services.NotesService;
using LibraryManager.Core.Services.PublisherService;
using LibraryManager.Core.Services.SubjectService;

namespace LibraryManager.Views.BookForms.UpdateBook
{
    public partial class UpdateBookForm : Form
    {
        private Book _book;

        private BindingList<Subject> _subjects = new();
        private BindingList<Subject> _bookSubjects = new();
        private BindingList<Collection> _collections = new();
        private BindingList<Collection> _bookCollections = new();
        private BindingList<Note> _notes = new();
        private List<Author> _authors = new();
        private List<Publisher> _publishers = new();

        private readonly ISubjectService _subjectService;
        private readonly IPublisherService _publisherService;
        private readonly ICollectionService _collectionService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly INoteService _noteService;

        public UpdateBookForm(Book book, ISubjectService subjectService, IPublisherService publisherService, ICollectionService collectionService, IAuthorService authorService, IBookService bookService, INoteService noteService)
        {
            _book = book;
            _subjectService = subjectService;
            _publisherService = publisherService;
            _collectionService = collectionService;
            _authorService = authorService;
            _bookService = bookService;
            _noteService = noteService;
            InitializeComponent();

            Load += HandleLoad;
            
            panelBody.Enabled = false;
        }

        private void LoadBookToForm()
        {
            tbISBN.Text = _book.Isbn;
            tbTitle.Text = _book.Title;
            tbPageCount.Text = _book.PageCount.ToString();
            tbPagesRead.Text = _book.PagesRead.ToString();

            comboBoxAuthor.Text = _book.Author.Name;
            comboBoxPublisher.Text = _book.Publisher.Name;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Set the picture box to scale the image
            pictureBox1.ImageLocation = _book.Cover.Medium; // Set the image to the cover URL
        }

        private async void HandleLoad(object? sender, EventArgs e)
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

            // Remove the book subjects from the list of all subjects
            foreach (var subject in _bookSubjects)
            {
                _subjects.Remove(subject);
            }

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

            // Remove the book collection from the list of all collections
            foreach (var collection in _bookCollections)
            {
                _collections.Remove(collection);
            }

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

            // Load all notes
            var notes = await _noteService.GetNotesForBookAsync(_book.Id);
            if (notes.Success)
            {
                _notes = new BindingList<Note>(notes.Data.ToList());
                
            }
            else
            {
                _notes = new BindingList<Note>();
            }
            
            listBoxNotes.DataSource = _notes;
            listBoxNotes.DisplayMember = "Title";


            LoadBookToForm();
        }

        private void btnAddSubjectToBook_Click(object sender, EventArgs e)
        {
            // Get the selected subject from the listBox
            var selectedSubject = (Subject)listBoxAllSubjects.SelectedItem;

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

        private async void btnRemoveCollectionFromBook_Click(object sender, EventArgs e)
        {
            var selectedCollection = (Collection)listBoxBookCollections.SelectedItem;

            if (selectedCollection == null) return;


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
            _book.PageCount = int.TryParse(tbPageCount.Text, out var pageCount) ? pageCount : 0;
            _book.PagesRead = int.TryParse(tbPagesRead.Text, out var pagesRead) ? pagesRead : 0;
            _book.Owned = cbOwned.Checked;
            _book.Loaned = cbOnLoan.Checked;

            var result = await _bookService.UpdateBookAsync(_book);

            if (result.Success)
            {
                MessageBox.Show("Book updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Close();
        }

        private void btnToggleEdit_Click(object sender, EventArgs e)
        {
            panelBody.Enabled = panelBody.Enabled switch
            {
                true => false,
                false => true
            };
        }

        private async void btnSaveNote_Click(object sender, EventArgs e)
        {
            var note = new Note
            {
                Title = tbNoteTitle.Text,
                Content = richTextBox1.Text,
                BookId = _book.Id
            };

            var result = await _noteService.InsertNoteAsync(note);

            if (result.Success)
            {
                _notes.Add(note);
                MessageBox.Show("Note saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveNote_Click(object sender, EventArgs e)
        {
            var selectedNote = (Note)listBoxNotes.SelectedItem;

            if (selectedNote == null) return;
            _notes.Remove(selectedNote);
            
            _noteService.DeleteNoteAsync(selectedNote.Id);
        }
    }
}
