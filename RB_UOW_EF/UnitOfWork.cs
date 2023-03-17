using Microsoft.EntityFrameworkCore.Metadata;
using RB_UOW_Core;
using RB_UOW_Core.Interfaces;
using RB_UOW_Core.Models;
using RB_UOW_EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB_UOW_EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Author> Authors { get; private set; }
        public IBooksRepository Books { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Authors = new BaseRepository<Author>(_context);
            Books = new BooksRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
