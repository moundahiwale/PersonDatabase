using System.Collections.Generic;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Services.Communication
{
    public class AddressResponse : BaseResponse
    {
        public Address Address { get; private set; }
        public IEnumerable<Address> Addresses { get; private set; }
        private AddressResponse(bool success, string message, Address address) : base(success, message)
        {
            Address = address;
        }
        private AddressResponse(bool success, string message, IEnumerable<Address> addresses) : base(success, message)
        {
            Addresses = addresses;
        }
        public AddressResponse(Address address) : this(true, string.Empty, address)
        { }
        public AddressResponse(IEnumerable<Address> addresses) : this(true, string.Empty, addresses)
        { }
        public AddressResponse(string message) : this(false, message, (Address)null)
        { }
    }
}