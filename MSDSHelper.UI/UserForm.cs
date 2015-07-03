using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSDSHelper.BLL;
using MSDSHelper.Model;


namespace MSDSHelper.UI
{
    public partial class UserForm : Form
    {
        readonly User _user = new User();
        readonly UserService _userBLL = new UserService();
        private const string APP_NAME = "MSDS Helper";

        public UserForm(string type)
        {
            InitializeComponent();
            FormatComponents(type);
            LoadGrid(_userBLL.SelectAll());
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

                        _user.Id = _userBLL.SelectIdentCurrent();

                        LoadComponents("create", _user);
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
            LoadGrid(_userBLL.SelectAll());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> valide = ValidateData();
            if (valide.Count > 0)
            {
                UserService userBLL = new UserService();
                List<User> userList = new List<User>();

                foreach (string item in valide)
                {
                    string search = string.Empty;
                    if (item.Contains("Nome"))
                    {
                        search = item.Replace("Nome ", "");
                        userList = userBLL.SelectByName(search);
                        goto x;
                    }
                    if (item.Contains("Cod "))
                    {
                        search = item.Replace("Cod ", "");
                        userList.Add(userBLL.SelectByID(Convert.ToInt32(search)));
                        goto x;
                    }
                    if (item.Contains("Login "))
                    {
                        search = item.Replace("Login ", "");
                        userList = userBLL.SelectByLogin(search);
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
            gridUsers.Rows.Clear();
            for (int i = 0; i < userList.Count; i++)
            {
                var u = userList[i];
                gridUsers.Rows.Add(u.Id, u.Nome, u.Login);
            }
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
                UserService userBLL = new UserService();
                LoadComponents("update", userBLL.SelectByID(Convert.ToInt32(row.Cells["Cod"].Value)));
                groupBox2.Enabled = true;
                btnUpdate.Enabled = true;
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

                        if (user.Id <= 0)
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
                        gridUsers.Enabled = false;

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

            if (txtNome2.Text == string.Empty || txtLogin2.Text == String.Empty || txtsenha.Text == String.Empty)
            {
                MessageBox.Show("Preencha os dados corretamente para adicionar um usuário!",
                    APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }
            var user1 = new User { Nome = txtNome2.Text, Login = txtLogin2.Text, Password = txtsenha.Text };
            var userService = new UserService();
            try
            {
                userService.Adicionar(user1);
                MessageBox.Show("Usuário adicionado com sucesso!",
                    APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                LoadGrid(_userBLL.SelectAll());
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao adicionar usuário: " + ex.Message,
                    APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNome2.Text == string.Empty || txtLogin2.Text == String.Empty || txtsenha.Text == String.Empty)
            {
                MessageBox.Show("Preencha os dados corretamente para atualizar o usuário!",
                    APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }
            User user = new User();
            user.Id = Convert.ToInt32(txtcod2.Text);
            user.Nome = txtNome2.Text;
            user.Login = txtLogin2.Text;
            user.Password = txtsenha.Text;
            UserService userBLL = new UserService();
            try
            {
                userBLL.Update(user);
                MessageBox.Show("Usuário atualizado com sucesso!",
                    APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                LoadGrid(userBLL.SelectAll());
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao atualizar usuário: " + ex.Message,
                    APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtNome2.Text = string.Empty;
            txtLogin2.Text = string.Empty;
            txtsenha.Text = string.Empty;
            txtsenha2.Text = string.Empty;
            btnUpdate.Enabled = false;
        }
    }
}
