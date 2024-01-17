namespace UseCases.UseCaseInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int productId, int qtyToSell, int pts, string firstName, string lastName, string address, string city,
    string postalCode, string phone, string UserId);
    }
}