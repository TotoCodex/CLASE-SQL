using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_4__GitB_.DB
{
    internal class DB
    {
        public static MySqlConnection mysqlConnection;
        public static MySqlCommand mysqlCommand;

        static DB() 
        {
            var mysqlStringConnection = @"Server=localhost;Database=utn;Uid=root;Pwd=;";
            mysqlConnection = new MySqlConnection(mysqlStringConnection);
            
            mysqlCommand = new MySqlCommand(mysqlStringConnection);
            mysqlCommand.CommandType = System.Data.CommandType.Text;//el tipo de comando que envio (texto)
            mysqlCommand.Connection = mysqlConnection;// envio la consulta
        
        }
        public static void Select() 
        {
            try 
            {
                mysqlConnection.Open();
                var query = "SELECT * FROM alumnos";
                
                mysqlCommand.CommandText = query;

                using(var reader = mysqlCommand.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                    var nombre = reader["nombre"].ToString() ?? "";
                    var id = Convert.ToInt32(reader["id"].ToString());
                    Console.WriteLine($"ID: {id} - Nombre: {nombre}" );
                    }
                }
                
            }
            catch(Exception) 
            {

                throw;
            
            
            } finally 
            { 
                mysqlConnection.Close(); 
            }
        
        
        
        }
        public static void Insert(string nombre) 
        {
            try 
            { 
                mysqlConnection.Open();
                var query = $"INSERT INTO alumnos (apellido,nombre,telefono,ciudad,a) VALUES ('{nombre}' , 's', 11, 'string', 55 )";

                mysqlCommand.Parameters.AddWithValue("@nombre", nombre);
                mysqlCommand.CommandText = query;
                mysqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }finally { mysqlConnection.Close(); }   
            
            
            
           

        }
        public static void OpenConection()
        {
            mysqlConnection.Open();
            
            
            
            mysqlConnection.Close();

        }
    }
}
