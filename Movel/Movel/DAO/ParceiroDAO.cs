using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.Model;

namespace Movel.DAO
{
    public class ParceiroDAO
    {
        public static bool InsertConfig(Parceiro c)
        {
            try
            {
                var context = new ContextDAO();
                    context.database.DeleteAll<Parceiro>();
                    return context.database.Insert(c) > 0;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static Parceiro Get()
        {
            try
            {
                var context = new ContextDAO();
                var retorno = context.database.Table<Parceiro>().FirstOrDefault();
                return retorno;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
