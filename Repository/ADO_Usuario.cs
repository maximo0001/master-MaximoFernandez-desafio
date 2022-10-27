
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;


namespace WebApplication1.Repository
{
    public class ADO_Usuario
    {
        public static List<Usuario> TraerUsuarios()
        {
            var listaUsuarios = new List<Usuario>();



            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario";


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usu = new Usuario();
                    usu.Id = Convert.ToInt32(reader.GetValue(0));
                    usu.Nombre = reader.GetValue(1).ToString();
                    usu.Apellido = reader.GetValue(2).ToString();
                    usu.NombreUsuario = reader.GetValue(3).ToString();
                    usu.Contraseña = reader.GetValue(4).ToString();
                    usu.Mail = reader.GetValue(5).ToString();

                    listaUsuarios.Add(usu);
                }

                reader.Close();
                connection.Close();

                foreach (var u in listaUsuarios)
                {
                    Console.WriteLine(u.Id);
                    Console.WriteLine(u.Nombre);
                    Console.WriteLine(u.Apellido);
                    Console.WriteLine(u.NombreUsuario);
                    Console.WriteLine(u.Contraseña);
                    Console.WriteLine(u.Mail);
                    Console.WriteLine("---------------");
                }
            }
            return listaUsuarios;
        }

        public static void EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE usuario WHERE id = @idUsuario";

                var param = new SqlParameter();
                param.ParameterName = "idUsuario";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = id;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public static void ModificarUsuario(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Usuario "+
                    "SET [Nombre] = @nombre, [Apellido] = @apellido, [NombreUsuario] = @nombreUsu, [Contraseña] = @contraseña, [Mail] = @mail"+
                    " WHERE id = @idUsu";

                var paramId = new SqlParameter();
                paramId.ParameterName = "idUsu";
                paramId.SqlDbType = SqlDbType.BigInt;
                paramId.Value = usu.Id;

                var paramNombre = new SqlParameter();
                paramNombre.ParameterName = "nombre";
                paramNombre.SqlDbType = SqlDbType.VarChar;
                paramNombre.Value = usu.Nombre;

                var paramApellido = new SqlParameter();
                paramApellido.ParameterName = "apellido";
                paramApellido.SqlDbType = SqlDbType.VarChar;
                paramApellido.Value = usu.Apellido;

                var paramNombreUsuario = new SqlParameter();
                paramNombreUsuario.ParameterName = "nombreUsu";
                paramNombreUsuario.SqlDbType = SqlDbType.VarChar;
                paramNombreUsuario.Value = usu.NombreUsuario;

                var paramContraseña = new SqlParameter();
                paramContraseña.ParameterName = "contraseña";
                paramContraseña.SqlDbType = SqlDbType.VarChar;
                paramContraseña.Value = usu.Contraseña;

                var paramMail = new SqlParameter();
                paramMail.ParameterName = "mail";
                paramMail.SqlDbType = SqlDbType.VarChar;
                paramMail.Value = usu.Mail;

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNombre);
                cmd.Parameters.Add(paramApellido);
                cmd.Parameters.Add(paramNombreUsuario);
                cmd.Parameters.Add(paramContraseña);
                cmd.Parameters.Add(paramMail);

                cmd.ExecuteNonQuery();
                connection.Close();

            }

        }

        internal static void AgregarUsuario(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                        "VALUES (@nombre, @apellido, @nombreUsu, @contraseña, @mail)";


                var paramNombre = new SqlParameter();
                paramNombre.ParameterName = "nombre";
                paramNombre.SqlDbType = SqlDbType.VarChar;
                paramNombre.Value = usu.Nombre;

                var paramApellido = new SqlParameter();
                paramApellido.ParameterName = "apellido";
                paramApellido.SqlDbType = SqlDbType.VarChar;
                paramApellido.Value = usu.Apellido;

                var paramNombreUsuario = new SqlParameter();
                paramNombreUsuario.ParameterName = "nombreUsu";
                paramNombreUsuario.SqlDbType = SqlDbType.VarChar;
                paramNombreUsuario.Value = usu.NombreUsuario;

                var paramContraseña = new SqlParameter();
                paramContraseña.ParameterName = "contraseña";
                paramContraseña.SqlDbType = SqlDbType.VarChar;
                paramContraseña.Value = usu.Contraseña;

                var paramMail = new SqlParameter();
                paramMail.ParameterName = "mail";
                paramMail.SqlDbType = SqlDbType.VarChar;
                paramMail.Value = usu.Mail;

                
                cmd.Parameters.Add(paramNombre);
                cmd.Parameters.Add(paramApellido);
                cmd.Parameters.Add(paramNombreUsuario);
                cmd.Parameters.Add(paramContraseña);
                cmd.Parameters.Add(paramMail);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
