using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TriESolutions.Models
{
    public class SendEmail
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "Message is required Please write your Message for tri e-solutions")]
        public string Message { get; set; }


    }
}
