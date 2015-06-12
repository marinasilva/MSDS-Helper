using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSDSHelper.BLL;
using MSDSHelper.Model;

namespace MSDSHelper.UI
{
    public partial class FichaForm : Form
    {
        ElementService _elementBLL = new ElementService();
        Element element = new Element();


        public FichaForm(string type, int idElement, bool first)
        {
            InitializeComponent();
            element = _elementBLL.SelectByID(idElement);
            FormatComponents(type, element);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public FichaForm(string type, bool first)
        {
            InitializeComponent();
            if (!first)
                element = _elementBLL.SelectLast();
            else
                element.Id = 0;
            FormatComponents(type, element);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidateItems().Count > 0)
            {
                Element _element = PopulateElement();
                Danger _danger = PopulateDanger();
                CombateIncendio _combateIncendio = PopulateCombateIncendio();

                CombateIncendioService _combateIncendioBLL = new CombateIncendioService();
                DangerService _dangerBLL = new DangerService();
                ElementService _elementBLL = new ElementService();

                try
                {
                    _combateIncendioBLL.Adicionar(_combateIncendio);
                    _danger.Incendio = _combateIncendioBLL.SelectLast();
                    _dangerBLL.Adicionar(_danger);
                    _element.Danger = _dangerBLL.SelectLast();
                    _elementBLL.Adicionar(_element);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao cadastrar nova ficha: " + ex.Message);
                }
            }
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
                Element _element = PopulateElement();
                Danger _danger = PopulateDanger();
                CombateIncendio _combateIncendio = PopulateCombateIncendio();

                CombateIncendioService _combateIncendioBLL = new CombateIncendioService();
                DangerService _dangerBLL = new DangerService();
                ElementService _elementBLL = new ElementService();

                try
                {
                    _combateIncendioBLL.Update(_combateIncendio);
                    _dangerBLL.Update(_danger);
                    _elementBLL.Update(_element);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao atualizar a ficha: " + ex.Message);
                }
            }
        }

        private Element PopulateElement()
        {
            Element _element = new Element();

            _element.Id = Convert.ToInt32(txtCod.Text);
            _element.NomeProduto = txtNomeProduto.Text;
            _element.FormulaMolecular = txtFormulaMolecular.Text;
            _element.Fabricante = txtFabricante.Text;
            _element.Descricao = txtDescricao.Text;
            _element.PesoMolecular = Convert.ToInt32(txtPeso.Text);
            _element.Unidade = cmbUnidade.SelectedItem.ToString();

            return _element;
        }

        private Danger PopulateDanger()
        {
            Danger _danger = new Danger();

            _danger.Id = lblPerigo.Text == string.Empty ? 0 : Convert.ToInt32(lblPerigo.Text);
            _danger.ContatoOlhos = txtOlhos.Text;
            _danger.ContatoPele = txtPele.Text;
            _danger.Inalacao = txtInalacao.Text;
            _danger.Ingestao = txtIngestao.Text;
            _danger.Descricao = txtIDPerigo.Text;

            return _danger;
        }

        private CombateIncendio PopulateCombateIncendio()
        {
            CombateIncendio _combateIncendio = new CombateIncendio();

            _combateIncendio.Id = lblIncendio.Text == string.Empty ? 0 : Convert.ToInt32(lblIncendio.Text);
            _combateIncendio.MeioApropriado = txtMeioApropriado.Text;
            _combateIncendio.PerigoEspecifico = txtPerigoEspecifico.Text;

            return _combateIncendio;
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
