using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Store_Web_Api.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
