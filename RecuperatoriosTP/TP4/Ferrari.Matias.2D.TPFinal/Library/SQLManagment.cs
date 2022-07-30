using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public static class SQLManagment
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static SQLManagment()
        {
            connectionString = "Data Source=.;Initial Catalog=TP4_DB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }
        /// <summary>
        /// Inserta un cliente en la base de datos
        /// </summary>
        /// <param name="cliente"></param>
        public static bool Insertar(Cliente cliente)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = "INSERT INTO CLIENTES VALUES (@Nombre,@Apellido,@DNI,@Telefono,@Clases,@Turno)";
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@DNI", cliente.Dni);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Clases", cliente.Clases.ToString());
                command.Parameters.AddWithValue("@Turno", cliente.Horarios.ToString());
                
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Trae todos los datos de la base de datos y los agrega a la lista de clientes
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> Leer()
        {
            List<Cliente> listaCliente = new List<Cliente>();
            try
            {
                connection.Open();
                command.CommandText = $"SELECT * FROM CLIENTES";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listaCliente.Add(new Cliente(Convert.ToInt32(dataReader["ID"]),dataReader["Nombre"].ToString(), dataReader["Apellido"].ToString(), Convert.ToInt64(dataReader["DNI"]), Convert.ToInt64(dataReader["Telefono"]), 
                            (EClases)Enum.Parse(typeof(EClases),dataReader["Clases"].ToString()), (EHorarios)Enum.Parse(typeof(EHorarios),dataReader["Turno"].ToString()) ));
                    }
                    Negocio.Clientes = new List<Cliente>(listaCliente);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return Negocio.Clientes;
        }
        /// <summary>
        /// Elimina un cliente que coincida con el id pasado por parametro
        /// </summary>
        /// <param name="idCliente"></param>
        public static void EliminarCliente(int idCliente)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "DELETE FROM CLIENTES WHERE ID = @Id";
                command.Parameters.AddWithValue("@Id",idCliente);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Modifica uno o varios campos de un cliente
        /// </summary>
        /// <param name="cliente"></param>
        public static void ModificarCliente(Cliente cliente)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "UPDATE CLIENTES SET Nombre=@Nombre, Apellido=@Apellido, DNI=@Dni, Telefono=@Telefono," +
                    "Clases=@Clases,Turno=@Turno WHERE ID=@Id";
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@DNI", cliente.Dni);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Clases", cliente.Clases.ToString());
                command.Parameters.AddWithValue("@Turno", cliente.Horarios.ToString());

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
