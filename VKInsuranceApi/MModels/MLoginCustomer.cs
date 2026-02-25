namespace VKInsuranceApi.MModels
{
    public class MLoginCustomer
    {
        public int? CustomerId { get; set; } = 0;


        //[Required(ErrorMessage = "Enter email ID")]
        public string? CustomerEmail { get; set; }



        public int? Sponsorid { get; set; } = 0;

        public string? ErrorMessage { get; set; }

        public string? JWTToken { get; set; }

    }
}
