namespace CloudTemple.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}