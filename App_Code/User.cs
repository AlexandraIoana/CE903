using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public interface User
{
    int id { get; set; }
    String loginName { get; set; }
    String name { get; set; }
    String email { get; set; }
    String password { get; set; }

    Boolean checkLogin(String loginName, String password);
    Boolean SignUp(String loginName, String name, String email, String password);
}