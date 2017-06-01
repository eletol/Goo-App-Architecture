namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class PassengerDevice
    {
        [Key]
        public string DeviceId { get; set; }

        [ForeignKey("Passenger")]
        public string PassengerId { get; set; }
        [Required]
        public string OSType { get; set; }
        public Passenger Passenger { get; set; }




    }
}
