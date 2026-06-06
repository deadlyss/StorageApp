using System.ComponentModel.DataAnnotations;
using StorageApp.MVC.Validation;

namespace StorageApp.MVC.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва обов'язкова")]
        [StringLength(100, MinimumLength = 2)]
        [NoNumbers]
        [Display(Name = "Назва")]
        public string Name { get; set; } = string.Empty;

        [Range(0.1, 100000)]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Категорія обов'язкова")]
        [Display(Name = "Категорія")]
        public int CategoryId { get; set; }
    }
}
