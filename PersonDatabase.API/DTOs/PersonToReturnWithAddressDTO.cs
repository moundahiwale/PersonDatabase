using System.Collections.Generic;

namespace PersonDatabase.API.DTOs
{
    public class PersonToReturnWithAddressDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<AddressToReturnDTO> Addresses { get; set; }
    }
}