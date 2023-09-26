namespace AkademiPlusMikroService.Discount.Dtos
{
    public class CreateDiscountCouponDto
    {

        public string UserID { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
