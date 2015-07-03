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
        private const string AppName = "MSDS Helper";

        public LoginForm(string _type)
        {
            InitializeComponent();
            lblType.Visible = false;
            Type = _type;
            lblType.Text = _type;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            _desiredLocation = this.Location;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if ((txtLogin.Text == string.Empty) || (txtPass.Text == string.Empty))
            {
                if (txtLogin.Text == string.Empty)
                {
                    lblLogin.Text = "*";
                    lblLogin.Visible = true;
                    MessageBox.Show("Favor informar o login!", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtPass.Text == string.Empty)
                {
                    lblPass.Text = "*";
                    lblPass.Visible = true;
                    MessageBox.Show("Favor informar a senha!", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Erro ao efeturar login. Verifique sua senha ou entre em contato com o administrador", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void LoginForm_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location != _desiredLocation)
                this.Location = _desiredLocation;
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnAcessar_Click(null,null);
        }
    }
}

