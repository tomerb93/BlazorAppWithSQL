using BlazorAppWithSQL.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BlazorAppWithSQL.Data
{
    public class PeopleService
    {
        public Task<ProductModel[]> GetProductAsync(DateTime startDate)

        {

            ProductModel[] productModels = new ProductModel[5];

            ProductModel productModel = new ProductModel();

            int counter = 0;

            string strConn = "Server =.; Database = Northwind; Trusted_Connection = True;";

            SqlConnection conn = new SqlConnection(strConn);

            string sql = "Select TOP 5 ProductName, UnitPrice From Products";

            SqlCommand command = new SqlCommand(sql, conn);

            //opening connection and executing the query

            conn.Open();

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())

            {

                productModel = new ProductModel
                {
                    ProductName = dr[0].ToString(),

                    UnitPrice = dr[1].ToString()
                };

                productModels[counter] = productModel;

                counter++;

            }

            conn.Close();

            Task<ProductModel[]> task = Task.FromResult(productModels);

            //return personModels;

            return task;

        }
    }
}
