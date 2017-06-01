using goo.Driver.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace goo.Driver.Models
{
    
    public  class Car
    {
        [Key]
        [ForeignKey("Driver")]
        public string Id { get; set; }
        [Required]
        public long Licence { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public Driver Driver { get; set; }

    }
}
