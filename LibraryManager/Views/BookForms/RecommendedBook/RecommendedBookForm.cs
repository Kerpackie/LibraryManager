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
using LibraryManager.Core.Services.SubjectService;

namespace LibraryManager.Views.BookForms.RecommendedBook
{
    public partial class RecommendedBookForm : Form
    {
        private Book _book = new();
        private readonly IBookApiService _api;
        private readonly ISubjectService _subjectService;

        public RecommendedBookForm(IBookApiService api, ISubjectService subjectService)
        {
            _api = api;
            _subjectService = subjectService;
            InitializeComponent();

            panelBody.Enabled = false;

            Load += async (sender, e) =>
            {
                await GetRandomBook();
                HandleLoad(sender, e);
            };
        }

        private async Task GetRandomBook()
        {
            var subject = await _subjectService.GetAllSubjectsAsync();

            var r = new Random();
            var randomIndex = r.Next(1, subject.Data.Count);
            var randomSubject = subject.Data[randomIndex];

            var book = await _api.GetSuggestedBookAsync<Book>(randomSubject.Name);

            if (book.Success)
            {
                _book = book.Data;
            }
        }

        private void HandleLoad(object? sender, EventArgs e)
        {
            tbISBN.Text = _book.Isbn;
            tbTitle.Text = _book.Title;
            tbPageCount.Text = _book.PageCount.ToString();
            tbPagesRead.Text = _book.PagesRead.ToString();

            comboBoxAuthor.Text = _book.Author.Name;
            comboBoxPublisher.Text = _book.Publisher.Name;

            listBoxAllSubjects.DataSource = _book.Subjects.ToList();


            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Set the picture box to scale the image
            pictureBox1.Load(!string.IsNullOrEmpty(_book.Cover.Medium)
                ? _book.Cover.Medium
                : "https://twinklelearning.in/uploads/noimage.jpg");
            {
                pictureBox1.Load(_book.Cover.Medium);
            }
        }
    }
}
