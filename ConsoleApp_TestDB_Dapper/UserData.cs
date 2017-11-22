using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_TestDB_Dapper
{
    class UserData
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Birth { get; set; }
    }
}
