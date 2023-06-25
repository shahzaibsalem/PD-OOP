using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Students
    {
        private string name;
        private string password;
        private string city;

        public Students(string name,string password,string city)
        {
            this.name = name;
            this.city = city;
            this.password = password;
        }

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string City { get => city; set => city = value; }
    }
}
