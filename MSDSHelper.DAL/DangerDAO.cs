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
        private const string _adicionar = @"INSERT  INTO Danger ([Inalacao],[ContatoOlhos],[ContatoPele],[Ingestao])
                                                    VALUES      (@inalacao, @olhos, @pele, @ingestao)";
        
        public void Adicionar(Danger danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_adicionar, connection);
            command.Parameters.AddWithValue("@inalacao", danger.Inalacao);
            command.Parameters.AddWithValue("@olhos", danger.ContatoOlhos);
            command.Parameters.AddWithValue("@pele", danger.ContatoPele);
            command.Parameters.AddWithValue("@ingestao", danger.Ingestao);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public Danger SelectByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
