using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using _entity = Dothan.Library;


namespace LandWin.Tools
{
    public partial class CommentFrm : DevExpress.XtraEditors.XtraForm
    {
        private _entity.bizMember.Comment _comment;

        public _entity.bizMember.Comment Item { get { return _comment; } }

        public CommentFrm(_entity.bizMember.Comment item)
        {
            InitializeComponent();
            _comment = item;
            _comment.BeginEdit();
            this.commentBindingSource.DataSource = _comment;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.commentBindingSource.RaiseListChangedEvents = false;
            this.commentBindingSource.EndEdit();
            _entity.bizMember.Comment temp = _comment.Clone();
            temp.ApplyEdit();
            try
            {
                _comment = temp.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is System.Data.SqlClient.SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");

                }
                else
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.BusinessException.ToString(), "Error");

                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
            }
            finally
            {
                this.commentBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}