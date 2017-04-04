using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAO.Contexts;
using DAO.Repositories;
using Model.Entities;

namespace Business
{
    public class PaginacaoRN<TEntity> where TEntity : class
    {

        public Paginacao<TEntity> GetPaginacao(int currentPAge , Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int pageSize = 20, string include="")
        {
            try
            {
                if (currentPAge > 0)
                {
                    currentPAge--;
                }
                var retorno = new Paginacao<TEntity>();
                var repo = new GenericRepository<TEntity>(new DB());
                retorno.QtdPags = Convert.ToInt32(Math.Round(( Convert.ToDecimal(repo.Count(filter)) / pageSize) + Convert.ToDecimal(0.4999)) ) ;
                retorno.Result = repo.Get(filter, page: currentPAge, orderBy: orderBy, pagesize:pageSize, includeProperties: include);
                retorno.CurrentPage = currentPAge;
;               return retorno;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
