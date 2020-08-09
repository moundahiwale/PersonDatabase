using System.ComponentModel.DataAnnotations;

namespace PersonDatabase.API.DTOs
{
    public class AddressForCreationDTO
    {
        public string Street { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}