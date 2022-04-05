using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Quntity { get; set; }
        [Display(Name = "تصویر")]
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
