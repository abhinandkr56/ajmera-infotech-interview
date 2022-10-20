using AjmeraInfotech.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraInfotech.Domain.interfaces.repo
{
    public interface IBookRepo
    {
        bool SaveBook(Book book);
        Book GetBookById(Guid id);
        List<Book> GetBooks();
        bool Update(Book book);
        bool Delete(Guid Id);
    }
}
