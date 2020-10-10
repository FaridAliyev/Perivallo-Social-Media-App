using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }
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
