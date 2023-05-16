using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using ProductMate.Areas.Admin.Models;
using ProductMate.DatabaseConnectivity;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductMate.DatabaseConnectivity
{
    public class AppDataConnectivity : IAppDataConnectivity
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = "Data Source=.;Server=DESKTOP-PAUP6KE;Initial Catalog=ProductMate;Trusted_Connection=True; User ID=SERVER160;password=Pratik@1234;Integrated Security=false";
            con = new SqlConnection(constr);
        }

        public List<SelectListItem> getOrganisations()
        {
            DataTable dataTable = new DataTable();
            DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            List<SelectListItem> organisations = new List<SelectListItem>();
            try
            {
                dataTable = clsDatabaseConnectivity.getDataTable("GetOrganisations");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    organisations.Add(new SelectListItem { 
                        Text = dataRow["organisation_name"].ToString(), 
                        Value = dataRow["organisation_id"].ToString() 
                    });
                }

                return organisations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsDatabaseConnectivity = null;
                dataTable = null;
                organisations = null;
            }
        }

        public List<SelectListItem> getUserRoles()
        {
            DataTable dataTable = new DataTable();
            DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            List<SelectListItem> roles = new List<SelectListItem>();
            try
            {
                dataTable = clsDatabaseConnectivity.getDataTable("GetUserRoles");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    roles.Add(new SelectListItem
                    {
                        Text = dataRow["role_name"].ToString(),
                        Value = dataRow["user_role_id"].ToString()
                    });
                }

                return roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsDatabaseConnectivity = null;
                dataTable = null;
                roles = null;
            }
        }

        public Boolean SaveUser(Users clsUsers)
        {
            Boolean IsUserAdded = false;
            try
            {
                connection();
                SqlCommand com = new SqlCommand("AddNewUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", clsUsers.strFirstName);
                com.Parameters.AddWithValue("@LastName", clsUsers.strLastName);
                com.Parameters.AddWithValue("@Contact", clsUsers.strContact);
                com.Parameters.AddWithValue("@EmailId", clsUsers.strEmailId);
                com.Parameters.AddWithValue("@Username", clsUsers.strUsername);
                com.Parameters.AddWithValue("@Password", clsUsers.strPassword);
                com.Parameters.AddWithValue("@CreateDate", clsUsers.dteCreateDate);
                com.Parameters.AddWithValue("@CreatedBy", clsUsers.intCreatedBy);
                com.Parameters.AddWithValue("@OrganisationId", clsUsers.intOrganisationId);
                com.Parameters.AddWithValue("@UserRoleId", clsUsers.intUserRoleId);
                com.Parameters.AddWithValue("@Status", clsUsers.intStatus);

                con.Open();
                int insertCount = com.ExecuteNonQuery();
                con.Close();
                if (insertCount >= 1)
                {
                    IsUserAdded = true;
                }
                else
                {
                    IsUserAdded = false;
                }

                return IsUserAdded;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public List<UserListGrid> getAllUsers()
        {
            UserListGrid clsUserListGrid;
            List<UserListGrid> colUserListGrid = new List<UserListGrid>();
            DataTable dataTable = new DataTable();
            DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            try
            {
                dataTable = clsDatabaseConnectivity.getDataTable("GetAllUsers");

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        clsUserListGrid = new UserListGrid();
                        if(dataRow["users_id"] != null) 
                        {
                            clsUserListGrid.intUsersId = Convert.ToInt32(dataRow["users_id"]);
                        }
                        if (dataRow["first_name"] != null)
                        {
                            clsUserListGrid.strFirstName = Convert.ToString(dataRow["first_name"]);
                        }
                        if (dataRow["last_name"] != null)
                        {
                            clsUserListGrid.strLastName = Convert.ToString(dataRow["last_name"]);
                        }
                        if (dataRow["contact"] != null)
                        {
                            clsUserListGrid.strContact = Convert.ToString(dataRow["contact"]);
                        }
                        if (dataRow["email_id"] != null)
                        {
                            clsUserListGrid.strEmailId = Convert.ToString(dataRow["email_id"]);
                        }
                        if (dataRow["username"] != null)
                        {
                            clsUserListGrid.strUsername = Convert.ToString(dataRow["username"]);
                        }
                        if (dataRow["password"] != null)
                        {
                            clsUserListGrid.strPassword = Convert.ToString(dataRow["password"]);
                        }
                        if (dataRow["create_date"] != null)
                        {
                            clsUserListGrid.dteCreateDate = Convert.ToDateTime(dataRow["create_date"]);
                        }
                        if (dataRow["created_by"] != null)
                        {
                            clsUserListGrid.strCreatedBy = getCreatedByUsername(Convert.ToString(dataRow["created_by"]));

                            clsUserListGrid.strCreatedBy = clsUserListGrid.strCreatedBy == "" ? "Other" : clsUserListGrid.strCreatedBy;
                        }
                        if (dataRow["organisation_id"] != null)
                        {
                            clsUserListGrid.strOrganisation = Convert.ToString(
                                clsDatabaseConnectivity.getDataTableBySQLQuery(
                                "SELECT organisation_name FROM users INNER JOIN organisation " +
                                "ON users.organisation_id = organisation.organisation_id " +
                                "WHERE users.users_id =  " + clsUserListGrid.intUsersId
                                ));

                            clsUserListGrid.strOrganisation = Convert.ToString(clsUserListGrid.strOrganisation) == "0" ? "Other" : Convert.ToString(clsUserListGrid.strOrganisation);
                        }
                        if (dataRow["user_role_id"] != null)
                        {
                            clsUserListGrid.strUserRole = Convert.ToString(
                                clsDatabaseConnectivity.getDataTableBySQLQuery(
                                "SELECT role_name FROM users INNER JOIN user_role " +
                                "ON users.user_role_id = user_role.user_role_id " +
                                "WHERE users_id = " + clsUserListGrid.intUsersId
                                ));
                        }
                        if (dataRow["status"] != null)
                        {
                            clsUserListGrid.strStatus = Convert.ToString(dataRow["status"]) == "0" ? "Inactive" : "Active";
                        }
                        
                        colUserListGrid.Add(clsUserListGrid);
                        clsUserListGrid = null;
                    }
                }
                else
                {
                    clsUserListGrid = null;
                    colUserListGrid = null;
                }
                return colUserListGrid;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsUserListGrid = null;
                colUserListGrid = null;
            }
        }


        public string getCreatedByUsername(string strCreatedBy)
        {
            string strCreatedByUsername = string.Empty;
            DataTable dt = new DataTable();
            DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            try
            {
                dt = clsDatabaseConnectivity.getDataTableBySQLQuery("SELECT username FROM users WHERE users_id = " + strCreatedBy);

                foreach (DataRow dataRow in dt.Rows) {
                    strCreatedByUsername = (String)dataRow["username"];
                }

                return strCreatedByUsername;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }



    }
}
