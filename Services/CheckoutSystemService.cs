namespace FormersMarket.Services
{
    public class CheckoutSystemService: ICheckoutSystemService
    {
        private Dictionary<string, Product> products;
        private List<Special> specials;
        private Dictionary<string, int> basket;
        List<PrintParticulars> printParts;

        public CheckoutSystemService()
        {
            InitializeProducts();
            InitializeSpecials();
            basket = new Dictionary<string, int>();
            printParts = new List<PrintParticulars>();
        }

        private void InitializeProducts()
        {
            products = new Dictionary<string, Product>
        {
            { "CH1", new Product("Chai", 3.11m) },
            { "AP1", new Product("Apples", 6.00m) },
            { "CF1", new Product("Coffee", 11.23m) },
            { "MK1", new Product("Milk", 4.75m) },
            { "OM1", new Product("Oatmeal", 3.69m) }
        };
        }

        private void InitializeSpecials()
        {
            specials = new List<Special>
        {
            new BuyOneGetOneFreeSpecial("CF1"),
            new BulkDiscountSpecial("AP1", 3, 4.50m),
            new FreeProductSpecial("CH1", "MK1", 4.75m),
            new PercentageDiscountSpecial("OM1", "AP1", 0.5m, 6.00m)
        };
        }

        public Dictionary<string, Product> GetAllProducts() {
            return products;
        }

        public Dictionary<string, int> Scan(string productCode)
        {
            if (!products.ContainsKey(productCode))
                return basket;

            if (basket.ContainsKey(productCode))
                basket[productCode]++;
            else
                basket[productCode] = 1;

            return basket;
        }

        public void ClearBasket() {
            basket = new Dictionary<string, int>();
            printParts = new List<PrintParticulars>();
        }

        public List<PrintParticulars> PrintBasket()
        {
            printParts = new List<PrintParticulars>();
            foreach (var entry in basket)
            {
                string productCode = entry.Key;
                int quantity = entry.Value;
                PrintParticulars(productCode, quantity, basket);
            }

            return printParts;
        }

        private List<PrintParticulars> PrintParticulars(string productCode, int quantity, Dictionary<string, int> basket)
        {
            Product product = products[productCode];
            decimal price = product.Price;

            for (int i = 1; i <= quantity; i++)
            {
                printParts.Add(new PrintParticulars { ProductCode = productCode, Price = price });
                foreach (Special special in specials)
                    if (special.CanApply(productCode, quantity))
                    {
                        var discountObj = special.PrintSpecials(productCode, price, quantity, basket, i);
                        if(discountObj != null)
                        printParts.Add(discountObj);
                    }
            }

            return printParts;
        }
    }
}