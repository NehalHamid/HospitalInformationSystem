using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using HospitalInformationSystem.Models.Models;


namespace HospitalInformationSystem.Data
{
   
    public class ApplicationUser: IdentityUser
    {

        public string? FullName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string? Gender { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? NationalID { get; set; }
        public string? Image { get; set; }
    }
}
