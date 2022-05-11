using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Store_Web_Api.Entities
{
    public class Movie
    {
        public Movie()
        {
            Actors = new List<Actor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MovieYear { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public List<Actor> Actors { get; set; }
        public Double Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
