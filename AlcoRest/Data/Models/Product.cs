using AlcoRest.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlcoRest.Data.Models
{
    public class Product : BaseEntity
    {
        public string? name { get; set; }

        public string country { get; set; }

        public string imageUrl { get; set; }

        public decimal volume { get; set; }

        public decimal spirtVolume { get; set; }

        public decimal price { get; set; }
        
        public int count { get; set; }

        public CountDescription status { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime created { get; set; } = DateTime.Now;
        
        public int categoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
