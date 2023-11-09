using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Utility
{
    public static class SD
    {

        public const string USER_ADMIN_ROLE = "Admin";
        public const string USER_CUSTOMER_ROLE = "Customer";
        public const string USER_COMPANY_ROLE = "Company";
        public const string USER_EMPLOYEE_ROLE = "Employee";



        public static List<string> Roles => new List<string>
        {
            USER_ADMIN_ROLE,
            USER_COMPANY_ROLE,
            USER_CUSTOMER_ROLE,
            USER_EMPLOYEE_ROLE,
        };

    }
}
