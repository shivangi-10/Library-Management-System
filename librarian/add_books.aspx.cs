using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public class Class1
{

    public static string GetRandomPassword(int length)
    {
        char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        string password = string.Empty;
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            int x = random.Next(1, chars.Length);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }
        return password;
    }

}


namespace library_ms.librarian
{
    public partial class add_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHIVANGI LAD\source\repos\library_ms\App_Data\lms.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if(Session["librarian"]== null)
            {
                Response.Redirect("login.aspx");
            }
        }

        
        protected void b1_Click(object sender, EventArgs e)
        {

            string books_image_name = Class1.GetRandomPassword(10) + ".jpg";
            string books_pdf = "";

            string path = "";
            string path1 = "";

            f1.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + books_image_name.ToString());
            path = "books_images/" + books_image_name.ToString();

            if (f2.FileName.ToString() != "")
            {
                books_pdf = Class1.GetRandomPassword(10) + ".pdf";
               
               
                f2.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_pdf/" + books_pdf.ToString());
                path1 = "books_pdf/" + books_pdf.ToString();
            }


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books values ('"+bookstitle.Text+"','"+path.ToString()+"','"+ path1.ToString() + "','"+authorname.Text+"','"+isbn.Text+"','"+qty.Text+"')";
            cmd.ExecuteNonQuery();

            msg.Style.Add("display", "block");


        }
    }
}