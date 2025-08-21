using Dapper;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace WaterLifeMVC.Models
{
    public class CrudModel
    {
        private readonly string ConnectionString = "User ID=root;Password=abc123;Host=localhost;Port=5432;Database=WaterLifeDB;";

        public ProductModel GetProduct(string name)
        {
            string query = "SELECT COUNT(1) FROM produto WHERE name = @name";
            IDbConnection con;
            con = new NpgsqlConnection(ConnectionString);
            con.Open();
            return con.QueryFirstOrDefault<ProductModel>(query, new { name });
        }

        public void createProduct(ProductModel produto)
        {
            string query = "INSERT INTO produto(name, image, description, price, stock, discount) VALUES (@name, @image, @description, @price, @stock, @discount)";
            IDbConnection con;
            con = new NpgsqlConnection(ConnectionString);
            con.Open();
            con.Execute(query, produto);
            con.Close();
        }
    }
}
