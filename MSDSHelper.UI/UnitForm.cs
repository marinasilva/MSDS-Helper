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
    public partial class UnitForm : Form
    {
        private Unit _unit = null;
        private UnitBLL _unitBLL = null;
        public UnitForm()
        {
            InitializeComponent();
            LoadUnit();
        }

        private void LoadUnit()
        {
            _unitBLL = new UnitBLL();
            cmbUnit.Items.Add(_unitBLL.SelectAll());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreateUpdate_Click(object sender, EventArgs e)
        {
            ValidateUnit();
            if (_unit != null)
            {
                _unitBLL = new UnitBLL();
                if (cmbUnit.SelectedIndex != -1)
                {
                    _unit.Id = _unitBLL.SelectByID(Convert.ToInt32(cmbUnit.SelectedItem)).Id;
                    _unitBLL.Update(_unit);
                }
                else
                    _unitBLL.Adicionar(_unit);
            }
            else
            {
                MessageBox.Show("Favor preencher os campos para cadastrar uma nova unidade!");
            }
        }

        private Unit ValidateUnit()
        {
            if (txtSigla.Text != string.Empty || txtUnit.Text != string.Empty)
                _unit = new Unit();
            if (txtUnit.Text != string.Empty)
                _unit.Unidade = txtUnit.Text;
            if (txtSigla.Text != string.Empty)
                _unit.Sigla = txtSigla.Text;
            return _unit;
        }
    }
}
