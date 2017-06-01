using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.DataSeed
{
   
   
   
    public static class PaymentMethods
    {
        public static SeedType CC = new SeedType() { Id = 1, Name = "Credit Card" };
        public static SeedType COD = new SeedType() { Id = 2, Name = "COD" };
    }
    public static class CarTypes
    {
        public static SeedType Bussiness = new SeedType() { Id = 1, Name = "Bussiness" };
        public static SeedType Economy = new SeedType() { Id = 2, Name = "Economy" };
    }
    public static class DriverStatuses
    {
        public static SeedType Busy = new SeedType() { Id = 1, Name = "Busy" };
        public static SeedType OutOfWork = new SeedType() { Id = 2, Name = "Out Of Work" };
    }
    public static class TripStatuses
    {
        public static SeedType Pending = new SeedType() { Id = 1, Name = "Pending" };
        public static SeedType Accepted = new SeedType() { Id = 2, Name = "Accepted" };
        public static SeedType Started = new SeedType() { Id = 3, Name = "Started" };
        public static SeedType Canceled = new SeedType() { Id = 4, Name = "Canceled" };
        public static SeedType Finished = new SeedType() { Id = 5, Name = "Finished" };
        public static SeedType Paid= new SeedType() { Id = 6, Name = "Paid" };



    }
    public class SeedType
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}