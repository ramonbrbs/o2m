using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Contexts;
using Model.Entities;

namespace DAO.Repositories
{
    public class IndicadoRepo: GenericRepository<Indicado>
    {
        public IndicadoRepo(DB context): base(context)
        {

        }
    }
}
