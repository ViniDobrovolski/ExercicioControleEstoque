using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControleEstoque1
{
    public partial class frmProdutos : ControleEstoque1.FrmBase
    {
        public frmProdutos()
        {
            InitializeComponent();
            BloqueiaCampos();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            Model get = new Model();
            List<DtoProduto2> lista = get.ListProduto();
            this.dataGridView1.DataSource = lista;
            this.dataGridView1.Refresh();
        }

        private void bntNovo_Click(object sender, EventArgs e)
        {
            textNome.Text = string.Empty;
            textMarca.Text = string.Empty;
            textQuantidade.Text = string.Empty;
            textPreco.Text = string.Empty;
            LiberaCampos();
            textNome.Focus();
        }

        #region Tratamento Visual
        private void LiberaCampos()
        {
            textNome.Enabled = true;
            textMarca.Enabled = true;
            textPreco.Enabled = true;
            textQuantidade.Enabled = true;
        }
        private void BloqueiaCampos()
        {
            textNome.Enabled = false;
            textMarca.Enabled = false;
            textPreco.Enabled = false;
            textQuantidade.Enabled = false;
        }


        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model set = new Model();
                dtoProduto u = new dtoProduto();
                u.nome = textNome.Text;
                u.marca = textMarca.Text;
                u.quantidade = Convert.ToInt32(textQuantidade.Text);
                u.preco = Convert.ToDecimal(textPreco.Text);
               if (textID.Text != string.Empty)
               {
                   u.id = int.Parse(textID.Text);
                  set.EditProduto(u);
              }
              else
                {
                    set.SetProduto(u);
                }

                BloqueiaCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            LiberaCampos();
            textNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (textID.Text != string.Empty)
            {
                Model del = new Model();
                del.DeletarProduto(int.Parse(textID.Text));
                BloqueiaCampos();
                CarregarGrid();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;

            Model get = new Model();
            DtoProduto2 d = get.GetProdutoID(ID);
            textID.Text = d.id.ToString();
            textNome.Text = d.nome;
         
            LiberaCampos();
            textNome.Focus();
        }
    }
}
