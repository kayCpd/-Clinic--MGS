using System.ComponentModel.DataAnnotations;

namespace Clinic.API.DTOs.GPOffices
{
    public class CreateGPOfficeDTO
    {
        [Required]
        [StringLength(150)]
        public required string Name { get; set; }
    }
}
