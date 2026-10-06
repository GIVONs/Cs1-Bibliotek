using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Models
{
    public class Person
    {
        string Name { get; set; }
        string Email { get; set; }

        public Person(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}
