﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace library_ms.NewFolder1
{
    public partial class librarian : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHIVANGI LAD\source\repos\library_ms\App_Data\lms.mdf;Integrated Security=True");
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from messages where dusername='librarian' and placed= 'no'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            notification1.Text = count.ToString();
            notification2.Text = count.ToString();

            r1.DataSource = dt;
            r1.DataBind();


        }

        public string gettwentycharacters(object myvalues)
        {
            string a;
            a = Convert.ToString(myvalues.ToString());
            string b = "";

            if (a.Length >= 15)
            {
                b = a.Substring(0, 15);
                return b.ToString();
            }
            else
            {
                b = a.ToString();
                return b.ToString();
            }
        }    
    }
}