using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class PostImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
