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
using LibraryManager.Core.Services.AuthorService;
using LibraryManager.Core.Services.CollectionService;
using LibraryManager.Core.Services.PublisherService;
using LibraryManager.Core.Services.SubjectService;

namespace LibraryManager.Views.BookForms.UpdateAuthorPublisherForms
{
    public partial class UpdateAuthorPublisher : Form
    {
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;
        private readonly ISubjectService _subjectService;
        private readonly ICollectionService _collectionService;


        public UpdateAuthorPublisher(IPublisherService publisherService, IAuthorService authorService, ISubjectService subjectService, ICollectionService collectionService)
        {
            _publisherService = publisherService;
            _authorService = authorService;
            _subjectService = subjectService;
            _collectionService = collectionService;
            InitializeComponent();
        }

        private async void btnAddPublisher_Click(object sender, EventArgs e)
        {

            var response = await _publisherService.InsertOrIgnorePublisherAsync(new Publisher { Name = tbSearchPublisher.Text });

            if (response.Success)
            {
                MessageBox.Show("Publisher added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddAuthor_Click(object sender, EventArgs e)
        {
            var response = await _authorService.InsertOrIgnoreAuthorAsync(new Author { Name = tbAuthor.Text });

            if (response.Success)
            {
                MessageBox.Show("Author added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddSubject_Click(object sender, EventArgs e)
        {
            var response = await _subjectService.InsertOrIgnoreSubjectAsync(new Subject { Name = tbSubject.Text });

            if (response.Success)
            {
                MessageBox.Show("Subject added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddCollection_Click(object sender, EventArgs e)
        {
            var response = await _collectionService.CreateCollectionAsync(new Collection { Name = tbCollection.Text });

            if (response.Success)
            {
                MessageBox.Show("Collection added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
