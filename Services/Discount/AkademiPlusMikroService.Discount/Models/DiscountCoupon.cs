namespace AkademiPlusMikroService.Discount.Models
{
    public class DiscountCoupon
    {
        public int DiscountCouponID { get; set; }
        public string UserID { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
