namespace FormersMarket
{
    public abstract class Special
    {
        protected string ProductCode { get; }
        public Special(string productCode)
        {
            ProductCode = productCode;
        }
        public abstract bool CanApply(string productCode, int quantity);
        public abstract PrintParticulars PrintSpecials(string productCode, decimal price, int quantity, Dictionary<string, int> basket, int index);
    }
}