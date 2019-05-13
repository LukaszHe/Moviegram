using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moviegram.Data.Entities
{
    [Serializable]
    public class Movie
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public byte[] Picture { get; set; }
        public virtual List<MovieTime> Times { get; set; }

        [NotMapped]
        public byte[] Thumbnail { get; }

    }
}
