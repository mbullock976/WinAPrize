namespace WinAPrize.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Coupon
    {
        public int CouponId { get; set; }

        [Required]        
        public string Code { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

