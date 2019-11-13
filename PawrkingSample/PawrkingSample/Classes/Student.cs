using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawrkingSample.Classes
{
    class Student
    {
        [PrimaryKey, MaxLength(9), Unique]
        public string Id { get; set; }
        public string password { get; set; }
        public Boolean isAdmin { get; set; }
    }
}
