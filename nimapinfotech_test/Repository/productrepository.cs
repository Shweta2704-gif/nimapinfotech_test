using nimapinfotech_test.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace nimapinfotech_test.Repository
{
    public class productrepository
    {
        private SqlConnection con;


        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        // To Add Employee details
        public bool Addproduct(Product obj)
        {
            connection();
            SqlCommand com = new SqlCommand("Addproduct", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@catagoryid", obj.catagoryid);
            //com.Parameters.AddWithValue("@catagoryname", obj.catagoryname);
            com.Parameters.AddWithValue("@productname", obj.productname);
            
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


        public List<Product> GetAllProduct()
        {
            connection();
            List<Product> productList = new List<Product>();

            SqlCommand com = new SqlCommand("getproduct", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                productList.Add(
                    new Product
                    {
                       productid = Convert.ToInt32(dr["productid"]),
                        productname = Convert.ToString(dr["productname"]),
                        catagoryid = Convert.ToInt32(dr["catagoryid"]),
                        catagoryname = Convert.ToString(dr["catagoryname"])

                    }
                );
            }

            return productList;
        }


        public bool UpdateProduct(Product obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", obj.productid);
            com.Parameters.AddWithValue("@NewProductName", obj.productname);
            //com.Parameters.AddWithValue("@catagoryid", obj.catagoryid);
            //com.Parameters.AddWithValue("@catagoryname", obj.catagoryname);

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

        public bool Deleteproduct(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", Id);

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
