namespace FormersMarket
{
    public class BuyOneGetOneFreeSpecial : Special
    {
        public BuyOneGetOneFreeSpecial(string productCode) : base(productCode) { }
        PrintParticulars printParts;
        public override bool CanApply(string productCode, int quantity)
        {
            return productCode == ProductCode && quantity >= 2;
        }
        public override PrintParticulars PrintSpecials(string productCode, decimal price, int quantity, Dictionary<string, int> basket, int index)
        {
            if (index % 2 == 0)
                printParts = (new PrintParticulars { Special = "BOGO", Price = -price });
            else
                printParts = null;
            return printParts;
        }
    }
}