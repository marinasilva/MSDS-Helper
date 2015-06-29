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
        readonly CombateIncendioService _combateIncendioBLL = new CombateIncendioService();
        readonly ElementService _elementBLL = new ElementService();
        readonly DangerService _dangerBLL = new DangerService();
        private readonly Point _desiredLocation;
        private const string AppName = "MSDS Helper";
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
            //Verifca o campo a ser pesquisado
            List<string> valide = ValidateItems();
            if (valide.Count > 0)
            {
                ElementService elementBLL = new ElementService();
                Element element = new Element();
                List<Element> elementList = new List<Element>();

                foreach (string item in valide)
                {
                    string search = string.Empty;
                    if (item.Contains("Cod"))
                    {
                        search = item.Replace("Cod ", "");
                        element = elementBLL.SelectByID(Convert.ToInt32(search));
                        //Se tiver encontrado alguma coisa adiciona.
                        if (element != null)
                            elementList.Add(element);
                        goto x;
                    }
                    if (item.Contains("Fabricante "))
                    {
                        search = item.Replace("Fabricante ", "");
                        elementList = elementBLL.SelectByFabricante(search);
                        goto x;
                    }
                    if (item.Contains("Formula "))
                    {
                        search = item.Replace("Formula ", "");
                        elementList = elementBLL.SelectByFormula(search);
                        goto x;
                    }
                    if (item.Contains("NomeProduto "))
                    {
                        search = item.Replace("NomeProduto ", "");
                        elementList = elementBLL.SelectByName(search);
                    }

                x:
                    if (elementList.Count > 0)
                        LoadGrid(elementList);
                    else
                        MessageBox.Show(@"Não foi encontrado nenhum registro com os critérios informados!",AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show(@"Favor inserir algum critério de pesquisa!",AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void LoadGrid(List<Element> elementList)
        {
            gridSearch.Rows.Clear();
            gridSearch.Columns.Clear();
            BindingSource bindingSource = new BindingSource();

            /* gridSearch.Columns[0].Name = "Cod";
             gridSearch.Columns[0].DataPropertyName = "Id";
             gridSearch.Columns[1].Name = "NomeProduto";
             gridSearch.Columns[1].DataPropertyName = "NomeProduto";
             gridSearch.Columns[2].Name = "Fabricante";
             gridSearch.Columns[2].DataPropertyName = "Fabricante";
             gridSearch.Columns[3].Name = "FormulaMolecular";
             gridSearch.Columns[3].DataPropertyName = "FormulaMolecular";*/

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
                ElementService elementBLL = new ElementService();
                LoadComponents("view", elementBLL.SelectByID(Convert.ToInt32(row.Cells["Id"].Value)));
            }
            if (gridSearch.SelectedRows.Count == 0)
                MessageBox.Show("É necessário selecionar uma ficha para visualizar.", "");
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
            CombateIncendio combateIncendio = PopulateCombateIncendio();
            Danger danger = PopulateDanger(combateIncendio);
            Element element = PopulateElement(danger);

            try
            {
                _combateIncendioBLL.Adicionar(combateIncendio);
                _dangerBLL.Adicionar(danger);
                _elementBLL.Adicionar(element);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao adicionar nova ficha de segurança: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CombateIncendio combateIncendio = PopulateCombateIncendio();
            Danger danger = PopulateDanger(combateIncendio);
            Element element = PopulateElement(danger);

            try
            {
                _combateIncendioBLL.Update(combateIncendio);
                _dangerBLL.Update(danger);
                _elementBLL.Update(element);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao atualizar ficha de segurança: " + ex.Message);
            }

        }

        private CombateIncendio PopulateCombateIncendio()
        {
            CombateIncendio combateIncendio = new CombateIncendio();
            combateIncendio.Id = lblIncendio.Text != string.Empty
                ? Convert.ToInt32(lblIncendio.Text)
                : _combateIncendioBLL.SelectLast().Id + 1;
            combateIncendio.MeioApropriado = txtMeioApropriado.Text;
            combateIncendio.PerigoEspecifico = txtPerigoEspecifico.Text;
            return combateIncendio;
        }

        private Danger PopulateDanger(CombateIncendio combateIncendio)
        {
            Danger danger = new Danger();
            danger.Id = lblPerigo.Text != string.Empty
                ? Convert.ToInt32(lblPerigo.Text)
                : _dangerBLL.SelectLast().Id + 1;
            danger.ContatoOlhos = txtOlhos.Text;
            danger.ContatoPele = txtPele.Text;
            danger.Descricao = txtIDPerigo.Text;
            danger.Inalacao = txtInalacao.Text;
            danger.Ingestao = txtIngestao.Text;
            danger.Incendio.Id = combateIncendio.Id;
            return danger;
        }

        private Element PopulateElement(Danger danger)
        {
            Element element = new Element();
            element.Id = Convert.ToInt32(txtCod.Text);
            element.Descricao = txtDescricao.Text;
            element.Fabricante = txtFabricante.Text;
            element.FormulaMolecular = txtFormulaMolecular.Text;
            element.NomeProduto = txtNomeProduto.Text;
            element.PesoMolecular = Convert.ToInt32(txtPeso.Text);
            element.Unidade = cmbUnidade.SelectedItem.ToString();
            element.Danger.Id = danger.Id;
            return element;
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

        private void txtCod1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}

