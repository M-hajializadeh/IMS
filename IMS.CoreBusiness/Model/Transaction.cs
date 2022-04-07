using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Model
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int ProdcutId { get; set; }
        [Display(Name ="نام محصول")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductName { get; set; }
        [Display(Name = "قبل از خروج")]
        public int BeforeQty { get; set; }
        [Display(Name = "تعداد")]
        public int CheckOutQty { get; set; }
        [Display(Name = "نام انباردار")]
        public string WorkerName { get; set; }
        [Display(Name = "زمان خروج")]
        public DateTime LeftInventoryTimeStamp { get; set; }
        [Display(Name = "نام تحویل گیرنده")]
        public string RecivedProductEmployee { get; set; } = "Employee Name";
    }
}
