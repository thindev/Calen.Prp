using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using System.IO;
using SQLite.Net.Interop;
using SQLite.Net.Platform;
using System.Threading.Tasks;

namespace Calen.Prp.Dal
{

    public class DataAccessor
    {
        static DataAccessor _instance = new DataAccessor();
        SQLiteConnection dataBase;
        public SQLiteConnection DataBase
        {
            get { return dataBase; }
        }
        private  DataAccessor()
        {
            this.InitAsync();
        }
        public static DataAccessor Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }
        public  void InitAsync()
        {
           // await Task.Run(new Action(() =>
            {
                string dataPath = AppDomain.CurrentDomain.BaseDirectory + @"\Data";
                if (!Directory.Exists(dataPath))
                {
                    Directory.CreateDirectory(dataPath);
                }
                string dbPath = dataPath + "\\db.db3";
                dataBase = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), dbPath);
                this.CreateTables();
        }
          //  ));
        }

        public void CreateTables()
        {
            dataBase.CreateTable<Tables.Goal>();
            dataBase.CreateTable<Tables.Activity>();
        }
    }
}
