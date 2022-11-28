using System.ComponentModel.DataAnnotations;

namespace BloodBankManagementSystem.Models
{
    public class DonorDetails
    {
        [Key]
        public int donorId { get;set;}
        public string donorName { get;set;}
        public string donorMob { get; set; }
        public string donorEmail { get; set; }
        public int donorAge { get;set;}
        public int donorWeight { get;set;} 
        public int donorheight { get; set; }
        public string donorBloodType { get;set;}

    } 
}
