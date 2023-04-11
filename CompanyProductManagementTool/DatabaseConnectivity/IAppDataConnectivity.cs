using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductMate.DatabaseConnectivity
{
    public interface IAppDataConnectivity
    {
        //AREA - Admin
        public List<SelectListItem> getOrganisations();
        public List<SelectListItem> getUserRoles();
       

        //AREA - Customer
        //AREA - Product Support
        //AREA - IT
        //AREA - Sales Marketing
        //AREA - Accounting
    }
}
