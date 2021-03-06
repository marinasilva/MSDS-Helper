﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MSDSHelper.BLL;
using MSDSHelper.Model;

namespace MSDSHelper.UI
{
    public partial class FichaForm : Form
    {
        readonly ElementService _elementBLL = new ElementService();
        readonly Element _element = new Element();
        readonly UnitService _unitService = new UnitService();
        private const string APP_NAME = "MSDS Helper";

        public FichaForm(string type, int idElement, bool first)
        {
            InitializeComponent();
            _element = _elementBLL.SelectByID(idElement);
            FormatComponents(type, _element);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        public FichaForm(string type, bool first)
        {
            InitializeComponent();
            if (!first)
                _element = _elementBLL.SelectLast();
            else
                _element.Id = 0;
            FormatComponents(type, _element);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void FormatComponents(string type, Element element)
        {
            LoadUnitCombo();
            switch (type)
            {
                case "view":
                    {
                        lblType.Text = "Visualização";
                        txtCod.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = false;
                        txtFabricante.Enabled = false;
                        txtFormulaMolecular.Enabled = false;
                        txtIDPerigo.Enabled = false;
                        txtInalacao.Enabled = false;
                        txtIngestao.Enabled = false;
                        txtMeioApropriado.Enabled = false;
                        txtNomeProduto.Enabled = false;
                        txtOlhos.Enabled = false;
                        txtPele.Enabled = false;
                        btnCadastrar.Visible = false;
                        //btnUpdate.Visible = false;

                        int id = element.Id + 1;
                        txtCod.Text = id.ToString();
                        txtDescricao.Text = element.Descricao;
                        txtFabricante.Text = element.Fabricante;
                        txtFormulaMolecular.Text = element.FormulaMolecular;
                        txtIDPerigo.Text = element.Danger.Descricao;
                        txtInalacao.Text = element.Danger.Inalacao;
                        txtIngestao.Text = element.Danger.Ingestao;
                        txtMeioApropriado.Text = element.Danger.Incendio.MeioApropriado;
                        txtNomeProduto.Text = element.Danger.Incendio.PerigoEspecifico;
                        lblIncendio.Text = element.Danger.Incendio.Id.ToString();
                        lblPerigo.Text = element.Danger.Id.ToString();

                        break;
                    }
                case "update":
                    {
                        lblType.Text = "Atualização";
                        txtCod.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = true;
                        txtFabricante.Enabled = true;
                        txtFormulaMolecular.Enabled = true;
                        txtIDPerigo.Enabled = true;
                        txtInalacao.Enabled = true;
                        txtIngestao.Enabled = true;
                        txtMeioApropriado.Enabled = true;
                        txtNomeProduto.Enabled = true;
                        txtOlhos.Enabled = true;
                        txtPele.Enabled = true;
                        btnCadastrar.Visible = false;
                        //btnUpdate.Visible = true;

                        txtDescricao.Text = element.Descricao;
                        txtFabricante.Text = element.Fabricante;
                        txtFormulaMolecular.Text = element.FormulaMolecular;
                        txtIDPerigo.Text = element.Danger.Descricao;
                        txtInalacao.Text = element.Danger.Inalacao;
                        txtIngestao.Text = element.Danger.Ingestao;
                        txtMeioApropriado.Text = element.Danger.Incendio.MeioApropriado;
                        txtNomeProduto.Text = element.Danger.Incendio.PerigoEspecifico;
                        lblIncendio.Text = element.Danger.Incendio.Id.ToString();
                        lblPerigo.Text = element.Danger.Id.ToString();
                        break;
                    }
                case "create":
                    {
                        lblType.Text = "Cadastro";
                        txtCod.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = true;
                        txtFabricante.Enabled = true;
                        txtFormulaMolecular.Enabled = true;
                        txtIDPerigo.Enabled = true;
                        txtInalacao.Enabled = true;
                        txtIngestao.Enabled = true;
                        txtMeioApropriado.Enabled = true;
                        txtNomeProduto.Enabled = true;
                        txtOlhos.Enabled = true;
                        txtPele.Enabled = true;
                        btnCadastrar.Visible = true;
                        //btnUpdate.Visible = false;

                        int cod = element.Id + 1;
                        txtCod.Text = cod.ToString();
                        txtDescricao.Text = string.Empty;
                        txtFabricante.Text = string.Empty;
                        txtFormulaMolecular.Text = string.Empty;
                        txtIDPerigo.Text = string.Empty;
                        txtInalacao.Text = string.Empty;
                        txtIngestao.Text = string.Empty;
                        txtMeioApropriado.Text = string.Empty;
                        txtNomeProduto.Text = string.Empty;
                        lblIncendio.Text = string.Empty;
                        lblPerigo.Text = string.Empty;
                        break;
                    }
            }
        }

        private void LoadUnitCombo()
        {
            cmbUnidade.Items.Clear();
            _unitService.SelectAll().ForEach(unit => cmbUnidade.Items.Add(unit));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //mensagem de nao cadastrado
            //validar todos os campos para cadastrar
            if (ValidateItems().Count > 0)
            {
                Element element = PopulateElement();
                Danger danger = PopulateDanger();
                CombateIncendio combateIncendio = PopulateCombateIncendio();

                CombateIncendioService combateIncendioBLL = new CombateIncendioService();
                DangerService dangerBLL = new DangerService();
                ElementService elementBLL = new ElementService();

                try
                {
                    combateIncendioBLL.Adicionar(combateIncendio);
                    danger.Incendio = combateIncendioBLL.SelectLast();
                    dangerBLL.Adicionar(danger);
                    element.Danger = dangerBLL.SelectLast();
                    elementBLL.Adicionar(element);
                    MessageBox.Show("Cadastrada com sucesso!", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao cadastrar nova ficha: " + ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LimparCampos()
        {
            foreach (var gbox in this.Controls.OfType<GroupBox>().ToList())
            {
                foreach (var txt in gbox.Controls.OfType<TextBox>().ToList())
                {
                    txt.Text = String.Empty;
                }
            }
            cmbUnidade.SelectedIndex = -1;
        }

        private List<string> ValidateItems()
        {
            List<string> emptyItems = new List<string>();
            if (cmbUnidade.SelectedIndex != -1)
                emptyItems.Add("Unidade");
            if (txtDescricao.Text != string.Empty)
                emptyItems.Add("Descrição");
            if (txtNomeProduto.Text != string.Empty)
                emptyItems.Add("Nome Produto");
            if (txtFormulaMolecular.Text != string.Empty)
                emptyItems.Add("Fórmula Molecular");
            if (txtPeso.Text != string.Empty)
                emptyItems.Add("Peso Molecular");
            if (txtFabricante.Text != string.Empty)
                emptyItems.Add("Fabricante");
            if (txtIDPerigo.Text != string.Empty)
                emptyItems.Add("Perigo");
            if (txtInalacao.Text != string.Empty)
                emptyItems.Add("Inalação");
            if (txtOlhos.Text != string.Empty)
                emptyItems.Add("Contato com os Olhos");
            if (txtPele.Text != string.Empty)
                emptyItems.Add("Contato com a Pele");
            if (txtIngestao.Text != string.Empty)
                emptyItems.Add("Ingestão");
            if (txtMeioApropriado.Text != string.Empty)
                emptyItems.Add("Meio Apropriado");
            if (txtPerigoEspecifico.Text != string.Empty)
                emptyItems.Add("Perigo Específico");
            return emptyItems;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateItems().Count == 0)
            {
                Element element = PopulateElement();
                Danger danger = PopulateDanger();
                CombateIncendio combateIncendio = PopulateCombateIncendio();

                CombateIncendioService combateIncendioBLL = new CombateIncendioService();
                DangerService dangerBLL = new DangerService();
                ElementService elementBLL = new ElementService();

                try
                {
                    combateIncendioBLL.Update(combateIncendio);
                    dangerBLL.Update(danger);
                    elementBLL.Update(element);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao atualizar a ficha: " + ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private Element PopulateElement()
        {
            Element element = new Element();

            element.Id = Convert.ToInt32(txtCod.Text);
            element.NomeProduto = txtNomeProduto.Text;
            element.FormulaMolecular = txtFormulaMolecular.Text;
            element.Fabricante = txtFabricante.Text;
            element.Descricao = txtDescricao.Text;
            element.PesoMolecular = Convert.ToInt32(txtPeso.Text);
            element.Unidade = cmbUnidade.SelectedItem.ToString();

            return element;
        }

        private Danger PopulateDanger()
        {
            Danger danger = new Danger();

            danger.Id = lblPerigo.Text == string.Empty ? 0 : Convert.ToInt32(lblPerigo.Text);
            danger.ContatoOlhos = txtOlhos.Text;
            danger.ContatoPele = txtPele.Text;
            danger.Inalacao = txtInalacao.Text;
            danger.Ingestao = txtIngestao.Text;
            danger.Descricao = txtIDPerigo.Text;

            return danger;
        }

        private CombateIncendio PopulateCombateIncendio()
        {
            CombateIncendio combateIncendio = new CombateIncendio();

            combateIncendio.Id = lblIncendio.Text == string.Empty ? 0 : Convert.ToInt32(lblIncendio.Text);
            combateIncendio.MeioApropriado = txtMeioApropriado.Text;
            combateIncendio.PerigoEspecifico = txtPerigoEspecifico.Text;

            return combateIncendio;
        }

        private void FichaForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
