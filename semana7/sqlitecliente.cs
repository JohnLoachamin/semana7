using semana7;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(sqlitecliente))]

namespace semana7
{
    class sqlitecliente : db
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //throw new NotImplementedException();
            var pathDocument = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(pathDocument, "semana7.db3");
            return new SQLiteAsyncConnection(path);

        }
    }
}
