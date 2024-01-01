using APIDemo.DAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.BAL
{
    public class User_BALBase : Controller
    {
        public List<UserModel> PR_SELECT_ALL_USER()
        {
            try
            {
                User_DalBase user_DALBase = new User_DalBase();
                List<UserModel> userModels = user_DALBase.PR_SELECT_ALL_USER();
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public UserModel PR_SELECT_BY_PK_USER(int UserID)
        {
            try
            {
                User_DalBase user_DALBase = new User_DalBase();
                UserModel userModel = user_DALBase.PR_SELECT_BY_PK_USER(UserID);
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool PR_DELETE_USER(int UserID)
        {
            try
            {
                User_DalBase dalUser = new User_DalBase();
                if (dalUser.PR_DELETE_USER(UserID))
                    return true;
                else
                    return false;
            }
            catch 
            { 
                return false;
            }
        }
        public bool PR_INSERT_USER(UserModel userModel)
        {
            try
            {
                User_DalBase dalUser = new User_DalBase();
                if (dalUser.PR_INSERT_USER(userModel))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
