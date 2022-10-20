using AjmeraInfotech.Common;
using AjmeraInfotech.Domain.interfaces.repo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraInfotech.Repository
{
    public class BookRepo:IBookRepo
    {
        private BookContext _bookContext=null;
        private IConfiguration _configuration = null;
        public BookRepo(IConfiguration configuration)
        {
            _configuration=configuration;
            _bookContext = new BookContext(_configuration);
        }
        public bool SaveBook(Book book)
        {
             _bookContext.Add(book);
             var a=_bookContext.SaveChanges();
            return a > 0;
        }
        public Book GetBookById(Guid id)
        {
            return _bookContext.books.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Book> GetBooks()
        {
            return _bookContext.books.ToList();
        }
        public bool Update(Book book)
        {
            var result = _bookContext.books.SingleOrDefault(b => b.Id == book.Id);
            if (result != null)
            {
                result.name = book.name;
                result.authorName = book.authorName;
                var a = _bookContext.SaveChanges();
                return a > 0;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(Guid Id)
        {
            var itemToRemove = _bookContext.books.SingleOrDefault(x => x.Id == Id);

            if (itemToRemove != null)
            {
                _bookContext.books.Remove(itemToRemove);
                var a = _bookContext.SaveChanges();
                return a > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
