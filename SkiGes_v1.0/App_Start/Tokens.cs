using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiGes_v1._0.App_Start
{
    public enum USERTYPE{ USER, ADMIN}
    public class Tokens
    {
        public static Boolean logged = false;
        public static USERTYPE userType = USERTYPE.USER;
    }
}