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
    public partial class LoginForm : Form
    {
        public bool SucessLogin { get; set; }
        public string Type { get; set; }

        //Em alguns momentos o forms secundario deve ser carregado em um panel, e vice-versa.
        public bool IsLoadToUserPanel { get; set; }

        private readonly Point _desiredLocation;
        private const string APP_NAME = "MSDS Helper";

        public LoginForm(string type)
        {
            InitializeComponent();
            lblType.Visible = false;
            Type = type;
            lblType.Text = type;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _desiredLocation = Location;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if ((txtLogin.Text == string.Empty) || (txtPass.Text == string.Empty))
            {
                if (txtLogin.Text == string.Empty)
                {
                    lblLogin.Text = "*";
                    lblLogin.Visible = true;
                    MessageBox.Show("Favor informar o login!", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtPass.Text == string.Empty)
                {
                    lblPass.Text = "*";
                    lblPass.Visible = true;
                    MessageBox.Show("Favor informar a senha!", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                UserService user = new UserService();
                if (user.ValidatePassword(txtLogin.Text, txtPass.Text))
                {
                    SucessLogin = true;
                    Close();
                    //if (lblType.Text == "create")
                    //{

                    //    SearchForm search = new SearchForm();

                    //    search.ShowDialog();
                    //}
                    //if (lblType.Text == "update")
                    //{
                    //    SearchForm search = new SearchForm();
                    //    search.ShowDialog();
                    //}
                }
                else
                    MessageBox.Show("Erro ao efeturar login. Verifique sua senha ou entre em contato com o administrador", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void LoginForm_LocationChanged(object sender, EventArgs e)
        {
            if (Location != _desiredLocation)
                Location = _desiredLocation;
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnAcessar_Click(null,null);
        }
    }
}

