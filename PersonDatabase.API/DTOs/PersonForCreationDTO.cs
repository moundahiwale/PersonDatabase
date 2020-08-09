using System.ComponentModel.DataAnnotations;

namespace PersonDatabase.API.DTOs
{
    public class PersonForCreationDTO
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}