using PawrkingSample.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawrkingSample
{
    class Database
    {
        readonly SQLiteAsyncConnection _DB;
        public Database(String dbpath)
        {
            _DB = new SQLiteAsyncConnection(dbpath);
            _DB.CreateTableAsync<ParkingLot>().Wait();
        }
    }
}
