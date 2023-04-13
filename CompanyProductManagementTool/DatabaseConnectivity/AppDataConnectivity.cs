using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
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



    }
}
