using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        [ForeignKey("ProductId")]
        public Product ProductSold { get; set; }
        [ForeignKey("StaffMemeberId")]
        public StaffMemeber SalesPerson { get; set; }

    }
}
