﻿using System;
using System.Linq;

namespace Mission7Final.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookContext context { get; set; }
        public EFBookRepository(BookContext _context)
        {
            context = _context;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
