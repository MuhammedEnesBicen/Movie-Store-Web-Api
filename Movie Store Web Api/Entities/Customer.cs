using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Store_Web_Api.Entities
{
    public class Customer
    {
        public Customer()
        {
            PurchasedMovies = new List<Movie>();
            FavoriteGenres = new List<Genre> ();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }

        public List<Movie> PurchasedMovies { get; set; }
        public List<Genre> FavoriteGenres { get; set; }


    }
}
