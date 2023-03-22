using System.ComponentModel.DataAnnotations;

namespace learnApi.Models.Dto
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nmae { get; set; }
    }
}
