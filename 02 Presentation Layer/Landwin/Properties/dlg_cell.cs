using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library;
using LandWin.Properties;

namespace LandWin
{
    public partial class dlg_cell : Form
    {
        private Cells _lists;
        public dlg_cell()
        {
            InitializeComponent();
            this.Text = Resources.Cell_Setting.ToString();

        }

        private void SavetoolStripButton1_Click(object sender, EventArgs e)
        {
            this.cellsBindingSource.RaiseListChangedEvents = false;
            this.cellListBindingSource.RaiseListChangedEvents = false;
            Cells temp = _lists.Clone();
            try
            {
                _lists = temp.Save();
                this.Close();
            }
            catch (Dothan.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                 LandWin.Properties.Resources.Error_Save.ToString(),
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), LandWin.Properties.Resources.Error_Save.ToString(),
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.cellsBindingSource.RaiseListChangedEvents = true;
                this.cellListBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void ClosetoolStripButton2_Click(object sender, EventArgs e)
        {
            if (_lists.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to close without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void dlg_cell_Load(object sender, EventArgs e)
        {
            this.cellListBindingSource.DataSource = CellList.GetList(frm_Main.Instance.Divcode.ToString());
            try
            {
                _lists = Cells.GetList(frm_Main.Instance.Divcode.ToString());
            }
            catch (Dothan.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                  "Data load error", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                  "Data load error", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }
            if (_lists != null)
                this.cellsBindingSource.DataSource = _lists;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int id = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                _lists.Remove(id);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _lists.AddNew();
        }
    }
}
