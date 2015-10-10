namespace CloudTemple.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [StringLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}