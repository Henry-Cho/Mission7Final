using System;
using System.Linq;

namespace Mission7Final.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
