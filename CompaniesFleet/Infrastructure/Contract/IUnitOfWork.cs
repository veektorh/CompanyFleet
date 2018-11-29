using Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    internal interface IUnitOfWork
    {
        void SaveChanges();
        Context Context { get; }
    }
}
