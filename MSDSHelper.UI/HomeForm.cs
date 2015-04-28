using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDSHelper.BLL;

namespace MSDSHelper.UI
{
    public partial class HomeForm : Form
    {
        LoginForm _login;
        public HomeForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm("update");
            login.ShowDialog();
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

            _login = new LoginForm("create");
            _login.TopLevel = false;
            _login.Parent = searchPanel;
            _login.Disposed += login_Disposed;
            _login.Show();
        }

        void login_Disposed(object sender, EventArgs e)
        {
            if (_login.SucessLogin)
            {
                if (_login.type == "create")
                {
                    ElementBLL elementBLL = new ElementBLL();
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
                }
            }
        }

        private void atualizarFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchPanel.HasChildren)
                searchPanel.Controls.Clear();

            SearchForm search = new SearchForm("update");
            search.TopLevel = false;
            search.Parent = searchPanel;
            search.Show();
        }
    }
}
