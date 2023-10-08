using Path.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.Repositori.Interface
{
    public interface ISaleRepositorie : IGenericRepositorie<Sale>
    {
        Task<Sale> RegisterSale(Sale model);
    }
}
