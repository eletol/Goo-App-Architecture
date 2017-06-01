namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class DriverDevice
    {
        [Key]
        public string DeviceId { get; set; }

        [ForeignKey("Driver")]
        public string DriverId { get; set; }
        [Required]
        public string OSType { get; set; }
        public Driver Driver { get; set; }



    }
}
