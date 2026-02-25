namespace VKInsuranceApi.MModels
{
    public class CustomerListDTO
    {
        public int CustomerId { get; set; } = 0;

        public string CustomerFirstName { get; set; } = null!;

        public string? CustomerLastName { get; set; } = null;

        public string? CustomerMiddleName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; } = null!;

        public string CustomerAddress { get; set; } = null!;

        public int Sponsorid { get; set; } = 0;

        public string? ErrorMessage { get; set; }
    }
}
