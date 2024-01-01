using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.PR_SELECT_ALL_USER();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>(); 
            if (users != null && users.Count > 0)
            {
                response.Add("status", true); 
                response.Add("message", "Data Found.");
                response.Add("data", users);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        [HttpGet("{UserID}")]
        public IActionResult Get(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            UserModel user = bal.PR_SELECT_BY_PK_USER(UserID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (user.UserId != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int UserID)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.PR_DELETE_USER(UserID);

            Dictionary<string,dynamic> response = new Dictionary<string,dynamic>();
            if(IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted Successfully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Error Occured!");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        [HttpPost]
        public IActionResult Insert([FromForm]UserModel userModel)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.PR_INSERT_USER(userModel);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted Successfully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Error Occured!");
                return NotFound(response);
            }
        }
    }
}
