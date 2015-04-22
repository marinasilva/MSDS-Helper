using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class UserDAO : IDAO<User>
    {
        private const string _adicionar = @"";
        private const string _delete = @"DELETE FROM USER WHERE ID = @idUser";
        private const string _update = @"";
        private const string _selectByID = @"SELECT * FROM USER WHERE ID = @idUser";
        private const string _validePass = @"SELECT PASSWORD FROM TBUSER WHERE LOGIN = @login";
        private const string _getPermission = @"SELECT PERMISSAO FROM TBUSER WHERE LOGIN = @login";

        public void Adicionar(User missing_name)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_delete, connection);
            command.Parameters.AddWithValue("@idUser", id);
            command.ExecuteScalar();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public User SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_selectByID, connection);
            command.Parameters.AddWithValue("@idUser", id);
            SqlDataReader reader = command.ExecuteReader();
            User user = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = new User();
                    user.Id = id;
                    user.Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString();
                    user.Login = reader["Login"] == DBNull.Value ? string.Empty : reader["Login"].ToString();
                    user.Password = reader["Password"] == DBNull.Value ? string.Empty : reader["Passwrod"].ToString();
                }
            }
            return user;
        }

        public string ValidePass(string login)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand( _validePass, connection);
            command.Parameters.AddWithValue("@login", login);
            SqlDataReader reader = command.ExecuteReader();
            string password = string.Empty;//new string();
            while (reader.Read())
                password = reader["Password"].ToString();
            reader.Close();return password;
        }

        public int GetPermission(string login)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_getPermission, connection);
            command.Parameters.AddWithValue("@login", login);
            SqlDataReader reader = command.ExecuteReader();
            int permission = 2;
            while (reader.Read())
                permission = Convert.ToInt32(reader["Permissao"]);
            reader.Close();
            return permission;
        }
    }
}
