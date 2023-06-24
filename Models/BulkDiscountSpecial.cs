namespace FormersMarket
{
    public class BulkDiscountSpecial : Special
    {
        private int minimumQuantity;
        private decimal discountedPrice;
        PrintParticulars printParts;
        public BulkDiscountSpecial(string productCode, int minimumQuantity, decimal discountedPrice) : base(productCode)
        {
            this.minimumQuantity = minimumQuantity;
            this.discountedPrice = discountedPrice;
        }
        public override bool CanApply(string productCode, int quantity)
        {
            return productCode == ProductCode && quantity >= minimumQuantity;
        }
        public override PrintParticulars PrintSpecials(string productCode, decimal price, int quantity, Dictionary<string, int> basket, int index)
        {
            if (basket[productCode] >= minimumQuantity)
                printParts = (new PrintParticulars { Special = "APPL", Price = -price + discountedPrice });
            else
                printParts = null;

            return printParts;
        }
    }
}