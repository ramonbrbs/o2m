using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movel.DAO
{
    public class CrudDAO<T> where T : class, new()
    {
        public static void Inserir(T conf)
        {
            try
            {
                var context = new ContextDAO();
                context.database.Insert(conf);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Alterar(T conf)
        {
            try
            {
                var context = new ContextDAO();
                context.database.Update(conf);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static T Obter()
        {
            try
            {
                var context = new ContextDAO();
                return context.database.Table<T>().FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
