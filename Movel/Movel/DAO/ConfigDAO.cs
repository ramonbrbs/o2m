using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.Model;

namespace Movel.DAO
{
    public class ConfigDAO
    {
        static object locker = new object();
        public static bool InsertConfig(Config c)
        {
            try
            {
                var context = new ContextDAO();
                c.CodConfig = 1;
                if (!context.database.Table<Config>().Any())
                {
                    return context.database.Insert(c) > 0;
                }
                else
                {
                    return context.database.Update(c) > 0;
                }
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        public static bool DeleteConfig()
        {
            try
            {
                var context = new ContextDAO();
                var config = context.database.Table<Config>().FirstOrDefault();
                if (config != null)
                {
                    context.database.Delete(config);
                }
                
                return true;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        public static Config Get()
        {
            try
            {
                var context = new ContextDAO();
                var retorno = context.database.Table<Config>().FirstOrDefault();
                return retorno;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}
