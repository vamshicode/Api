using AutoMapper;
using Microsoft.Data.SqlClient;
using VKInsuranceApi.Database;
using VKInsuranceApi.MModels;
using VKInsuranceApi.RepositotyDesignPattern.Interfaces;

namespace VKInsuranceApi.RepositotyDesignPattern.Implementation
{
    public class Login : ILogin
    {
        WillisDbContext _dbContext;
        private IMapper _mapper;
        public Login(WillisDbContext willisDbContext, IMapper mapper)
        {
            _dbContext = willisDbContext;
            _mapper = mapper;
        }
        public MLoginCustomer ValidateLogin(MLoginCustomer Mcustomer)
        {
            try
            {

                if (string.IsNullOrEmpty(Mcustomer.CustomerEmail))
                {
                    var OutModel = new MLoginCustomer();
                    OutModel.ErrorMessage = "Please enter your email";
                    return OutModel;
                }
                else
                {
                    var IsExist = _dbContext.Customers.FirstOrDefault(x => x.CustomerEmail == Mcustomer.CustomerEmail);

                    if (IsExist == null)
                    {
                        var error = new MLoginCustomer();
                        error.ErrorMessage = "Customer doesnt Exist";
                        return error;
                    }

                    MLoginCustomer res = _mapper.Map<MLoginCustomer>(IsExist);

                    return res;

                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("no user found", ex);

            }
        }

        public string CreateJWTToken(MLoginCustomer JwtDetails)
        {
            return "";
        }

        public List<CustomerListDTO> GetAllCustomers()
        {
            var customers = _dbContext.Customers.ToList();
            if (customers == null || customers.Count == 0)
            {
                string error = "No customers found";
                throw new ArgumentException(error);
            }
            var res = _mapper.Map<List<CustomerListDTO>>(customers);
            return res;
        }
    }
}
