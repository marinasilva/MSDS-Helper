using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class UserDao : IDao<User>
    {
        private const string ADICIONAR = @"INSERT INTO TbUser ([Nome],[Login],[Password])  VALUES  (@Nome, @Login, @Password)";
        private const string DELETE = @"DELETE FROM TbUser WHERE ID = @idUser";
        private const string UPDATE = @"UPDATE TbUser  SET [Nome] = @Nome, [Login] = @Login, [Password] = @Password WHERE idUser = @idUser";
        private const string SELECT_BY_ID = @"SELECT * FROM TbUser WHERE IDUSER = @idUser";
        private const string VALIDE_PASS = @"SELECT PASSWORD FROM TBUSER WHERE LOGIN = @login";
        private const string SELECT_BY_NAME = @"SELECT * FROM TbUser WHERE NOME LIKE @Nome";
        private const string SELECT_BY_LOGIN = @"SELECT * FROM TbUser WHERE LOGIN LIKE @Login";
        private const string SELECT_LAST = @"SELECT TOP 1 * FROM TbUser ORDER BY idUser";
        private const string SELECT_IDENT_CURRENT = @"SELECT IDENT_CURRENT('TbUser') + IDENT_INCR('TbUser') AS ID";
        private const string SELECT_ALL = "SELECT * FROM TbUser";

        public void Adicionar(User user)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(ADICIONAR, connection))
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
            using (SqlCommand command = new SqlCommand(DELETE, connection))
            {
                command.Parameters.AddWithValue("@idUser", id);
                command.ExecuteScalar();
            }
        }

        public void Update(User danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(UPDATE, connection))
            {
                command.Parameters.AddWithValue("@Nome", danger.Nome);
                command.Parameters.AddWithValue("@Login", danger.Login);
                command.Parameters.AddWithValue("@Password", danger.Password);
                command.Parameters.AddWithValue("@idUser", danger.Id);
                command.ExecuteNonQuery();
            }
        }

        public User SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            User user;
            using (SqlCommand command = new SqlCommand(SELECT_BY_ID, connection))
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
                            //user.Password = reader["Password"] == DBNull.Value ? string.Empty : reader["Passwrod"].ToString();
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
            using (SqlCommand command = new SqlCommand(VALIDE_PASS, connection))
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
            using (SqlCommand command = new SqlCommand(SELECT_BY_NAME, connection))
            {
                command.Parameters.AddWithValue("@Nome", "%" + name + "%");
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    userList = new List<User>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User user = new User();
                            user.Id = Convert.ToInt32(reader["idUser"]);
                            user.Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString();
                            user.Login = reader["Login"] == DBNull.Value ? string.Empty : reader["Login"].ToString();
                            user.Password = reader["Password"] == DBNull.Value ? string.Empty : reader["Password"].ToString();
                            userList.Add(user);
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
            using (SqlCommand command = new SqlCommand(SELECT_BY_LOGIN, connection))
            {
                command.Parameters.AddWithValue("@Login", "%" + login + "%");
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    userList = new List<User>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User user = new User();
                            user.Id = Convert.ToInt32(reader["idUser"]);
                            user.Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString();
                            user.Login = reader["Login"] == DBNull.Value ? string.Empty : reader["Login"].ToString();
                            user.Password = reader["Password"] == DBNull.Value ? string.Empty : reader["Password"].ToString();
                            userList.Add(user);
                        }
                    }
                }
            }
            return userList;
        }

        public User SelectLast()
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(SELECT_LAST, connection))
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
            using (SqlCommand command = new SqlCommand(SELECT_IDENT_CURRENT, connection))
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

        public List<User> SelectAll()
        {
            SqlConnection connection = ContextFactory.Instancia();
            List<User> userList;
            using (SqlCommand command = new SqlCommand(SELECT_ALL, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    userList = new List<User>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User user = new User();
                            user.Id = Convert.ToInt32(reader["idUser"]);
                            user.Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString();
                            user.Login = reader["Login"] == DBNull.Value ? string.Empty : reader["Login"].ToString();
                            user.Password = reader["Password"] == DBNull.Value ? string.Empty : reader["Password"].ToString();
                            userList.Add(user);
                        }
                    }
                }
            }
            return userList;
        }
    }
}