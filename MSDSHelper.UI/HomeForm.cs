using System;
using System.Windows.Forms;
using MSDSHelper.BLL;

namespace MSDSHelper.UI
{
    public partial class HomeForm : Form
    {
        LoginForm _login;
        private readonly UnitService _unitService;
        private const string APP_NAME = "MSDS Helper";
        public HomeForm()
        {
            InitializeComponent();
            _unitService = new UnitService();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void pesquisarFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchPanel.HasChildren)
                searchPanel.Controls.Clear();

            SearchForm search = new SearchForm("visualizar");
            search.TopLevel = false;
            search.Parent = searchPanel;
            search.Show();
        }

        private void cadastrarFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchPanel.HasChildren)
                searchPanel.Controls.Clear();
            if (_unitService.SelectAll().Count <= 0)
            {
                var result = MessageBox.Show(@"Por favor, tenha pelo menos uma unidade cadastrada no sitema. Deseja cadastrar uma agora?", 
                    APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _login = new LoginForm("createUnit");
                    _login.TopLevel = false;
                    _login.Parent = searchPanel;
                    _login.Disposed += login_Disposed;
                    _login.Show();
                    return;
                }

            }
            _login = new LoginForm("createFicha");
            _login.TopLevel = false;
            _login.Parent = searchPanel;
            _login.Disposed += login_Disposed;
            _login.Show();
        }

        void login_Disposed(object sender, EventArgs e)
        {
            if (_login.SucessLogin)
            {
                switch (_login.Type)
                {
                    case "createFicha":
                        ElementService elementBLL = new ElementService();
                        if (elementBLL.SelectCount() > 0)
                        {
                            FichaForm ficha = new FichaForm("create", false);
                            ficha.TopLevel = false;
                            ficha.Parent = searchPanel;
                            ficha.Show();
                        }
                        else
                        {
                            FichaForm ficha = new FichaForm("create", true);
                            ficha.TopLevel = false;
                            ficha.Parent = searchPanel;
                            ficha.Show();
                        }
                        break;

                    case "updateFicha":
                        SearchForm search = new SearchForm("update");
                        search.TopLevel = false;
                        search.Parent = searchPanel;
                        search.Show();
                        break;

                    case "updateUser":
                        UserForm user = new UserForm("update");
                        user.TopLevel = false;
                        user.Parent = userPanel;
                        user.Show();
                        break;

                    case "createUser":
                        user = new UserForm("create");
                        user.TopLevel = false;
                        user.Parent = userPanel;
                        user.Show();
                        break;

                    case "createUnit":
                        UnitForm unit = new UnitForm();
                        unit.TopLevel = false;
                        unit.Parent = _login.IsLoadToUserPanel? userPanel:searchPanel;
                        unit.Show();
                        break;
                }
            }
        }

        private void atualizarFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchPanel.HasChildren)
                searchPanel.Controls.Clear();

            _login = new LoginForm("updateFicha");
            _login.TopLevel = false;
            _login.Parent = searchPanel;
            _login.Disposed += login_Disposed;
            _login.Show();
        }

        private void atualizarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userPanel.HasChildren)
                userPanel.Controls.Clear();

            _login = new LoginForm("updateUser");
            _login.TopLevel = false;
            _login.Parent = userPanel;
            _login.Disposed += login_Disposed;
            _login.Show();
        }

        private void cadastrarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userPanel.HasChildren)
                userPanel.Controls.Clear();

            _login = new LoginForm("createUser");
            _login.TopLevel = false;
            _login.Parent = userPanel;
            _login.Disposed += login_Disposed;
            _login.Show();
        }

        private void cadastrarUnidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userPanel.HasChildren)
                userPanel.Controls.Clear();

            _login = new LoginForm("createUnit");
            _login.TopLevel = false;
            _login.Parent = userPanel;
            _login.IsLoadToUserPanel = true;
            _login.Disposed += login_Disposed;
            _login.Show();
        }
    }
}
