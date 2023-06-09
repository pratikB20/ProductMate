﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Web.Mvc;

namespace ProductMate.DatabaseConnectivity
{
    public class DataConnectivity
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
            catch(Exception ex)
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
            if(dataTable.Rows.Count > 0)
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
    }
}
