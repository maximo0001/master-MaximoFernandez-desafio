using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ADO_Venta
    {
        public static void AgregarVenta(Venta ven)
        {
            int idInsertado;
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Venta(comentarios,idUsuario) VALUES(@com,@idUsu) " +
                   "select @@IDENTITY";

                var paramCom = new SqlParameter();
                paramCom.ParameterName = "com";
                paramCom.SqlDbType = SqlDbType.VarChar;
                paramCom.Value = ven.Comentarios;

                var param = new SqlParameter();
                param.ParameterName = "idUsu";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = ven.IdUsuario;
                
                cmd.Parameters.Add(paramCom);
                cmd.Parameters.Add(param);
                
                idInsertado = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }

            foreach (var p in ven.Productos)
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
                    paramIdVenta.Value = idInsertado;

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
                    paramIdProducto.ParameterName = "idProd";
                    paramIdProducto.SqlDbType = SqlDbType.BigInt;
                    paramIdProducto.Value = p.Id;

                    cmd.Parameters.Add(paramIdProducto);
                    cmd.Parameters.Add(paramStock);

                    cmd.ExecuteNonQuery();
                    connection.Close(); 
                }
            }


        }


    }
}
