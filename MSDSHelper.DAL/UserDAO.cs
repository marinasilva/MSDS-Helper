using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class UserDAO : IDAO<User>
    {
        private const string _adicionar = @"INSERT INTO TbUser ([Nome],[Login],[Password])  VALUES  (@Nome, @Login, @Password)";
        private const string _delete = @"DELETE FROM USER WHERE ID = @idUser";
        private const string _update = @"UPDATE TbUser  SET [Nome] = @Nome, [Login] = @Login, [Password] = @Password WHERE idUser = @idUser";
        private const string _selectByID = @"SELECT * FROM USER WHERE IDUSER = @idUser";
        private const string _validePass = @"SELECT PASSWORD FROM TBUSER WHERE LOGIN = @login";
        private const string _selectByName = @"SELECT * FROM USER WHERE NOME LIKE '%@Nome%'";
        private const string _selectByLogin = @"SELECT * FROM USER WHERE LOGIN LIKE '%@Login%'";
        private const string _selectLast = @"SELECT TOP 1 * FROM TbUser ORDER BY idUser";
        private const string _selectIdentCurrent = @"SELECT IDENT_CURRENT('TbUser') + IDENT_INCR('TbUser') AS ID";

        public void Adicionar(User user)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_adicionar, connection))
            {
                command.Parameters.AddWithValue("@Nome", user.Nome);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_delete, connection))
            {
                command.Parameters.AddWithValue("@idUser", id);
                command.ExecuteScalar();
            }
        }

        public void Update(User user)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_update, connection))
            {
                command.Parameters.AddWithValue("@Nome", user.Nome);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@idUser", user.Id);
                command.ExecuteNonQuery();
            }
        }

        public User SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            User user;
            using (SqlCommand command = new SqlCommand(_selectByID, connection))
            {
                command.Parameters.AddWithValue("@idUser", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    user = null;
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
                }
            }
            return user;
        }

        public string ValidePass(string login)
        {
            SqlConnection connection = ContextFactory.Instancia();
            string password;//new string();
            using (SqlCommand command = new SqlCommand(_validePass, connection))
            {
                command.Parameters.AddWithValue("@login", login);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    password = string.Empty;
                    while (reader.Read())
                        password = reader["Password"].ToString();
                    reader.Close();
                }
            }
            return password;
        }

        public List<User> SelectByName(string name)
        {
            SqlConnection connection = ContextFactory.Instancia();
            List<User> userList;
            using (SqlCommand command = new SqlCommand(_selectByName, connection))
            {
                command.Parameters.AddWithValue("@Nome", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    userList = new List<User>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User _user = new User();
                            _user.Id = Convert.ToInt32(reader["idUser"]);
                            _user.Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString();
                            _user.Login = reader["Login"] == DBNull.Value ? string.Empty : reader["Login"].ToString();
                            _user.Password = reader["Password"] == DBNull.Value ? string.Empty : reader["Password"].ToString();
                            userList.Add(_user);
                        }
                    }
                }
            }
            return userList;
        }

        public List<User> SelectByLogin(string login)
        {
            SqlConnection connection = ContextFactory.Instancia();
            List<User> userList;
            using (SqlCommand command = new SqlCommand(_selectByLogin, connection))
            {
                command.Parameters.AddWithValue("@Login", login);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    userList = new List<User>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User _user = new User();
                            _user.Id = Convert.ToInt32(reader["idUser"]);
                            _user.Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString();
                            _user.Login = reader["Login"] == DBNull.Value ? string.Empty : reader["Login"].ToString();
                            _user.Password = reader["Password"] == DBNull.Value ? string.Empty : reader["Password"].ToString();
                            userList.Add(_user);
                        }
                    }
                }
            }
            return userList;
        }

        public User SelectLast()
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_selectLast, connection))
            {
                User user;
                using (var reader = command.ExecuteReader())
                {
                    user = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user = new User();
                            user.Id = Convert.ToInt32(reader["idUser"]);
                            user.Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString();
                            user.Login = reader["Login"] == DBNull.Value ? string.Empty : reader["Login"].ToString();
                            //user.Password = reader["Password"] == DBNull.Value ? string.Empty : reader["Passwrod"].ToString();
                        }
                    }
                }
                return user;
            }
        }

        public int SelectIdentCurrent()
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_selectIdentCurrent, connection))
            {
                int nextID = 0;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        nextID = reader["ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID"]);
                }
                return nextID;
            }
        }
    }
}
