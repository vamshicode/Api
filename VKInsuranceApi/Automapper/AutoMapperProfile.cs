using AutoMapper;
using VKInsuranceApi.EntityModels;
using VKInsuranceApi.MModels;

namespace VKInsuranceApi.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Login
            CreateMap<MLoginCustomer, Customer>();
            //get list of customers
            CreateMap<Customer, CustomerListDTO>();
            CreateMap<Customer, MLoginCustomer>();

        }
    }
}
