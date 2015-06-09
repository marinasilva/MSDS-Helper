namespace MSDSHelper.UI
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pesquisarFichaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarFichaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarFichaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.userPanel = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.cadastrarUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarUnidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(945, 770);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.searchPanel);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(937, 744);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ficha de Segurança";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // searchPanel
            // 
            this.searchPanel.AutoScroll = true;
            this.searchPanel.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.searchPanel.Controls.Add(this.pictureBox1);
            this.searchPanel.Location = new System.Drawing.Point(3, 31);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(945, 770);
            this.searchPanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(154, 156);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 301);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesquisarFichaToolStripMenuItem,
            this.cadastrarFichaToolStripMenuItem,
            this.atualizarFichaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pesquisarFichaToolStripMenuItem
            // 
            this.pesquisarFichaToolStripMenuItem.Name = "pesquisarFichaToolStripMenuItem";
            this.pesquisarFichaToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.pesquisarFichaToolStripMenuItem.Text = "Pesquisar Ficha";
            this.pesquisarFichaToolStripMenuItem.Click += new System.EventHandler(this.pesquisarFichaToolStripMenuItem_Click);
            // 
            // cadastrarFichaToolStripMenuItem
            // 
            this.cadastrarFichaToolStripMenuItem.Name = "cadastrarFichaToolStripMenuItem";
            this.cadastrarFichaToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.cadastrarFichaToolStripMenuItem.Text = "Cadastrar Ficha";
            this.cadastrarFichaToolStripMenuItem.Click += new System.EventHandler(this.cadastrarFichaToolStripMenuItem_Click);
            // 
            // atualizarFichaToolStripMenuItem
            // 
            this.atualizarFichaToolStripMenuItem.Name = "atualizarFichaToolStripMenuItem";
            this.atualizarFichaToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.atualizarFichaToolStripMenuItem.Text = "Atualizar Ficha";
            this.atualizarFichaToolStripMenuItem.Click += new System.EventHandler(this.atualizarFichaToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.userPanel);
            this.tabPage2.Controls.Add(this.menuStrip2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(937, 744);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configurações";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // userPanel
            // 
            this.userPanel.Location = new System.Drawing.Point(6, 30);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(925, 708);
            this.userPanel.TabIndex = 1;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarUsuárioToolStripMenuItem,
            this.atualizarUsuárioToolStripMenuItem,
            this.cadastrarUnidadeToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(931, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // cadastrarUsuárioToolStripMenuItem
            // 
            this.cadastrarUsuárioToolStripMenuItem.Name = "cadastrarUsuárioToolStripMenuItem";
            this.cadastrarUsuárioToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.cadastrarUsuárioToolStripMenuItem.Text = "Cadastrar Usuário";
            this.cadastrarUsuárioToolStripMenuItem.Click += new System.EventHandler(this.cadastrarUsuárioToolStripMenuItem_Click);
            // 
            // atualizarUsuárioToolStripMenuItem
            // 
            this.atualizarUsuárioToolStripMenuItem.Name = "atualizarUsuárioToolStripMenuItem";
            this.atualizarUsuárioToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.atualizarUsuárioToolStripMenuItem.Text = "Atualizar Usuário";
            this.atualizarUsuárioToolStripMenuItem.Click += new System.EventHandler(this.atualizarUsuárioToolStripMenuItem_Click);
            // 
            // cadastrarUnidadeToolStripMenuItem
            // 
            this.cadastrarUnidadeToolStripMenuItem.Name = "cadastrarUnidadeToolStripMenuItem";
            this.cadastrarUnidadeToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.cadastrarUnidadeToolStripMenuItem.Text = "Cadastrar Unidade";
            this.cadastrarUnidadeToolStripMenuItem.Click += new System.EventHandler(this.cadastrarUnidadeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Material Safety Data Sheet Helper";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(224, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 47);
            this.label3.TabIndex = 9;
            this.label3.Text = "MSDS Helper";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(5, 5);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(976, 828);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSDS Helper ";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pesquisarFichaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarFichaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarFichaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem cadastrarUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarUnidadeToolStripMenuItem;
    }
}