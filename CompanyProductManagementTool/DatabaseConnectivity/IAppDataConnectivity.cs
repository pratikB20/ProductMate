using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ProductMate.DatabaseConnectivity
{
    public interface IAppDataConnectivity
    {
        //AREA - ADMIN
        public SelectListItems getOrganisations();
       

        //AREA - Customer
        //AREA - Product Support
        //AREA - IT
        //AREA - Sales Marketing
        //AREA - Accounting
    }
}
