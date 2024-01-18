using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using ProductMate.Areas.Admin.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductMate.DatabaseConnectivity
{
    public interface IAppDataConnectivity
    {
        //Global Common Methods
        public Users AuthenticateUser(string txtUsername, string txtPassword);
        public void RecordUserSession(int intUserID, DateTime? dteSessionStart, DateTime? dteSessionEnd, string strRemarks);

        //AREA - Admin
        public List<SelectListItem> getOrganisations();
        public List<SelectListItem> getUserRoles();
        public Boolean SaveUser(Users clsUsers);
        public List<UserListGrid> getAllUsers();
        public bool DeleteUser(int intUserID);
        public Boolean UpdateUser(Users clsUsers);
        public Users GetUserDetailsByUsersId(int intUsersId);
        public Boolean SaveUserRole(UserRole clsUserRole);
        public List<RoleListGrid> getAllRoles();
        public bool DeleteUserRole(int intUserRoleId);
        public UserRole GetUserRoleDetailsByUserRoleId(int intUserRoleId);
        public Boolean UpdateUserRole(UserRole clsUserRole);
        public Boolean SaveDelegate(Delegates clsDelegates);
        public List<DelegateListGrid> getAllDelegates();

        //AREA - Customer
        //AREA - Product Support
        //AREA - IT
        //AREA - Sales Marketing
        //AREA - Accounting
    }
}
