using VKInsuranceApi.MModels;

namespace VKInsuranceApi.RepositotyDesignPattern.Interfaces
{
    public interface ILogin
    {
        public MLoginCustomer ValidateLogin(MLoginCustomer Mcustomer);
        public List<CustomerListDTO> GetAllCustomers();
    }
}
