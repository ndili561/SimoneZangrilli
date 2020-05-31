using SimoneZangrilli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimoneZangrilli.Context
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(ContactInfo info)
        {
            _context.Add(info);
             await  _context.SaveChangesAsync();
        }
    }
}
