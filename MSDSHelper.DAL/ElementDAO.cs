using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class ElementDao : IDao<Element>
    {

        private const string _adicionar = @"INSERT  INTO Element ([NomeProduto],[FormulaMolecular],[PesoMolecular],[Unidade],[Fabricante],[Descricao])
                                                    VALUES
                                                                 (@nomeProduto,@formulaMolecular,@pesoMolecular,@unidade,@fabricante,@descricao)";
        private const string _delete = @"DELETE FROM ELEMENT WHERE IDELEMENT = @idElement";
        private const string _update = @"UPDATE Element SET [NomeProduto] = @nomeProduto, [FormulaMolecular] = @formulaMolecular, [PesoMolecular] = @pesoMolecular,
                                                            [Unidade] = @unidade, [Fabricante] = @fabricante, [Descricao] = @descricao
                                         WHERE idElement = @idElement";
        private const string _selectByID = @"SELECT * FROM ELEMENT WHERE IDELEMENT = @idElement";
        private const string _selectByName = @"SELECT * FROM ELEMENT WHERE NOMEPRODUTO LIKE '%@nomeProduto%'";
        private const string _selectByFormula = @"SELECT * FROM ELEMENT WHERE FORMULAMOLECULAR LIKE '%@formulaMolecular%'";
        private const string _selectLast = @"SELECT TOP 1 FROM ELEMENT ORDER BY IDELEMENT";
        private const string _selectByFabricante = @"SELECT * FROM ELEMENT WHERE FABRICANTE LIKE '%@fabricante%'";
        private const string _selectCount = @"SELECT COUNT(IDELEMENT) FROM ELEMENT";
        

        public void Adicionar(Element element)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_adicionar, connection))
            {
                command.Parameters.AddWithValue("@nomeProduto", element.NomeProduto);
                command.Parameters.AddWithValue("@formulaMolecular", element.FormulaMolecular);
                command.Parameters.AddWithValue("@pesoMolecular", element.PesoMolecular);
                command.Parameters.AddWithValue("@unidade", element.Unidade);
                command.Parameters.AddWithValue("@fabricante", element.Fabricante);
                command.Parameters.AddWithValue("@descricao", element.Descricao);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_delete, connection))
            {
                command.Parameters.AddWithValue("@idElement", id);
                command.ExecuteScalar();
            }
        }

        public void Update(Element danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_update, connection);

        }

        public Element SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            Element element;
            using (SqlCommand command = new SqlCommand(_selectByID, connection))
            {
                command.Parameters.AddWithValue("@idElement", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    element = null;
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
                }
            }
            return element;
        }

        public List<Element> SelectByName(string name)
        {
            SqlConnection connection = ContextFactory.Instancia();
            List<Element> elementList;
            using (SqlCommand command = new SqlCommand(_selectByName, connection))
            {
                command.Parameters.AddWithValue("@nomeProduto", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    elementList = new List<Element>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Element element = new Element();
                            element.Id = Convert.ToInt32(reader["idElement"]);
                            element.NomeProduto = reader["NomeProduto"].ToString();
                            element.FormulaMolecular = reader["FormulaMolecular"] == DBNull.Value
                                ? string.Empty
                                : reader["FormularMolecular"].ToString();
                            element.Descricao = reader["Descricao"] == DBNull.Value
                                ? string.Empty
                                : reader["Descricao"].ToString();
                            element.PesoMolecular = reader["PesoMolecular"] == DBNull.Value
                                ? 0
                                : Convert.ToInt32(reader["PesoMolecular"]);
                            element.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                            element.Danger.Id = reader["idDanger"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idDanger"]);
                            elementList.Add(element);
                        }
                    }
                }
            }
            return elementList;
        }

        public List<Element> SelectByFormula(string formula)
        {
            SqlConnection connection = ContextFactory.Instancia();
            List<Element> elementList;
            using (SqlCommand command = new SqlCommand(_selectByFormula, connection))
            {
                command.Parameters.AddWithValue("@formulaMolecular", formula);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    elementList = new List<Element>();
                    if (reader.HasRows)
                    {
                        while (reader.HasRows)
                        {
                            Element element = new Element();
                            element.Id = Convert.ToInt32(reader["idElement"]);
                            element.NomeProduto = reader["NomeProduto"] == DBNull.Value
                                ? string.Empty
                                : reader["NomeProduto"].ToString();
                            element.FormulaMolecular = reader["FormulaMolecular"] == DBNull.Value
                                ? string.Empty
                                : reader["FormularMolecular"].ToString();
                            element.Descricao = reader["Descricao"] == DBNull.Value
                                ? string.Empty
                                : reader["Descricao"].ToString();
                            element.PesoMolecular = reader["PesoMolecular"] == DBNull.Value
                                ? 0
                                : Convert.ToInt32(reader["PesoMolecular"]);
                            element.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                            element.Danger.Id = reader["idDanger"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idDanger"]);
                            elementList.Add(element);
                        }
                    }
                }
            }
            return elementList;
        }

        public Element SelectLast()
        {
            SqlConnection connection = ContextFactory.Instancia();
            Element element;
            using (SqlCommand command = new SqlCommand(_selectLast, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    element = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            element = new Element();
                            element.Id = Convert.ToInt32(reader["idElement"]);
                            element.Descricao = reader["Descricao"] == DBNull.Value
                                ? string.Empty
                                : reader["Descricao"].ToString();
                            element.Fabricante = reader["Fabricante"] == DBNull.Value
                                ? string.Empty
                                : reader["Fabricante"].ToString();
                            element.FormulaMolecular = reader["FormulaMolecular"] == DBNull.Value
                                ? string.Empty
                                : reader["FormulaMolecular"].ToString();
                            element.NomeProduto = reader["NomeProduto"] == DBNull.Value
                                ? string.Empty : reader["NomeProduto"].ToString();
                            element.PesoMolecular = reader["PesoMolecular"] == DBNull.Value
                                ? 0
                                : Convert.ToInt32(reader["PesoMolecular"]);
                            element.Danger.Id = reader["idDanger"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idDanger"]);
                            element.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                        }
                    }
                }
            }
            return element;
        }

        public List<Element> SelectByFabricante(string fabricante)
        {
            SqlConnection connection = ContextFactory.Instancia();
            List<Element> elementList;
            using (SqlCommand command = new SqlCommand(_selectByFabricante, connection))
            {
                command.Parameters.AddWithValue("@fabricante", fabricante);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    elementList = new List<Element>();
                    Element element = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            element = new Element();
                            element.Id = Convert.ToInt32(reader["idElement"]);
                            element.Descricao = reader["Descricao"] == DBNull.Value
                                ? string.Empty
                                : reader["Descricao"].ToString();
                            element.Fabricante = reader["Fabricante"] == DBNull.Value
                                ? string.Empty
                                : reader["Fabricante"].ToString();
                            element.FormulaMolecular = reader["FormulaMolecular"] == DBNull.Value
                                ? string.Empty
                                : reader["FormulaMolecular"].ToString();
                            element.NomeProduto = reader["NomeProduto"] == DBNull.Value
                                ? string.Empty
                                : reader["NomeProduto"].ToString();
                            element.PesoMolecular = reader["PesoMolecular"] == DBNull.Value
                                ? 0
                                : Convert.ToInt32(reader["PesoMolecular"]);
                            element.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                            element.Danger.Id = reader["idDanger"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idDanger"]);

                            elementList.Add(element);
                        }
                    }
                }
            }
            return elementList;
        }

        public int SelectCount()
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_selectCount, connection))
            {
                return Convert.ToInt32(command.ExecuteNonQuery());
            }
        }
    }
}
