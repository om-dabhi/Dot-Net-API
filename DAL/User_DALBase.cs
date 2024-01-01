using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.DAL
{

    public class User_DalBase : DAL_Helpers 
    {
        public bool PR_DELETE_USER(int UserID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnString);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_DELETE_USER");
                sqldb.AddInParameter(cmd,"@UserID",SqlDbType.Int,UserID);
                if(Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
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
                SqlDatabase sqldb = new SqlDatabase(ConnString);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_INSERT_USER");
                sqldb.AddInParameter(cmd, "@Name", SqlDbType.VarChar, userModel.Name);
                sqldb.AddInParameter(cmd, "@Contact", SqlDbType.VarChar, userModel.Contact);
                sqldb.AddInParameter(cmd, "@Email", SqlDbType.VarChar, userModel.Email);
                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public List<UserModel> PR_SELECT_ALL_USER()
        {
            try
            {
                SqlDatabase sqlDatabase= new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_USER");
                List<UserModel> userModels = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.UserId = Convert.ToInt32(dr["UserID"].ToString());
                        userModel.Name = dr["Name"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        userModels.Add(userModel);
                    }
                }
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID); UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        userModel.UserId = Convert.ToInt32(dr["UserID"].ToString()); userModel.Name = dr["Name"].ToString();
                        userModel.Contact = dr["Contact"].ToString(); userModel.Email = dr["Email"].ToString();
                    }

                }
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
