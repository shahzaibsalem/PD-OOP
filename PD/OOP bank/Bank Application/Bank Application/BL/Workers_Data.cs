using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application.BL
{
    public class Workers_Data
    {
        private string Name;
        private string City;
        private int Salary;
        private string Post;

        public Workers_Data(string Name,string City,int Salary,string Post)
        {
            this.Name = Name;
            this.City = City;
            this.Salary = Salary;
            this.Post = Post;
        }

        public void Set_Name(string Name)
        {
            this.Name = Name;
        }
        public void Set_City(string City)
        {
            this.City = City;
        }
        public void Set_Salary(int Salary)
        {
            this.Salary = Salary;
        }
        public void Set_Post(string Post)
        {
            this.Post = Post;
        }

        public String Get_Name()
        {
            return this.Name;
        }
        public String Get_City()
        {
            return this.City;
        }
        public int Get_Salary()
        {
            return this.Salary;
        }
        public String Get_Post()
        {
            return this.Post;
        }
    }
}
