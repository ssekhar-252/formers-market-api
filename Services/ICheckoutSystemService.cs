namespace FormersMarket.Services
{
    public interface ICheckoutSystemService
    {
        Dictionary<string, Product> GetAllProducts();
        Dictionary<string, int> Scan(string productCode);
        List<PrintParticulars> PrintBasket();
        void ClearBasket();
    }
}