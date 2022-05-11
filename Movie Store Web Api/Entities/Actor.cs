using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Store_Web_Api.Entities
{
    public class Actor
    {
        public Actor()
        {
            Movies = new List<Movie>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
