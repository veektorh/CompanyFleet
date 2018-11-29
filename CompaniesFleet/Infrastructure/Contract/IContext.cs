using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infrastructure.Contract
{
    public interface IContext : IDisposable
    {
        DbContext AppDbContext { get; }
    }
}
