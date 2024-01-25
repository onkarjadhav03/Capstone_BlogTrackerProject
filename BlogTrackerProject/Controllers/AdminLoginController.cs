using BlogTrackerProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BlogTrackerProject.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Adminsignin
        // GET: AdminSignIn
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: EmpSignin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "Server=tcp:capstonedb.database.windows.net,1433;Initial Catalog=CapstoneDb;Persist Security Info=False;User ID=onkar;Password=ManishPavan@333;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        }
        [HttpPost]
        public ActionResult Verify(AdminInfo adm)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from AdminInfo where EmailId='" + adm.EmailId + "' and Password='" + adm.Password + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Index", "Employeeinfo"); // Assuming EmployeeInfo is your controller name
            }
            else
            {
                con.Close();
                return RedirectToAction("Index", "Bloginfo");  // Assuming "Home" is the name of the view you want to return in case of failure
            }
        }

    }
}
