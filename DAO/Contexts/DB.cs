using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DAO.Contexts
{
    public class DB : DbContext
    {
        public DB() : base("name=STR1")
        {

        }

        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Indicado> Indicados { get; set; }
    }
}
