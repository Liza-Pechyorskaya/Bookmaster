using Bookmaster.AppData;
using Bookmaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalog.xaml
    /// </summary>
    public partial class BrowseCatalog : Page
    {
        List<Book> _books = App.context.Book.ToList();

        PaginationService _booksPagination;

        public BrowseCatalog()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchResultsGrid.Visibility = Visibility.Visible;

            string bookTitle = SearchByBookTitleTb.Text;
            string authorName = SearchByAuthorNameTb.Text;
            string bookSubjects = SearchByBookSubjectsTb.Text;

            if(string.IsNullOrEmpty(bookTitle) && string.IsNullOrEmpty(authorName) && string.IsNullOrEmpty(bookSubjects))
            {
                _booksPagination = new PaginationService(_books);
            }
            else
            {
                List<Book> booksSearchResult = _books.Where(b => b.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) && b.Authors.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower())).ToList();

                _booksPagination = new PaginationService(booksSearchResult);
            }

            BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfBooks;
            TotalPagesTbl.DataContext = TotalBooksTbl.DataContext = _booksPagination;
        }

        private void PreviousBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.PreviousPage();
        }

        private void CurrentPageTb_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void NextBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.NextPage();
        }
    }
}
