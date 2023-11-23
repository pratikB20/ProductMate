﻿using System;
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

        //Common Method to get datatable from SP without parameters
        public DataTable getDataTable(string StoredProcedureName = "")
        {
            DataTable dataTable = new DataTable();
            try
            {
                connection();
                SqlCommand com = new SqlCommand(StoredProcedureName, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);

                con.Open();
                da.Fill(dataTable);
                con.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Common Method to get datatable from QUERY
        public DataTable getDataTableBySQLQuery(string strQuery)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            try
            {
                connection();
                adp = new SqlDataAdapter(strQuery, con);
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex) { throw ex; }
            finally { adp = null; }
        }

        //To view employee details with generic list     
        public Users AuthenticateUser(string txtUsername, string txtPassword)
        {
            connection();
            Users clsUsers = new Users();
            SqlCommand com = new SqlCommand("AuthenticateUser", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@Username", txtUsername);
            com.Parameters.AddWithValue("@Password", txtPassword);
            DataTable dataTable = new DataTable();

            con.Open();
            da.Fill(dataTable);
            con.Close();

            //Bind EmpModel generic list using dataRow     
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    clsUsers.intUsersId = Convert.ToInt32(dataRow["users_id"]);
                    clsUsers.strFirstName = Convert.ToString(dataRow["first_name"]);
                    clsUsers.strLastName = Convert.ToString(dataRow["last_name"]);
                    clsUsers.strContact = Convert.ToString(dataRow["contact"]);
                    clsUsers.strEmailId = Convert.ToString(dataRow["email_id"]);
                    clsUsers.strUsername = Convert.ToString(dataRow["username"]);
                    clsUsers.strPassword = Convert.ToString(dataRow["password"]);
                    clsUsers.dteCreateDate = Convert.ToDateTime(dataRow["create_date"]);
                    clsUsers.intCreatedBy = Convert.ToInt32(dataRow["created_by"]);
                    clsUsers.intOrganisationId = Convert.ToInt32(dataRow["organisation_id"]);
                    clsUsers.intUserRoleId = Convert.ToInt32(dataRow["user_role_id"]);
                    clsUsers.intStatus = Convert.ToInt32(dataRow["status"]);
                }
            }
            else
            {
                clsUsers = null;
            }

            return clsUsers;
        }

        public List<SelectListItem> getOrganisations()
        {
            DataTable dataTable = new DataTable();
            //DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            List<SelectListItem> organisations = new List<SelectListItem>();
            try
            {
                dataTable = getDataTable("GetOrganisations");

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
                //clsDatabaseConnectivity = null;
                dataTable = null;
                organisations = null;
            }
        }

        public List<SelectListItem> getUserRoles()
        {
            DataTable dataTable = new DataTable();
            //DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            List<SelectListItem> roles = new List<SelectListItem>();
            try
            {
                dataTable = getDataTable("GetUserRoles");

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
                //clsDatabaseConnectivity = null;
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
                int intInsertCount = com.ExecuteNonQuery();
                con.Close();
                
                IsUserAdded = (intInsertCount >= 1) ? true : false;

                return IsUserAdded;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<UserListGrid> getAllUsers()
        {
            UserListGrid clsUserListGrid;
            List<UserListGrid> colUserListGrid = new List<UserListGrid>();
            DataTable dataTable = new DataTable();
            DataTable tempDataTable = new DataTable();
            //DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            try
            {
                dataTable = getDataTable("GetAllUsers");

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
                            tempDataTable = getDataTableBySQLQuery("SELECT username FROM users WHERE users_id = " + Convert.ToString(dataRow["created_by"]));
                            if (tempDataTable.Rows.Count > 0)
                            {
                                foreach (DataRow dr in tempDataTable.Rows) { clsUserListGrid.strCreatedBy = (String)dr["username"]; }
                            }
                            else { clsUserListGrid.strCreatedBy = "Other"; }
                            tempDataTable = null;
                        }
                        if (dataRow["organisation_id"] != null)
                        {
                            tempDataTable = getDataTableBySQLQuery("SELECT organisation_name FROM organisation WHERE organisation_id =  " + Convert.ToString(dataRow["organisation_id"]));
                            if (tempDataTable.Rows.Count > 0)
                            {
                                foreach (DataRow dr in tempDataTable.Rows) { clsUserListGrid.strOrganisation = (String)dr["organisation_name"]; }
                            }
                            else { clsUserListGrid.strOrganisation = "Other"; }
                            tempDataTable = null;
                        }
                        if (dataRow["user_role_id"] != null)
                        {
                            tempDataTable = getDataTableBySQLQuery("SELECT role_name FROM user_role WHERE user_role_id = " + Convert.ToString(dataRow["user_role_id"]));
                            if (tempDataTable.Rows.Count > 0)
                            {
                                foreach (DataRow dr in tempDataTable.Rows) { clsUserListGrid.strUserRole = (String)dr["role_name"]; }
                            }
                            else { clsUserListGrid.strUserRole = "Other"; }
                            tempDataTable = null;
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
                tempDataTable = null;
                dataTable = null;
            }
        }

        public bool DeleteUser(int intUserID)
        {
            Boolean IsUserDeleted = false;
            try
            {
                connection();
                SqlCommand com = new SqlCommand("DeleteUser", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@User_ID", intUserID);

                con.Open();
                int intDeleteCount = com.ExecuteNonQuery();
                con.Close();

                IsUserDeleted = (intDeleteCount >= 1) ? true : false;

                return IsUserDeleted;
            }
            catch(Exception ex)
            { throw ex; }
        }

        public Boolean UpdateUser(Users clsUsers)
        {
            Boolean IsUserUpdated = false;
            try
            {
                connection();
                SqlCommand com = new SqlCommand("UpdateUser", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserID", clsUsers.intUsersId);
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
                int intUpdateCount = com.ExecuteNonQuery();
                con.Close();

                IsUserUpdated = (intUpdateCount >= 1) ? true : false;

                return IsUserUpdated;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Users GetUserDetailsByUsersId(int intUsersId)
        {
            DataTable dataTable = new DataTable();
            //DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            Users clsUser = new Users();
            try
            {
                connection();
                SqlCommand com = new SqlCommand("GetUserDetailsByUsersId", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UsersID", intUsersId);
                SqlDataAdapter da = new SqlDataAdapter(com);

                con.Open();
                da.Fill(dataTable);
                con.Close();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["users_id"] != null)
                        {
                            clsUser.intUsersId = Convert.ToInt32(dataRow["users_id"]);
                        }
                        if (dataRow["first_name"] != null)
                        {
                            clsUser.strFirstName = Convert.ToString(dataRow["first_name"]);
                        }
                        if (dataRow["last_name"] != null)
                        {
                            clsUser.strLastName = Convert.ToString(dataRow["last_name"]);
                        }
                        if (dataRow["contact"] != null)
                        {
                            clsUser.strContact = Convert.ToString(dataRow["contact"]);
                        }
                        if (dataRow["email_id"] != null)
                        {
                            clsUser.strEmailId = Convert.ToString(dataRow["email_id"]);
                        }
                        if (dataRow["username"] != null)
                        {
                            clsUser.strUsername = Convert.ToString(dataRow["username"]);
                        }
                        if (dataRow["password"] != null)
                        {
                            clsUser.strPassword = Convert.ToString(dataRow["password"]);
                        }
                        if (dataRow["create_date"] != null)
                        {
                            clsUser.dteCreateDate = Convert.ToDateTime(dataRow["create_date"]);
                        }
                        if (dataRow["created_by"] != null)
                        {
                            clsUser.intCreatedBy = Convert.ToInt32(dataRow["created_by"]);
                        }
                        if (dataRow["organisation_id"] != null)
                        {
                            clsUser.intOrganisationId = Convert.ToInt32(dataRow["organisation_id"]);
                        }
                        if (dataRow["user_role_id"] != null)
                        {
                            clsUser.intUserRoleId = Convert.ToInt32(dataRow["user_role_id"]);
                        }
                        if (dataRow["status"] != null)
                        {
                            clsUser.intStatus = Convert.ToInt32(dataRow["status"]);
                        }
                    }
                }
                else
                {
                    clsUser = null;
                }
                return clsUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsUser = null;
                dataTable = null;
            }
        }

        public Boolean SaveUserRole(UserRole clsUserRole)
        {
            Boolean IsUserRoleAdded = false;
            try
            {
                connection();
                SqlCommand com = new SqlCommand("AddNewUserRole", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@RoleName", clsUserRole.strRoleName);
                com.Parameters.AddWithValue("@Description", clsUserRole.strDescription);
                com.Parameters.AddWithValue("@CreateDate", clsUserRole.dteCreateDate);
                com.Parameters.AddWithValue("@CreatedBy", clsUserRole.intCreatedBy);
                com.Parameters.AddWithValue("@Status", clsUserRole.intStatus);

                con.Open();
                int intInsertCount = com.ExecuteNonQuery();
                con.Close();

                IsUserRoleAdded = (intInsertCount >= 1) ? true : false;

                return IsUserRoleAdded;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public List<RoleListGrid> getAllRoles()
        {
            RoleListGrid clsRoleListGrid;
            List<RoleListGrid> colRoleListGrid = new List<RoleListGrid>();
            DataTable dataTable = new DataTable();
            DataTable tempDataTable = new DataTable();
            //DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            try
            {
                dataTable = getDataTable("GetAllRoles");

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        clsRoleListGrid = new RoleListGrid();
                        if (dataRow["user_role_id"] != null)
                        {
                            clsRoleListGrid.intUserRolesId = Convert.ToInt32(dataRow["user_role_id"]);
                        }
                        if (dataRow["role_name"] != null)
                        {
                            clsRoleListGrid.strRoleName = Convert.ToString(dataRow["role_name"]);
                        }
                        if (dataRow["description"] != null)
                        {
                            clsRoleListGrid.strDescription = Convert.ToString(dataRow["description"]);
                        }
                        if (dataRow["create_date"] != null)
                        {
                            clsRoleListGrid.dteCreateDate = Convert.ToDateTime(dataRow["create_date"]);
                        }
                        if (dataRow["created_by"] != null)
                        {
                            tempDataTable = getDataTableBySQLQuery("SELECT username FROM users WHERE users_id = " + Convert.ToString(dataRow["created_by"]));
                            if (tempDataTable.Rows.Count > 0)
                            {
                                foreach (DataRow dr in tempDataTable.Rows) { clsRoleListGrid.strCreatedBy = (String)dr["username"]; }
                            }
                            else { clsRoleListGrid.strCreatedBy = "Other"; }
                            tempDataTable = null;
                        }
                        if (dataRow["status"] != null)
                        {
                            clsRoleListGrid.strStatus = Convert.ToString(dataRow["status"]) == "0" ? "Inactive" : "Active";
                        }

                        colRoleListGrid.Add(clsRoleListGrid);
                        clsRoleListGrid = null;
                    }
                }
                else
                {
                    clsRoleListGrid = null;
                    colRoleListGrid = null;
                }
                
                return colRoleListGrid;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                colRoleListGrid = null;
            }
        }

        public bool DeleteUserRole(int intUserRoleId)
        {
            Boolean IsUserRoleDeleted = false;
            try
            {
                connection();
                SqlCommand com = new SqlCommand("DeleteUserRole", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@User_Role_ID", intUserRoleId);
                con.Open();
                int intDeleteCount = com.ExecuteNonQuery();
                con.Close();

                IsUserRoleDeleted = (intDeleteCount >= 1) ? true : false;

                return IsUserRoleDeleted;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public UserRole GetUserRoleDetailsByUserRoleId(int intUserRoleId)
        {
            DataTable dataTable = new DataTable();
            //DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            UserRole clsUserRole = new UserRole();
            try
            {
                connection();
                SqlCommand com = new SqlCommand("GetUserRoleDetailsByUserRoleId", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserRoleID",intUserRoleId);
                SqlDataAdapter da = new SqlDataAdapter(com);

                con.Open();
                da.Fill(dataTable);
                con.Close();

                if (dataTable.Rows.Count > 0)
                {
                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        if(dataRow["user_role_id"] != null)
                        {
                            clsUserRole.intUserRoleId = Convert.ToInt32(dataRow["user_role_id"]);
                        }
                        if (dataRow["role_name"] != null)
                        {
                            clsUserRole.strRoleName = Convert.ToString(dataRow["role_name"]);
                        }
                        if (dataRow["description"] != null)
                        {
                            clsUserRole.strDescription = Convert.ToString(dataRow["description"]);
                        }
                        if (dataRow["create_date"] != null)
                        {
                            clsUserRole.dteCreateDate = Convert.ToDateTime(dataRow["create_date"]);
                        }
                        if (dataRow["created_by"] != null)
                        {
                            clsUserRole.intCreatedBy = Convert.ToInt32(dataRow["created_by"]);
                        }
                        if (dataRow["status"] != null)
                        {
                            clsUserRole.intStatus = Convert.ToInt32(dataRow["status"]);
                        }
                    }
                }
                else
                {
                    clsUserRole = null;
                }

                return clsUserRole;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataTable = null;
                //clsDatabaseConnectivity = null;
                clsUserRole = null;
            }
        }

        public Boolean UpdateUserRole(UserRole clsUserRole)
        {
            Boolean IsUserRoleUpdated = false;
            try
            {
                connection();
                SqlCommand com = new SqlCommand("UpdateUserRole", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserRoleID", clsUserRole.intUserRoleId);
                com.Parameters.AddWithValue("@RoleName", clsUserRole.strRoleName);
                com.Parameters.AddWithValue("@Description", clsUserRole.strDescription);
                com.Parameters.AddWithValue("@CreateDate", clsUserRole.dteCreateDate);
                com.Parameters.AddWithValue("@CreatedBy", clsUserRole.intCreatedBy);
                com.Parameters.AddWithValue("@Status", clsUserRole.intStatus);

                con.Open();
                int intUpdateCount = com.ExecuteNonQuery();
                con.Close();

                IsUserRoleUpdated = (intUpdateCount >= 1) ? true : false;

                return IsUserRoleUpdated;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Boolean SaveDelegate(Delegates clsDelegates)
        {
            Boolean IsDelegateAdded = false;
            try
            {
                connection();
                SqlCommand com = new SqlCommand("AddNewDelegate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@DelegateName",clsDelegates.strDelegateName);
                com.Parameters.AddWithValue("@DelegateContact", clsDelegates.strDelegateContact);
                com.Parameters.AddWithValue("@DelegateEmailId", clsDelegates.strDelegateEmailId);
                com.Parameters.AddWithValue("@CreateDate", clsDelegates.dteCreateDate);
                com.Parameters.AddWithValue("@CreatedBy", clsDelegates.intCreatedBy);
                com.Parameters.AddWithValue("@Status", clsDelegates.intStatus);

                con.Open();
                int intInsertCount = com.ExecuteNonQuery();
                con.Close();
                
                IsDelegateAdded = (intInsertCount >= 1) ? true : false;

                return IsDelegateAdded;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<DelegateListGrid> getAllDelegates()
        {
            DelegateListGrid clsDelegateListgrid;
            List<DelegateListGrid> colDelegateListGrid = new List<DelegateListGrid>();
            DataTable datatable = new DataTable();
            DataTable tempDataTable = new DataTable();
            try
            {
                datatable = getDataTable("GetAllDelegates");

                if(datatable.Rows.Count > 0)
                {
                    foreach(DataRow dataRow in datatable.Rows)
                    {
                        clsDelegateListgrid = new DelegateListGrid();

                        if(dataRow["delegate_id"] != null)
                        {
                            clsDelegateListgrid.intDelegateId = Convert.ToInt32(dataRow["delegate_id"]);
                        }
                        if (dataRow["delegate_name"] != null)
                        {
                            clsDelegateListgrid.strDelegateName = Convert.ToString(dataRow["delegate_name"]);
                        }
                        if (dataRow["delegate_contact"] != null)
                        {
                            clsDelegateListgrid.strDelegateContact = Convert.ToString(dataRow["delegate_contact"]);
                        }
                        if (dataRow["delegate_email_id"] != null)
                        {
                            clsDelegateListgrid.strDelegateEmailId = Convert.ToString(dataRow["delegate_email_id"]);
                        }
                        if (dataRow["create_date"] != null)
                        {
                            clsDelegateListgrid.dteCreateDate = Convert.ToDateTime(dataRow["create_date"]);
                        }
                        if(dataRow["created_by"] != null)
                        {
                            tempDataTable = getDataTableBySQLQuery("SELECT username FROM users WHERE users_id = " + Convert.ToString(dataRow["created_by"]));
                            if(tempDataTable.Rows.Count > 0)
                            {
                                foreach(DataRow dr in tempDataTable.Rows) { clsDelegateListgrid.strCreatedBy = (string)dr["username"]; }
                            }
                            else { clsDelegateListgrid.strCreatedBy = "Other"; }
                            tempDataTable = null;
                        }
                        if(dataRow["status"] != null)
                        {
                            clsDelegateListgrid.strStatus = Convert.ToString(dataRow["status"]) == "0" ? "Inactive" : "Active";
                        }

                        colDelegateListGrid.Add(clsDelegateListgrid);
                        clsDelegateListgrid = null;
                    }
                }
                else
                {
                    clsDelegateListgrid = null;
                    colDelegateListGrid = null;
                }

                return colDelegateListGrid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                colDelegateListGrid = null;
            }
        }
    }
}
