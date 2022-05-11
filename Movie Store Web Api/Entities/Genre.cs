using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Store_Web_Api.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
