using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moviegram.Data.Entities
{
    [Serializable]
    public class Cinema
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
