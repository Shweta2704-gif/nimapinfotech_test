using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using nimapinfotech_test.Models;
using System.Collections.Generic;
using nimapinfotech_test.Interface;


namespace nimapinfotech_test.Repository
{
    public class catagoryrepository:ICatagoryRepository
    {
         private SqlConnection con;

       
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        // To Add Employee details
        public bool AddCatagory(Catagory obj)
        {
            connection();
            SqlCommand com = new SqlCommand("addcatagory", con);
            com.CommandType = CommandType.StoredProcedure;
           // com.Parameters.AddWithValue("@catagoryid", obj.catagoryid);
            com.Parameters.AddWithValue("@catagoryname", obj.catagoryname);
            com.Parameters.AddWithValue("@productid", obj.productid);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        public IEnumerable<Catagory> GetAllCatagory()
        {
            connection();
            List<Catagory> catagoryList = new List<Catagory>();

            SqlCommand com = new SqlCommand("getcatagory", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                catagoryList.Add(
                    new Catagory
                    {
                        catagoryid = Convert.ToInt32(dr["catagoryid"]),
                        catagoryname = Convert.ToString(dr["catagoryname"]),
                        productid = Convert.ToString(dr["productid"]),

                    }
                );
            }

            return catagoryList;
        }

        
        public bool UpdateCatagory(Catagory obj)
        {
            connection();
            SqlCommand com = new SqlCommand("updatecatagorydeatils", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", obj.catagoryid);
            com.Parameters.AddWithValue("@NewCategoryName", obj.catagoryname);
            //com.Parameters.AddWithValue("@NewProductId", obj.productid);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deletecatagory(int? Id)
        {
            connection();
            SqlCommand com = new SqlCommand("deletecatagory", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
    }
}