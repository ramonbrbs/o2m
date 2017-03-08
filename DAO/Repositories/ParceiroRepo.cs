using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Contexts;
using Model.Entities;

namespace DAO.Repositories
{
    public class ParceiroRepo : GenericRepository<Parceiro>
    {
        public ParceiroRepo(DB context): base(context)
        {

        }

    }
}
