using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ADO_Venta
    {
        public static void AgregarVenta(List<Producto> prod, int id)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Venta(idUsuario) VALUES(@idUsu)";

                var param = new SqlParameter();
                param.ParameterName = "idUsu";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = id;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            foreach (var p in prod)
            {
                using (SqlConnection connection = new SqlConnection(General.connectionString()))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO productoVendido(stock,idProducto,idVenta) VALUES(@stock,@idProducto,@idVenta)";

                    var paramStock = new SqlParameter();
                    paramStock.ParameterName = "stock";
                    paramStock.SqlDbType = SqlDbType.Int;
                    paramStock.Value = p.Stock;

                    var paramIdProducto = new SqlParameter();
                    paramIdProducto.ParameterName = "idProducto";
                    paramIdProducto.SqlDbType = SqlDbType.BigInt;
                    paramIdProducto.Value = p.Id;

                    var paramIdVenta = new SqlParameter();
                    paramIdVenta.ParameterName = "idVenta";
                    paramIdVenta.SqlDbType = SqlDbType.BigInt;
                    paramIdVenta.Value = ;


                    cmd.Parameters.Add(paramStock);
                    cmd.Parameters.Add(paramIdProducto);
                    cmd.Parameters.Add(paramIdVenta);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                using (SqlConnection connection = new SqlConnection(General.connectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update Producto set [stock] = stock - @stock where id = @idProd";

                    var paramStock = new SqlParameter();
                    paramStock.ParameterName = "stock";
                    paramStock.SqlDbType = SqlDbType.Int;
                    paramStock.Value = p.Stock;

                    var paramIdProducto = new SqlParameter();
                    paramIdProducto.ParameterName = "idProducto";
                    paramIdProducto.SqlDbType = SqlDbType.BigInt;
                    paramIdProducto.Value = p.Id;

                    connection.Close(); 
                }
            }


        }


    }
}
