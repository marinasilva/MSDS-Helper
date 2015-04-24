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
        public string type { get; set; }

        public LoginForm(string _type)
        {
            InitializeComponent();
            lblType.Visible = false;
            type = _type; 
            lblType.Text = _type;
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
                    MessageBox.Show("Favor informar o login!");
                }
                else if (txtPass.Text == string.Empty)
                {
                    lblPass.Text = "*";
                    lblPass.Visible = true;
                    MessageBox.Show("Favor informar a senha!");
                }
            }
            else
            {
               UserBLL _user = new UserBLL();
                    if (_user.ValidatePassword(txtLogin.Text, txtPass.Text))
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
                }
               
            }
        }
    }

