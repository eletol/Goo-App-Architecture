namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Car
    {
        [Key]
        [ForeignKey("Driver")]
        public string Id { get; set; }
        [Required]
        public string Model { get; set; }
    
        [Required]
        public string Color { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public Driver Driver { get; set; }
        [Required]
        public long Licence { get; set; }

    }
}
