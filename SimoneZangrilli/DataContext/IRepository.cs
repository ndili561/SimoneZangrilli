using SimoneZangrilli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimoneZangrilli.Context
{
    public interface IRepository
    {
        Task Add(ContactInfo info);
    }
}
