using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq.Expressions;

namespace library_ms.librarian
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHIVANGI LAD\source\repos\library_ms\App_Data\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from librarian_registration where username= '" + username.Text + "' and password= '" + password.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i > 0)
            {
                Session["librarian"] = username.Text;
                Response.Redirect("demo.aspx");
            }
            else
            {
                error.Style.Add("display", "block"); 
            }
        }
    
    }
}