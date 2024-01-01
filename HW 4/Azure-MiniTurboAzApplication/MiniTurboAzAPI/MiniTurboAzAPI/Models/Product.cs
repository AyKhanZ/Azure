using System.ComponentModel.DataAnnotations.Schema;

namespace MiniTurboAzAPI.Models
{
  
    public class Product
    {
        public int Id { get; set; }
        public uint Year { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }

        public Author Author { get; set; }

        public List<Image> Images { get; set; }
    }
}
