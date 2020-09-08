using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.ViewModels
{
    public class UserVM
    {
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Username { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(200)]
        public string About { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public bool Private { get; set; }
    }
}
