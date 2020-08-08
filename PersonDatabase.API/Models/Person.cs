using System.Collections.Generic;

namespace PersonDatabase.API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Address> Addresses { get; set; } = new List<Address>();
    }
}