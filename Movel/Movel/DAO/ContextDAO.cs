using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.Model;
using SQLite;
using Xamarin.Forms;

namespace Movel.DAO
{
    internal class ContextDAO
    {
        internal SQLiteConnection database;

        internal ContextDAO()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Config>();
            database.CreateTable<Parceiro>();
            
        }
    }
}
