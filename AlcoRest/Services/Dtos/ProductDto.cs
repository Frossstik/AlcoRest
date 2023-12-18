using AlcoRest.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlcoRest.Services.Dtos
{
    public class ProductDto
    {
        public string? name { get; set; }

        public string country { get; set; }

        public string imageUrl { get; set; }

        public decimal volume { get; set; }

        public decimal spirtVolume { get; set; }

        public decimal price { get; set; }

        public int count { get; set; }

        public CountDescription status { get; set; }

        public int categoryId { get; set; }
    }
}
