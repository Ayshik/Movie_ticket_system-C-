using Movie_ticket_system.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_ticket_system.Models
{
   public class DataAccess
    {
        SqlConnection con;
        public DataAccess()
        {
            con = new SqlConnection(@"Data Source=desktop-k8o6se7\mssqlserver02;Initial Catalog=movie;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public DataTable Movietailsall(Moviecontroller u)
        {
            string query = string.Format("Select * from info where Status='Active'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public int Addmovie(Moviecontroller u)
        {
            int i = 0;
            string query = "INSERT INTO info(Name,Seat,Time,Price,Catagory,Status) VALUES ('" + u.Name + "','" + u.Seat + "','" + u.Time + "','" + u.Price + "','" + u.Catagory + "','" + u.status + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }

        public int movieupdate(Moviecontroller u)
        {
            int i = 0;
            string query = String.Format("UPDATE info SET Name='" + u.Name + "',Seat='" + u.Seat + "',Time='" + u.Time + "',Price='" + u.Price + "',Catagory='" + u.Catagory + "',Status='" + u.Biyer + "' WHERE Name='" + u.Name + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }
        public int Delete(Moviecontroller u)
        {
            int i = 0;
            string query = String.Format("Delete from info where Sl='" + u.sl + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public int Sell(Moviecontroller u)
        {
            int i = 0;
            string query = "INSERT INTO info(Name,Seat,Time,Price,Catagory,Status) VALUES ('" + u.Name + "','" + u.Seat + "','" + u.Time + "','" + u.Price + "','" + u.Catagory + "','" + u.status + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }
    }
}
