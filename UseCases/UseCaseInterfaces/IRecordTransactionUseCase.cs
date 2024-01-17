namespace UseCases.UseCaseInterfaces
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int productId, int qty, int pts, string firstName, string lastName, string address, string city,
    string postalCode, string phone, string UserId);
    }
}