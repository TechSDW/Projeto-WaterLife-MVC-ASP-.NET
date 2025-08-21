using System.ComponentModel.DataAnnotations;

namespace WaterLifeMVC.Models
{
    public class ProductModel
    {
        [Key]
        public int id {  get; set; }
        public string name { get; set; }
        public byte[] image { get; set; }
        public string description { get; set; }
        public float price { get; set; }
    }
}