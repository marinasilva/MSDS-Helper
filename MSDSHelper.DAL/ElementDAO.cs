using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class ElementDAO : IDAO<Element>
    {

        private const string _adicionar = @"INSERT  INTO Element ([NomeProduto],[FormulaMolecular],[PesoMolecular],[Unidade],[Fabricante],[Descricao])
                                                    VALUES
                                                                 (@nomeProduto,@formulaMolecular,@pesoMolecular,@unidade,@fabricante,@descricao)";
        private const string _delete = @"DELETE FROM ELEMENT WHERE ID = @idElement";
        private const string _update = @"";
        private const string _selectByID = @"SELECT * FROM ELEMENT WHERE ID = @idElement";
        private const string _selectByName = @"SELECT * FROM ELEMENT WHERE NOMEPRODUTO LIKE '%@nomeProduto%'";
        private const string _selectByFormula = @"SELECT * FROM ELEMENT WHERE FORMULAMOLECULAR LIKE '%@formulaMolecular%'";


        public void Adicionar(Element element)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_adicionar, connection);
            command.Parameters.AddWithValue("@nomeProduto", element.NomeProduto);
            command.Parameters.AddWithValue("@formulaMolecular", element.FormulaMolecular);
            command.Parameters.AddWithValue("@pesoMolecular", element.PesoMolecular);
            command.Parameters.AddWithValue("@unidade", element.Unidade);
            command.Parameters.AddWithValue("@fabricante", element.Fabricante);
            command.Parameters.AddWithValue("@descricao", element.Descricao);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_delete, connection);
            command.Parameters.AddWithValue("@idElement", id);
            command.ExecuteScalar();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public Element SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_selectByID, connection);
            command.Parameters.AddWithValue("@idElement", id);
            SqlDataReader reader = command.ExecuteReader();
            Element element = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    element = new Element();
                    element.Id = id;
                    element.NomeProduto = reader["NomeProduto"] == DBNull.Value
                        ? string.Empty
                        : reader["NomeProduto"].ToString();
                    element.Fabricante = reader["Fabricante"] == DBNull.Value
                        ? string.Empty
                        : reader["Fabricante"].ToString();
                    element.FormulaMolecular = reader["FormulaMolecular"] == DBNull.Value
                        ? string.Empty
                        : reader["FormulaMolecular"].ToString();
                    element.Descricao = reader["Descricao"] == DBNull.Value
                        ? string.Empty
                        : reader["Descricao"].ToString();
                    element.PesoMolecular = reader["PesoMolecular"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(reader["PesoMolecular"]);
                    element.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                    element.Danger.Id = reader["idDanger"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idDanger"]);
                }
            }
            return element;
        }

        public List<Element> SelectByName(string name)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_selectByName, connection);
            command.Parameters.AddWithValue("@nomeProduto", name);
            SqlDataReader reader = command.ExecuteReader();
            List<Element> elementList = new List<Element>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Element _element = new Element();
                    _element.Id = Convert.ToInt32(reader["idElement"]);
                    _element.NomeProduto = reader["NomeProduto"].ToString();
                    _element.FormulaMolecular = reader["FormulaMolecular"] == DBNull.Value
                        ? string.Empty
                        : reader["FormularMolecular"].ToString();
                    _element.Descricao = reader["Descricao"] == DBNull.Value
                        ? string.Empty
                        : reader["Descricao"].ToString();
                    _element.PesoMolecular = reader["PesoMolecular"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(reader["PesoMolecular"]);
                    _element.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                    _element.Danger.Id = reader["idDanger"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idDanger"]);
                    elementList.Add(_element);
                }
            }
            return elementList;
        }

        public List<Element> SelectByFormula(string formula)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_selectByFormula, connection);
            command.Parameters.AddWithValue("@formulaMolecular", formula);
            SqlDataReader reader = command.ExecuteReader();
            List<Element> elementList = new List<Element>();
            if (reader.HasRows)
            {
                while (reader.HasRows)
                {
                    Element _element = new Element();
                    _element.Id = Convert.ToInt32(reader["idElement"]);
                    _element.NomeProduto = reader["NomeProduto"] == DBNull.Value
                        ? string.Empty
                        : reader["NomeProduto"].ToString();
                    _element.FormulaMolecular = reader["FormulaMolecular"] == DBNull.Value
                        ? string.Empty
                        : reader["FormularMolecular"].ToString();
                    _element.Descricao = reader["Descricao"] == DBNull.Value
                        ? string.Empty
                        : reader["Descricao"].ToString();
                    _element.PesoMolecular = reader["PesoMolecular"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(reader["PesoMolecular"]);
                    _element.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                    _element.Danger.Id = reader["idDanger"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idDanger"]);
                    elementList.Add(_element);
                }
            }
            return elementList;
        }
    }
}
