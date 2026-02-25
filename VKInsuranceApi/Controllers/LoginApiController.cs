using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using VKInsuranceApi.MModels;
using VKInsuranceApi.RepositotyDesignPattern.Interfaces;
using VKInsuranceApi.Security;

namespace VKInsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private IConfiguration _configuration;
        private ILogin _ILogin { get; set; }
        public LoginApiController(ILogin login, IConfiguration configuration)
        {
            _ILogin = login;
            _configuration = configuration;
        }


        [HttpPost("WillisLogin")]
        public ActionResult WillisLogin([FromBody] MLoginCustomer loginCustomer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(loginCustomer.CustomerEmail))
                    {
                        return BadRequest("Enter email");
                    }
                    MLoginCustomer res = _ILogin.ValidateLogin(loginCustomer);
                    if (res.ErrorMessage == "Customer doesnt Exist")
                    {
                        return BadRequest(res.ErrorMessage = "Customer login failed and user didn't exist");
                    }

                    else
                    {
                        // Generate JWT token if user is valid

                        //Claim(created by taking entered input fields)
                        //res.CustomerEmail,res.CustomerId
                        //var JWTTokenObj = CreateJWTToken();
                        var tokenGenerator = new JWTTokenGenerator(_configuration);
                        string tokenString = tokenGenerator.CreateJWTToken(res.CustomerEmail, res.CustomerId.Value);
                        res.JWTToken = tokenString;



                        ////create token
                        //var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                        //res.JWTToken = tokenString;
                        return Ok(res);
                    }


                }
                catch (SqlException ex)
                {
                    throw new ApplicationException("no user found");

                }
            }

            return BadRequest();
        }
        //[Route()]
        [Authorize()]
        [HttpGet("CustomersList")]
        public ActionResult GetAllCustomers()
        {
            try
            {
                var customers = _ILogin.GetAllCustomers();

                if (customers == null || customers.Count == 0)
                {
                    return NoContent(); // 204
                }

                return Ok(customers);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving customers");
            }
        }

    }
}
