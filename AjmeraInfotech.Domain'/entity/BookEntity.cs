using AjmeraInfotech.Common;
using AjmeraInfotech.Domain.interfaces.entity;
using AjmeraInfotech.Domain.interfaces.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraInfotech.Domain.entity
{
    public class BookEntity: IBookEntity
    {
        private IBookRepo _bookRepo;
        public BookEntity(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public bool SaveBook(Book book)
        {
            return _bookRepo.SaveBook(book);
        }
        public Book GetBookById(Guid id)
        {
            return _bookRepo.GetBookById(id);
        }
        public List<Book> GetBooks()
        {
            return _bookRepo.GetBooks();
        }
        public bool Update(Book book)
        {
            return _bookRepo.Update(book);
        }
        public bool Delete(Guid Id)
        {
            return _bookRepo.Delete(Id);
        }
    }
}
