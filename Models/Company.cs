using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StepUpLeadCareersTask.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Column(TypeName ="varchar(250)")]
        [Required(ErrorMessage ="This Field is Required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Column(TypeName = "varchar(250)")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Column(TypeName = "varchar(250)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Column(TypeName = "varchar(250)")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Column(TypeName = "varchar(250)")]//FirstName,LastName,Email,CompanyName,CompanySize,JobRole,JobDepartment,Phone,Country,UserIpAddress,UserBrowserDetails,UserOsInfroamtion,LinkPageUrl
        public string CompanySize { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Column(TypeName = "varchar(250)")]
        public string JobRole { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Column(TypeName = "varchar(250)")]
        public string JobDepartment { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Column(TypeName = "varchar(250)")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Column(TypeName = "varchar(250)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string UserIpAddress { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string UserBrowserDetails { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string UserOsInfroamtion { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string LinkPageUrl { get; set; }
    }
}
