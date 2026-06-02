using System.ComponentModel.DataAnnotations;

namespace OCMS.Models
{
    public class Category   
    {
        [Key]
        public int CategoryId { get; set; }  
        public string CategoryName { get; set; } = string.Empty;
    }
}