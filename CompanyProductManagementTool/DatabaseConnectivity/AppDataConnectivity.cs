using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using ProductMate.DatabaseConnectivity;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Web.Mvc;

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

        public SelectListItem convertToSelectList(KeyValues ColKeyValues)
        {
            SelectListItem clsSelectListItem = null;
            try
            {
                if (ColKeyValues.Count > 0)
                {
                    foreach (KeyValue clsKeyValue in ColKeyValues)
                    {
                        clsSelectListItem = new SelectListItem()
                        {
                            Value = Convert.ToString(clsKeyValue.intId),
                            Text = clsKeyValue.strName
                        };
                    }

                    return clsSelectListItem;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public KeyValues getOrganisations()
        {
            KeyValue clsSelectListItem;
            KeyValues colSelectListItem = new KeyValues();
            DataTable dataTable = new DataTable();
            DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            try
            {
                dataTable = clsDatabaseConnectivity.getDataTable("GetOrganisations");
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        clsSelectListItem = new KeyValue()
                        {
                            intId = Convert.ToInt32(dataRow["organisation_id"]),
                            strName = Convert.ToString(dataRow["organisation_name"])
                        };
                        colSelectListItem.Add(clsSelectListItem);
                    }
                }
                return colSelectListItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsDatabaseConnectivity = null;
            }
        }



    }
}
