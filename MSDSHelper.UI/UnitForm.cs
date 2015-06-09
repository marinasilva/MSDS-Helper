using System;
using System.Collections.Generic;
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
            List<Unit> unitList = _unitBLL.SelectAll();
            if (unitList.Count == 0) return;
            foreach (Unit unit in unitList)
            {
                cmbUnit.Items.Add(unit.Unidade);
            }
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
                    try
                    {
                        string unitName = cmbUnit.SelectedItem.ToString();
                        _unit = _unitBLL.SelectByName(unitName);
                        _unit.Unidade = txtUnit.Text;
                        _unit.Sigla = txtSigla.Text;
                        _unitBLL.Update(_unit);
                        MessageBox.Show("Unidade atualizada com sucesso!");
                        txtSigla.Text = String.Empty;
                        txtUnit.Text = String.Empty;
                        cmbUnit.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha ao atualizar a unidade: " + ex.Message);
                    }
                }
                else
                    try
                    {
                        _unit = new Unit();
                        _unitBLL.Adicionar(_unit);
                        MessageBox.Show("Unidade adicionada com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha ao adicionar unidade: " + ex.Message);
                    }
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

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string unitName = cmbUnit.SelectedItem.ToString();
            Unit unit = _unitBLL.SelectByName(unitName);
            txtUnit.Text = unit.Unidade;
            txtSigla.Text = unit.Sigla;
        }
    }
}
