using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class DangerDAO : IDAO<Danger>
    {
        private const string _adicionar = @"INSERT  INTO Danger ([Inalacao],[ContatoOlhos],[ContatoPele],[Ingestao],[Descricao])
                                                    VALUES      (@inalacao, @olhos, @pele, @ingestao, @descricao)";
        private const string _selectLast = @"SELECT TOP 1 FROM DANGER ORDER BY IDDANGER";
        private const string _update = @"UPDATE Danger SET [Inalacao] = @inalacao, [ContatoOlhos] = @olhos, [ContatoPele] = @pele, [Ingestao] = @ingestao, [Descricao] = @descricao
                                         WHERE idDanger = @idDanger";
        private const string _selectByID = @"SELECT * FROM DANGER WHERE IDDANGER = @idDanger";
        private const string _delete = @"DELETE FROM DANGER WHERE IDDANGER = @idDanger";

        public void Adicionar(Danger danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_adicionar, connection);
            command.Parameters.AddWithValue("@inalacao", danger.Inalacao);
            command.Parameters.AddWithValue("@olhos", danger.ContatoOlhos);
            command.Parameters.AddWithValue("@pele", danger.ContatoPele);
            command.Parameters.AddWithValue("@ingestao", danger.Ingestao);
            command.Parameters.AddWithValue("@descricao", danger.Descricao);
            command.ExecuteNonQuery();
        }

        public Danger SelectLast()
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_selectLast, connection);
            SqlDataReader reader = command.ExecuteReader();
            Danger _danger = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _danger = new Danger();
                    _danger.Id = Convert.ToInt32(reader["idDanger"]);
                    _danger.ContatoOlhos = reader["ContatoOlhos"].ToString();
                    _danger.ContatoPele = reader["ContatoPele"].ToString();
                    _danger.Inalacao = reader["Inalacao"].ToString();
                    _danger.Ingestao = reader["Ingestao"].ToString();
                    _danger.Incendio.Id = Convert.ToInt32(reader["idIncendio"]);
                    _danger.Descricao = reader["Descricao"].ToString();
                }
            }
            return _danger;
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_delete, connection);
            command.Parameters.AddWithValue("@idDanger", id);
            command.ExecuteNonQuery();
        }

        public void Update(Danger _danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_update, connection);
            command.Parameters.AddWithValue("@idDanger", _danger.Id);
            command.Parameters.AddWithValue("@inalacao", _danger.Inalacao);
            command.Parameters.AddWithValue("@olhos", _danger.ContatoOlhos);
            command.Parameters.AddWithValue("@pele", _danger.ContatoPele);
            command.Parameters.AddWithValue("@ingestao", _danger.Ingestao);
            command.Parameters.AddWithValue("@descricao", _danger.Descricao);
            command.ExecuteNonQuery();
        }

        public Danger SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_selectByID, connection);
            command.Parameters.AddWithValue("@idDanger", id);
            SqlDataReader reader = command.ExecuteReader();
            Danger _danger = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _danger = new Danger();
                    _danger.Id = Convert.ToInt32(reader["idDanger"]);
                    _danger.ContatoOlhos = reader["ContatoOlhos"] == DBNull.Value
                        ? string.Empty
                        : reader["ContatoOlhos"].ToString();
                    _danger.ContatoPele = reader["ContatoPele"] == DBNull.Value
                        ? string.Empty
                        : reader["ContatoPele"].ToString();
                    _danger.Inalacao = reader["Inalacao"] == DBNull.Value ? string.Empty : reader["Inalacao"].ToString();
                    _danger.Incendio.Id = reader["idIncendio"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(reader["idIncendio"]);
                    _danger.Ingestao = reader["Ingestao"] == DBNull.Value ? string.Empty : reader["Ingestao"].ToString();
                }
            }
            return _danger;  
        }
    }
}
