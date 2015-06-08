using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MSDSHelper.BLL;
using MSDSHelper.Model;


namespace MSDSHelper.UI
{
    public partial class UserForm : Form
    {
        User user = new User();
        UserBLL userBLL = new UserBLL();

        public UserForm(string type)
        {
            InitializeComponent();
            FormatComponents(type);
        }

        private void FormatComponents(string type)
        {
            switch (type)
            {
                case "update":
                    {
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = false;
                        break;
                    }
                case "create":
                    {
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = true;

                        user.Id = userBLL.SelectIdentCurrent();
                        
                        LoadComponents("create", user);
                        break;
                    }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtCod.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtlogin.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> valide = ValidateData();
            if (valide.Count > 0)
            {
                UserBLL _userBLL = new UserBLL();
                List<User> userList = new List<User>();

                foreach (string item in valide)
                {
                    string search = string.Empty;
                    if (item.Contains("Nome"))
                    {
                        search = item.Replace("Nome ", "");
                        userList = _userBLL.SelectByName(search);
                        goto x;
                    }
                    if (item.Contains("Cod "))
                    {
                        search = item.Replace("Cod ", "");
                        userList.Add(_userBLL.SelectByID(Convert.ToInt32(search)));
                        goto x;
                    }
                    if (item.Contains("Login "))
                    {
                        search = item.Replace("Login ", "");
                        userList = _userBLL.SelectByLogin(search);
                    }
                x:
                    if (userList.Count > 0)
                    {
                        LoadGrid(userList);
                    }
                    else
                        MessageBox.Show("Não foi encontrado nenhum registro com os critérios informados!");
                }
            }
            else
                MessageBox.Show("Favor inserir algum critério para pesquisa!");
        }

        private void LoadGrid(List<User> userList)
        {
            BindingSource bindingSource = new BindingSource();

            gridUsers.Columns[0].Name = "Cod";
            gridUsers.Columns[0].DataPropertyName = "Id";
            gridUsers.Columns[1].Name = "Nome";
            gridUsers.Columns[1].DataPropertyName = "Nome";
            gridUsers.Columns[2].Name = "Login";
            gridUsers.Columns[2].DataPropertyName = "Login";


            bindingSource.DataSource = userList;
            gridUsers.DataSource = bindingSource;
            btnOK.Enabled = true;
        }

        private List<string> ValidateData()
        {
            List<string> searchParameters = new List<string>();
            if (txtCod.Text != string.Empty)
                searchParameters.Add("Cod " + txtCod.Text);
            if (txtNome.Text != string.Empty)
                searchParameters.Add("Nome " + txtNome.Text);
            if (txtlogin.Text != string.Empty)
                searchParameters.Add("Login " + txtlogin.Text);
            return searchParameters;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count == 1)
            {
                DataGridViewRow row = gridUsers.SelectedRows[0];
                UserBLL _userBLL = new UserBLL();
                LoadComponents("update", _userBLL.SelectByID(Convert.ToInt32(row.Cells["Cod"].Value)));
            }
            if (gridUsers.SelectedRows.Count == 0)
                MessageBox.Show("É necessário selecionar um usuário para visualizar.");
            if (gridUsers.SelectedRows.Count > 1)
                MessageBox.Show("Selecione somente um usuário!");
        }

        private void LoadComponents(string type, User user)
        {
            switch (type)
            {
                case "update":
                    {
                        txtcod2.Enabled = false;
                        txtNome2.Enabled = true;
                        txtLogin2.Enabled = true;
                        txtsenha.Enabled = true;
                        txtsenha2.Enabled = true;
                        btnCreate.Visible = false;
                        btnUpdate.Visible = true;

                        if (user.Id <= 0 || user.Id == null)
                            txtcod2.Text = "1";
                        else
                            txtcod2.Text = user.Id.ToString();
                        txtNome2.Text = user.Nome;
                        txtLogin2.Text = user.Login;
                        txtsenha.Text = user.Password;
                        txtsenha2.Text = user.Password;
                        break;
                    }
                case "create":
                    {
                        txtcod2.Enabled = false;
                        txtNome2.Enabled = true;
                        txtLogin2.Enabled = true;
                        txtsenha.Enabled = true;
                        txtsenha2.Enabled = true;
                        btnCreate.Visible = true;
                        btnUpdate.Visible = false;

                        int cod = user == null ? 0 : user.Id;
                        txtcod2.Text = cod.ToString();
                        txtNome2.Text = string.Empty;
                        txtLogin2.Text = string.Empty;
                        txtsenha.Text = string.Empty;
                        txtsenha2.Text = string.Empty;
                        break;
                    }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //if (txtsenha.Text != txtsenha2.Text)
            //{
            //    txtsenha2.BackColor = Color.FromArgb(240, 36, 77);

            //}
            User user = new User();
            user.Nome = txtNome2.Text;
            user.Login = txtLogin2.Text;
            user.Password = txtsenha.Text;
            UserBLL userBLL = new UserBLL();
            try
            {
                userBLL.Adicionar(user);
                MessageBox.Show("Usuário adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao adicionar usuário: " + ex.Message);
            }
        }
    }
}
