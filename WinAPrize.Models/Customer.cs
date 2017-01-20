
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinAPrize.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
 
        [Required]       
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string TelephoneNo { get; set; }

        [Required]
        public string TownOrCity { get; set; }

        [Required]        
        public string PostCode { get; set; }

        [Required]
        public string Country { get; set; }

        public virtual ICollection<Coupon> Coupons { get; set; }

    }
}
