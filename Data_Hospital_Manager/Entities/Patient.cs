using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager.Entities
{
    public class Patient
    {
        [Key] public int Id { get; set; }
        [Required][MaxLength(30)] public string FirstName { get; set; }
        [Required][MaxLength(30)] public string LastName { get; set; }
        [Required][EmailAddress] public string Email { get; set; }
        [Required][Phone] public string PhoneNumber { get; set; }
    }
}
