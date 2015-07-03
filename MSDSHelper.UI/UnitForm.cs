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
        private UnitService _unitBLL = null;
        private const string AppName = "MSDS Helper";
        public UnitForm()
        {
            InitializeComponent();
            LoadUnit();
        }

        private void LoadUnit()
        {
            cmbUnit.Items.Clear();
            _unitBLL = new UnitService();
            List<Unit> unitList = _unitBLL.SelectAll();
            if (unitList.Count == 0) return;
            cmbUnit.Items.Add("<Selecione para editar>");
            foreach (Unit unit in unitList)
            {
                cmbUnit.Items.Add(unit.Unidade);
            }
            cmbUnit.SelectedIndex = 0;
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
                _unitBLL = new UnitService();
                if (cmbUnit.SelectedIndex > 0)
                {
                    try
                    {
                        string unitName = cmbUnit.SelectedItem.ToString();
                        _unit = _unitBLL.SelectByName(unitName);
                        _unit.Unidade = txtUnit.Text;
                        _unit.Sigla = txtSigla.Text;
                        _unitBLL.Update(_unit);
                        MessageBox.Show(@"Unidade atualizada com sucesso!", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadUnit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Falha ao atualizar a unidade: " + ex.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                        //O correto é não mostrar o detalhe do erro e criar um log pra conter os detalhes da exception.
                    }
                }
                else
                    try
                    {
                        _unitBLL.Adicionar(_unit);
                        MessageBox.Show("Unidade adicionada com sucesso!", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUnit();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha ao adicionar unidade: " + ex.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos para cadastrar uma nova unidade!", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFields()
        {
            txtSigla.Text = String.Empty;
            txtUnit.Text = String.Empty;
            cmbUnit.SelectedIndex = 0;
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
            if (cmbUnit.SelectedIndex == 0) return;
            string unitName = cmbUnit.SelectedItem.ToString();
            Unit unit = _unitBLL.SelectByName(unitName);
            txtUnit.Text = unit.Unidade;
            txtSigla.Text = unit.Sigla;
        }
    }
}
