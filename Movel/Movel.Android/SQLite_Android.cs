using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Movel.Droid;
using Movel.Model;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Movel.Droid
{

    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "db.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}