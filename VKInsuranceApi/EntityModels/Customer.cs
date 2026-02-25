namespace VKInsuranceApi.EntityModels;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerFirstName { get; set; } = null!;

    public string? CustomerLastName { get; set; }

    public string? CustomerMiddleName { get; set; }

    public string CustomerEmail { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public int Sponsorid { get; set; }
}
