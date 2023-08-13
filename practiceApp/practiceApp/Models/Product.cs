
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace practiceApp.Models
{
    public enum Category{
        BISCUITS,TOAST,KHARI
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Field is empty")]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage ="Field is empty")]
        [EnumDataType(typeof(Category))]
        public Category category { get; set; }
        public DateOnly mfgDate { get; set; }

    }
}
