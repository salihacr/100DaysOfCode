using CarGalleryApp.CustomAttributes;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CarGalleryApp.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Brand")]
        [Required]
        [Display(Name = "Marka")]
        public string Brand { get; set; }
        [BsonElement("Model")]
        [Required]
        public string Model { get; set; }
        [BsonElement("Year")]
        [Required]
        [YearRange]
        [Display(Name = "Yıl")]
        public int Year { get; set; }

        [BsonElement("Price")]
        [Display(Name = "Fiyat ($)")]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal Price { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "Resim")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }
    }
}
