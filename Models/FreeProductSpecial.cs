namespace FormersMarket
{
    public class FreeProductSpecial : Special
    {
        private string freeProductCode;
        private decimal freeProductPrice;
        PrintParticulars printParts;
        public FreeProductSpecial(string productCode, string freeProductCode, decimal freeProductPrice) : base(productCode)
        {
            this.freeProductCode = freeProductCode;
            this.freeProductPrice = freeProductPrice;
        }
        public override bool CanApply(string productCode, int quantity)
        {
            return productCode == ProductCode && quantity > 0;
        }
        public override PrintParticulars PrintSpecials(string productCode, decimal price, int quantity, Dictionary<string, int> basket, int index)
        {
            if (basket[productCode] > 0 && basket.ContainsKey(freeProductCode) && index == 1)
                printParts = new PrintParticulars { Special = "CHMK", Price = -freeProductPrice };
            else
                printParts = null;

            return printParts;
        }
    }
}