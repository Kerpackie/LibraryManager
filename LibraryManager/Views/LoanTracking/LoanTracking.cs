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
using LibraryManager.Core.Services.LoanService;

namespace LibraryManager.Views.LoanTracking
{
    public partial class LoanTracking : Form
    {
        private Loan _loan = new();
        private BindingList<Loan> _loans = new();

        private BindingList<Book> _allBooks = new();
        private BindingList<Book> _booksOnLoan = new();

        private readonly ILoanService _loanService;
        private readonly IBookService _bookService;

        private LoanState _loanState = LoanState.NewLoan;

        private enum LoanState
        {
            LoanSelected,
            NewLoan
        }

        public LoanTracking(ILoanService loanService, IBookService bookService)
        {
            _loanService = loanService;
            _bookService = bookService;
            InitializeComponent();

            Load += PrepareForm;

            LoanSelected();

        }

        private async void PrepareForm(object? sender, EventArgs e)
        {
            var allLoans = await _loanService.GetAllLoansAsync();

            if (allLoans.Success)
            {
                _loans = new BindingList<Loan>(allLoans.Data.Where(loan => loan.IsReturned == false).ToList());
                listBoxLoans.DataSource = _loans;
                listBoxLoans.DisplayMember = "Borrower";
            }


            var allBooks = await _bookService.GetAllBooksAsync();

            if (allBooks.Success)
            {
                var notLoaned = allBooks.Data
                    .Where(b => b.Loaned == false)
                    .ToList();

                _allBooks = new BindingList<Book>(notLoaned);
                listBoxAllBooks.DataSource = _allBooks;
                listBoxAllBooks.DisplayMember = "Title";
            }

            _booksOnLoan = new BindingList<Book>(_loan.Books.ToList());
            listBoxBooksInLoan.DataSource = _booksOnLoan;
            listBoxBooksInLoan.DisplayMember = "Title";


        }

        private async void listBoxLoans_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoanSelected();

            _loan = (Loan)listBoxLoans.SelectedItem;



            if (_loan != null)
            {
                
                tbBorrower.Text = _loan.Borrower;
                dtpReturnDate.Value = _loan.LoanDate;
                listBoxBooksInLoan.DataSource = new BindingList<Book>(_loan.Books.ToList());

                var allBooks = await _bookService.GetAllBooksAsync();

                listBoxAllBooks.DataSource =
                    new BindingList<Book>(allBooks.Data.Where(b => b.Loaned == false).ToList());
            }
            else
            {
                _loan = new Loan();
                tbBorrower.Text = "";
                dtpReturnDate.Value = DateTime.Now.AddMonths(1);
                listBoxBooksInLoan.DataSource = new BindingList<Book>();

                var allBooks = await _bookService.GetAllBooksAsync();

                listBoxAllBooks.DataSource =
                    new BindingList<Book>(allBooks.Data.Where(b => b.Loaned == false).ToList());
            }
        }

        private async void btnUpdateLoan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBorrower.Text))
            {
                MessageBox.Show("Text cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _loan.LoanDate = DateTime.Now;
            _loan.ReturnDate = dtpReturnDate.Value;
            _loan.Borrower = tbBorrower.Text;
            _loan.Books = _booksOnLoan.ToList();
            _loan.IsReturned = false;

            var result = await _loanService.UpdateLoanAsync(_loan);

            if (result.Success)
            {
                MessageBox.Show("Loan updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Loan update failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnReturnLoan_Click(object sender, EventArgs e)
        {
            _loan = (Loan)listBoxLoans.SelectedItem;

            _loan.ReturnDate = DateTime.Now;
            _loan.IsReturned = true;



            var result = await _loanService.ReturnLoanAsync(_loan.Id);

            if (result.Success)
            {
                MessageBox.Show("Loan returned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _loans.Remove(_loan);
            }
            else
            {
                MessageBox.Show($"Loan return failed: {result.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoanSelected()
        {
            _loanState = LoanState.LoanSelected;

            btnUpdateLoan.Enabled = true;
            btnReturnLoan.Enabled = true;
        }

        private void NewLoan()
        {
            _loanState = LoanState.NewLoan;

            btnUpdateLoan.Enabled = false;
            btnReturnLoan.Enabled = false;
        }

        private async void btnCreateLoan_Click(object sender, EventArgs e)
        {
            switch (_loanState)
            {
                case LoanState.LoanSelected:
                    HandleNewLoan_LoanSelected();
                    break;
                case LoanState.NewLoan:
                    await HandleNewLoan_NewLoanSelected();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void HandleNewLoan_LoanSelected()
        {
            NewLoan();

            _loan = new Loan();
            tbBorrower.Text = "";
            dtpReturnDate.Value = DateTime.Now.AddMonths(1);
            _loan.Books = new BindingList<Book>();

        }

        private async Task HandleNewLoan_NewLoanSelected()
        {
            if (string.IsNullOrEmpty(tbBorrower.Text))
            {
                MessageBox.Show("Text cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _loan.LoanDate = DateTime.Now;
            _loan.ReturnDate = dtpReturnDate.Value;
            _loan.Borrower = tbBorrower.Text;
            _loan.Books = _booksOnLoan.ToList();
            _loan.IsReturned = false;

            var result = await _loanService.CreateLoanAsync(_loan);

            if (result.Success)
            {
                MessageBox.Show("Loan created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Loan creation failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var selectedBook = (Book)listBoxAllBooks.SelectedItem;
            if (selectedBook is null) return;

            if (_loan.Books.Contains(selectedBook))
            {
                MessageBox.Show("This book is already in the loan.");
                return;
            }

            _loan.Books.Add(selectedBook);
            _allBooks.Remove(selectedBook);
            _booksOnLoan.Add(selectedBook);
        }

        private void btnRemoveBook_Click(object sender, EventArgs e)
        {
            var selectedBook = (Book)listBoxBooksInLoan.SelectedItem;

            if (selectedBook is null) return;

            _loan.Books.Remove(selectedBook);
            _allBooks.Add(selectedBook);
            _booksOnLoan.Remove(selectedBook);
        }

        private void listBoxBooksInLoan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
