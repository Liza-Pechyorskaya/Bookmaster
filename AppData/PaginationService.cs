using Bookmaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmaster.AppData
{
    public class PaginationService
    {
        private const int PAGE_SIZE = 50;
        private readonly List<Book> _books;
        private int _currentPageIndex = 0;
        private int _currentPageNumber = 1;
        public int BooksCount => _books.Count;
        public int TotalPages => BooksCount/PAGE_SIZE + 1; 
        public IEnumerable<Book> CurrentPageOfBooks => _books.Skip(_currentPageIndex*PAGE_SIZE).Take(PAGE_SIZE);

        public PaginationService(List<Book> books)
        {
            _books = books;
        }

        public IEnumerable<Book> NextPage()
        {
            _currentPageIndex++;

            return CurrentPageOfBooks;
        }

        public IEnumerable<Book> PreviousPage()
        {
            _currentPageIndex--;

            return CurrentPageOfBooks;
        }

        public IEnumerable<Book> SetCurrentPage(int pageNumber)
        {
            _currentPageNumber = pageNumber;

            return CurrentPageOfBooks;
        }
    }
}
