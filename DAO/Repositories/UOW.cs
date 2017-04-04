using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Contexts;

namespace DAO.Repositories
{
    public class UOW
    {
        private DB context = new DB();
        private ParceiroRepo parceiroRep;
        private IndicadoRepo indicadoRep;
        private BancoRepo bancoRep;

        public ParceiroRepo ParceiroRep
        {
            get
            {

                if (this.parceiroRep == null)
                {
                    this.parceiroRep = new ParceiroRepo(context);
                }
                return parceiroRep;
            }
        }

        public BancoRepo BancoRep
        {
            get
            {

                if (this.bancoRep == null)
                {
                    this.bancoRep = new BancoRepo(context);
                }
                return bancoRep;
            }
        }

        public IndicadoRepo IndicadoRep
        {
            get
            {

                if (this.indicadoRep == null)
                {
                    this.indicadoRep = new IndicadoRepo(context);
                }
                return indicadoRep;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
