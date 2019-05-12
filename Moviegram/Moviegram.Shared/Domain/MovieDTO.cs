using System;
using System.Collections.Generic;
using System.Text;

namespace Moviegram.Shared.Domain
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Picture { get; set; }
        public List<MovieTimeDTO> Times { get; set; }
    }
}
