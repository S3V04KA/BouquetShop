namespace BouquetShop.GraphQL
{
    public record AddSalesmanInput(
        string FirstName,
        string LastName,
        string Email,
        string Pass,
        string PicUrl,
        float Money
        );

    public record AddBuyerInput(
        string FirstName,
        string LastName,
        string Email,
        string Pass,
        string PicUrl,
        float Money
        );

    public record AddBouqetInput(
        string Name,
        float Price,
        int Count,
        int SalemanId
        );

    public record BouqetInCartInput(
        int BouqetId,
        int BuyerId
        );
}
