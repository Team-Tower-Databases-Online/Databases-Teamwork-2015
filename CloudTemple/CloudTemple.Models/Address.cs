namespace CloudTemple.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string AddressText { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}