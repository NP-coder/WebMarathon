using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMarathon.Utility
{
    public class Helper
    {
        public static string Client = "Клієнт";
        public static string Operator = "Оператор";
        public static string Admin = "Адміністратор";
        //public static string Processed = "Обробляється";
        //public static string Rejected = "Відхилено";
        //public static string Approved = "Схвалено";


        public static Dictionary<int,string> RequestStatus = new Dictionary<int, string>()
        {
            [1] = "Обробляється",
            [2] = "Відхилено",
            [3] = "Схвалено",
        };

        public static List<SelectListItem> GetRequestStatus()
        {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.RequestStatus[1],Text=Helper.RequestStatus[1]},
                    new SelectListItem{Value=Helper.RequestStatus[2],Text=Helper.RequestStatus[2]},
                    new SelectListItem{Value=Helper.RequestStatus[3],Text=Helper.RequestStatus[3]}

                };
        }

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            if (isAdmin)
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Operator,Text=Helper.Operator},
                    new SelectListItem{Value=Helper.Admin,Text=Helper.Admin},
                    new SelectListItem{Value=Helper.Client,Text=Helper.Client}

                };
            }
            else
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Client,Text=Helper.Client},

                };
            }
        }
    }
}
