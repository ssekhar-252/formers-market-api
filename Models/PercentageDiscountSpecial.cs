namespace FormersMarket
{
    public class PercentageDiscountSpecial : Special
    {
        private string discountedProductCode;
        private decimal discountPercentage;
        private decimal discounedProductPrice;

        PrintParticulars printParts;
        public PercentageDiscountSpecial(string productCode, string discountedProductCode, decimal discountPercentage, decimal discountedProductPrice) : base(productCode)
        {
            this.discountedProductCode = discountedProductCode;
            this.discountPercentage = discountPercentage;
            discounedProductPrice = discountedProductPrice;
        }
        public override bool CanApply(string productCode, int quantity)
        {
            return productCode == ProductCode && quantity > 0;
        }
        public override PrintParticulars PrintSpecials(string productCode, decimal price, int quantity, Dictionary<string, int> basket, int index)
        {
            if (basket[productCode] > 0 && basket.ContainsKey(discountedProductCode))
            {
                printParts = (new PrintParticulars { Special = "APOM", Price = -discounedProductPrice * discountPercentage });
            }
            else printParts = null;
            return printParts;
        }
    }
}