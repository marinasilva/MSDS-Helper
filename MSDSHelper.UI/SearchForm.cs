using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDSHelper.BLL;
using MSDSHelper.Model;

namespace MSDSHelper.UI
{
    public partial class SearchForm : Form
    {
        CombateIncendioBLL _combateIncendioBLL = new CombateIncendioBLL();
        ElementBLL _elementBLL = new ElementBLL();
        DangerBLL _dangerBLL = new DangerBLL();
        private Point _desiredLocation;

        public SearchForm(string type)
        {
            InitializeComponent();
            FormatComponents(type);
            DisableComponents();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            _desiredLocation = this.Location;
        }

        private void FormatComponents(string type)
        {
            switch (type)
            {
                case "view":
                    {
                        lblType.Text = "Visualização";
                        txtCod1.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = false;
                        txtFabricante1.Enabled = false;
                        txtFormulaMolecular.Enabled = false;
                        txtIDPerigo.Enabled = false;
                        txtInalacao.Enabled = false;
                        txtIngestao.Enabled = false;
                        txtMeioApropriado.Enabled = false;
                        txtNomeProduto1.Enabled = false;
                        txtOlhos.Enabled = false;
                        txtPele.Enabled = false;
                        btnCadastrar.Visible = false;
                        btnUpdate.Visible = false;
                        break;
                    }
                case "update":
                    {
                        lblType.Text = "Atualização";
                        txtCod.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = true;
                        txtFabricante1.Enabled = true;
                        txtFormulaMolecular.Enabled = true;
                        txtIDPerigo.Enabled = true;
                        txtInalacao.Enabled = true;
                        txtIngestao.Enabled = true;
                        txtMeioApropriado.Enabled = true;
                        txtNomeProduto1.Enabled = true;
                        txtOlhos.Enabled = true;
                        txtPele.Enabled = true;
                        btnCadastrar.Visible = false;
                        btnUpdate.Visible = true;
                        break;
                    }
                case "create":
                    {
                        lblType.Text = "Cadastro";
                        txtCod1.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = true;
                        txtFabricante1.Enabled = true;
                        txtFormulaMolecular.Enabled = true;
                        txtIDPerigo.Enabled = true;
                        txtInalacao.Enabled = true;
                        txtIngestao.Enabled = true;
                        txtMeioApropriado.Enabled = true;
                        txtNomeProduto1.Enabled = true;
                        txtOlhos.Enabled = true;
                        txtPele.Enabled = true;
                        btnCadastrar.Visible = true;
                        btnUpdate.Visible = false;
                        break;
                    }
            }
        }

        private void DisableComponents()
        {
            lblType.Text = "Ficha de Segurança";
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
            txtPeso.Enabled = false;
            cmbUnidade.Enabled = false;
            txtPerigoEspecifico.Enabled = false;
            btnCadastrar.Visible = false;
            btnUpdate.Visible = false;
            btnVisualizar.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtCod1.Text = string.Empty;
            txtFabricante1.Text = string.Empty;
            txtNomeProduto1.Text = string.Empty;
            txtFormula.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> valide = ValidateItems();
            if (valide.Count > 0)
            {
                ElementBLL _elementBLL = new ElementBLL();
                Element _element = new Element();
                List<Element> elementList = new List<Element>();

                foreach (string item in valide)
                {
                    string search = string.Empty;
                    if (item.Contains("Cod"))
                    {
                        search = item.Replace("Cod ", "");
                        elementList.Add(_elementBLL.SelectByID(Convert.ToInt32(search)));
                        goto x;
                    }
                    if (item.Contains("Fabricante "))
                    {
                        search = item.Replace("Fabricante ", "");
                        elementList = _elementBLL.SelectByFabricante(search);
                        goto x;
                    }
                    if (item.Contains("Formula "))
                    {
                        search = item.Replace("Formula ", "");
                        elementList = _elementBLL.SelectByFormula(search);
                        goto x;
                    }
                    if (item.Contains("NomeProduto "))
                    {
                        search = item.Replace("NomeProduto ", "");
                        elementList = _elementBLL.SelectByName(search);
                    }

                x:
                    if (elementList.Count > 0)
                    {

                        LoadGrid(elementList);
                    }
                    else
                        MessageBox.Show("Não foi encontrado nenhum registro com os critérios informados!");
                }
            }
            else
                MessageBox.Show("Favor inserir algum critério de pesquisa!");
        }

        private void LoadGrid(List<Element> elementList)
        {
            BindingSource bindingSource = new BindingSource();

            gridSearch.Columns[0].Name = "Cod";
            gridSearch.Columns[0].DataPropertyName = "Id";
            gridSearch.Columns[1].Name = "NomeProduto";
            gridSearch.Columns[1].DataPropertyName = "NomeProduto";
            gridSearch.Columns[2].Name = "Fabricante";
            gridSearch.Columns[2].DataPropertyName = "Fabricante";
            gridSearch.Columns[3].Name = "FormulaMolecular";
            gridSearch.Columns[3].DataPropertyName = "FormulaMolecular";

            bindingSource.DataSource = elementList;
            gridSearch.DataSource = bindingSource;
            btnVisualizar.Enabled = true;
        }

        private List<string> ValidateItems()
        {
            List<string> searchParameters = new List<string>();
            if (txtCod1.Text != string.Empty)
                searchParameters.Add("Cod " + txtCod1.Text);
            if (txtFabricante1.Text != string.Empty)
                searchParameters.Add("Fabricante " + txtFabricante1.Text);
            if (txtFormula.Text != string.Empty)
                searchParameters.Add("Formula " + txtFormula.Text);
            if (txtNomeProduto1.Text != string.Empty)
                searchParameters.Add("NomeProduto " + txtNomeProduto1.Text);

            return searchParameters;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (gridSearch.SelectedRows.Count == 1)
            {
                DataGridViewRow row = gridSearch.SelectedRows[0];
                ElementBLL _elementBLL = new ElementBLL();
                LoadComponents("view", _elementBLL.SelectByID(Convert.ToInt32(row.Cells["Cod"].Value)));
            }
            if (gridSearch.SelectedRows.Count == 0)
                MessageBox.Show("É necessário selecionar uma ficha para visualizar.");
            if (gridSearch.SelectedRows.Count > 1)
                MessageBox.Show("Selecione somente uma ficha!");
        }

        private void LoadComponents(string type, Element element)
        {
            //LoadUnitCombo();
            switch (type)
            {
                case "view":
                    {
                        lblType.Text = "Visualização";
                        txtCod1.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = false;
                        txtFabricante1.Enabled = false;
                        txtFormulaMolecular.Enabled = false;
                        txtIDPerigo.Enabled = false;
                        txtInalacao.Enabled = false;
                        txtIngestao.Enabled = false;
                        txtMeioApropriado.Enabled = false;
                        txtNomeProduto1.Enabled = false;
                        txtOlhos.Enabled = false;
                        txtPele.Enabled = false;
                        btnCadastrar.Visible = false;
                        btnUpdate.Visible = false;

                        int id = element.Id + 1;
                        txtCod1.Text = id.ToString();
                        txtDescricao.Text = element.Descricao;
                        txtFabricante1.Text = element.Fabricante;
                        txtFormulaMolecular.Text = element.FormulaMolecular;
                        txtIDPerigo.Text = element.Danger.Descricao;
                        txtInalacao.Text = element.Danger.Inalacao;
                        txtIngestao.Text = element.Danger.Ingestao;
                        txtMeioApropriado.Text = element.Danger.Incendio.MeioApropriado;
                        txtNomeProduto1.Text = element.Danger.Incendio.PerigoEspecifico;
                        lblIncendio.Text = element.Danger.Incendio.Id.ToString();
                        lblPerigo.Text = element.Danger.Id.ToString();

                        break;
                    }
                case "update":
                    {
                        lblType.Text = "Atualização";
                        txtCod1.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = true;
                        txtFabricante1.Enabled = true;
                        txtFormulaMolecular.Enabled = true;
                        txtIDPerigo.Enabled = true;
                        txtInalacao.Enabled = true;
                        txtIngestao.Enabled = true;
                        txtMeioApropriado.Enabled = true;
                        txtNomeProduto1.Enabled = true;
                        txtOlhos.Enabled = true;
                        txtPele.Enabled = true;
                        btnCadastrar.Visible = false;
                        btnUpdate.Visible = true;

                        txtDescricao.Text = element.Descricao;
                        txtFabricante1.Text = element.Fabricante;
                        txtFormulaMolecular.Text = element.FormulaMolecular;
                        txtIDPerigo.Text = element.Danger.Descricao;
                        txtInalacao.Text = element.Danger.Inalacao;
                        txtIngestao.Text = element.Danger.Ingestao;
                        txtMeioApropriado.Text = element.Danger.Incendio.MeioApropriado;
                        txtNomeProduto1.Text = element.Danger.Incendio.PerigoEspecifico;
                        lblIncendio.Text = element.Danger.Incendio.Id.ToString();
                        lblPerigo.Text = element.Danger.Id.ToString();
                        break;
                    }
                case "create":
                    {
                        lblType.Text = "Cadastro";
                        txtCod1.Enabled = false;
                        lblIncendio.Visible = false;
                        lblPerigo.Visible = false;
                        txtDescricao.Enabled = true;
                        txtFabricante1.Enabled = true;
                        txtFormulaMolecular.Enabled = true;
                        txtIDPerigo.Enabled = true;
                        txtInalacao.Enabled = true;
                        txtIngestao.Enabled = true;
                        txtMeioApropriado.Enabled = true;
                        txtNomeProduto1.Enabled = true;
                        txtOlhos.Enabled = true;
                        txtPele.Enabled = true;
                        btnCadastrar.Visible = true;
                        btnUpdate.Visible = false;

                        txtDescricao.Text = string.Empty;
                        txtFabricante1.Text = string.Empty;
                        txtFormulaMolecular.Text = string.Empty;
                        txtIDPerigo.Text = string.Empty;
                        txtInalacao.Text = string.Empty;
                        txtIngestao.Text = string.Empty;
                        txtMeioApropriado.Text = string.Empty;
                        txtNomeProduto1.Text = string.Empty;
                        lblIncendio.Text = string.Empty;
                        lblPerigo.Text = string.Empty;
                        break;
                    }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CombateIncendio _combateIncendio = PopulateCombateIncendio();
            Danger _danger = PopulateDanger(_combateIncendio);
            Element _element = PopulateElement(_danger);

            try
            {
                _combateIncendioBLL.Adicionar(_combateIncendio);
                _dangerBLL.Adicionar(_danger);
                _elementBLL.Adicionar(_element);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao adicionar nova ficha de segurança: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CombateIncendio _combateIncendio = PopulateCombateIncendio();
            Danger _danger = PopulateDanger(_combateIncendio);
            Element _element = PopulateElement(_danger);

            try
            {
                _combateIncendioBLL.Update(_combateIncendio);
                _dangerBLL.Update(_danger);
                _elementBLL.Update(_element);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao atualizar ficha de segurança: " + ex.Message);
            }

        }

        private CombateIncendio PopulateCombateIncendio()
        {
            CombateIncendio _combateIncendio = new CombateIncendio();
            _combateIncendio.Id = lblIncendio.Text != string.Empty
                ? Convert.ToInt32(lblIncendio.Text)
                : _combateIncendioBLL.SelectLast().Id + 1;
            _combateIncendio.MeioApropriado = txtMeioApropriado.Text;
            _combateIncendio.PerigoEspecifico = txtPerigoEspecifico.Text;
            return _combateIncendio;
        }

        private Danger PopulateDanger(CombateIncendio combateIncendio)
        {
            Danger _danger = new Danger();
            _danger.Id = lblPerigo.Text != string.Empty
                ? Convert.ToInt32(lblPerigo.Text)
                : _dangerBLL.SelectLast().Id + 1;
            _danger.ContatoOlhos = txtOlhos.Text;
            _danger.ContatoPele = txtPele.Text;
            _danger.Descricao = txtIDPerigo.Text;
            _danger.Inalacao = txtInalacao.Text;
            _danger.Ingestao = txtIngestao.Text;
            _danger.Incendio.Id = combateIncendio.Id;
            return _danger;
        }

        private Element PopulateElement(Danger danger)
        {
            Element _element = new Element();
            _element.Id = Convert.ToInt32(txtCod.Text);
            _element.Descricao = txtDescricao.Text;
            _element.Fabricante = txtFabricante.Text;
            _element.FormulaMolecular = txtFormulaMolecular.Text;
            _element.NomeProduto = txtNomeProduto.Text;
            _element.PesoMolecular = Convert.ToInt32(txtPeso.Text);
            _element.Unidade = cmbUnidade.SelectedItem.ToString();
            _element.Danger.Id = danger.Id;
            return _element;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridSearch_SelectionChanged(object sender, EventArgs e)
        {
            btnVisualizar.Enabled = true;
        }

        private void SearchForm_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location != _desiredLocation)
                this.Location = _desiredLocation;
        }
    }
}

