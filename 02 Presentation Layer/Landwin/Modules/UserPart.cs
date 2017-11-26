using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using _entity = Dothan.Library.bizAdmin;

namespace LandWin.Modules
{
    public partial class UserPart :  WinPart
    {
        private _entity.RoleList _rolelist;
        private _entity.UserList _list;
        private _entity.User _user;

        public UserPart()
        {
            InitializeComponent();
           
            LoadRoleList();
            LoadUserData();
        }


        private void LoadRoleList()
        {
            try
            {
                _rolelist = _entity.RoleList.Get();
                CreateCheckedListBoxControl();
             }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is System.Data.SqlClient.SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");
                    this.Close();
                }
                else
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.BusinessException.ToString(), "Error");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
                this.Close();

            }
        }


        private void LoadUserData()
        {
            try
            {
                _list = _entity.UserList.Get();
                BindingUserList();
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is System.Data.SqlClient.SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");
                    this.Close();
                }
                else
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.BusinessException.ToString(), "Error");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
                this.Close();

            }
        }

        private void BindingUserList()
        {
            if (this.btnViewInActive.Checked)
            {
                this.userListBindingSource.DataSource = _list;
            }
            else
            {
                this.userListBindingSource.DataSource = from user in _list
                                                        where user.IsActive == true
                                                        select user;
            }
            this.gridView1.RefreshData();
        }

  
        protected internal override object GetIdValue()
        {
            return "UserList";
        }


        private void btnAdd_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dockPanel1.Enabled = true;
            if (_user == null)
            {
                AddUser();
            }
            else
            {
                EndUserEditer();
                if (_user.IsDirty)
                {
                    if (Shared.Utility.ToConfirmUnSavedData())
                        AddUser();
                }

            }
        }

        private void AddUser()
        {
            _user = _entity.User.New();
            BindingUser();
        }



        private void EndUserEditer()
        {

            this.userBindingSource.EndEdit();
            StringBuilder str = new StringBuilder();
            foreach (CheckedListBoxItem item in checkedListBoxControl1.CheckedItems)
            {
                str.Append(item.Value.ToString()).Append(",");
            }
            _user.RoleList = str.ToString().TrimEnd(',');

        }


      

        private void SaveData()
        {
            this.userBindingSource.EndEdit();
            EndUserEditer();
            this.userBindingSource.RaiseListChangedEvents = false;
            
            _entity.User temp = _user.Clone();
            temp.ApplyEdit();
            try
            {

                _user = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                this.userBindingSource.ResetBindings(false);
                LoadUserData();
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is  System.Data.SqlClient.SqlException)
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
                this.userBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.User.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }

           
            EndUserEditer();
            if (!_user.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }

            SaveData();
        }



        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (_entity.User.CanDeleteObject())
            {

                DialogResult result = MessageBox.Show("Do you want to remove a selected user?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
                
                Remove(Shared.UtiltyDevExpress.SelectedRows(this.gridView1));

                this.LoadUserData();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
            }
        }




        private void Remove(object[] row)
        {
            try
            {
                foreach (object info in row)
                {
                    _entity.User.Delete(((_entity.UserInfo)info).Id, Dothan.ApplicationContext.User.Identity.Name);
                }


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
        }

        /// <summary>
        /// Add Role list on the CheckListBox
        /// </summary>
        private void CreateCheckedListBoxControl()
        {
            checkedListBoxControl1.Items.AddRange(CreateCheckedItemList());
        }

        private CheckedListBoxItem[] CreateCheckedItemList()
        {
            CheckedListBoxItem[] items = new CheckedListBoxItem[_rolelist.Count];

            for (int i = 0; i < _rolelist.Count; i++)
            {
                items[i] = new CheckedListBoxItem(_rolelist[i].Key, _rolelist[i].Value.ToString());
            }
            return items;
        }



        private void LoadUser(_entity.UserInfo info)
        {
            _user = _entity.User.Get(info.Id);
            BindingUser();
        }


        private void BindingUser()
        {
            _user.BeginEdit();
            this.userBindingSource.DataSource = _user;
            BindingRoleList(_user.RoleList);

            _user.PropertyChanged += new PropertyChangedEventHandler(User_PropertyChanged);
            
            dockPanel1.Enabled = true;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                LoadUser((_entity.UserInfo)view.GetRow(info.RowHandle));
            }
        }


        private void BindingRoleList(string roles)
        {
            if(string.IsNullOrEmpty(roles))
                return ;

            string[] list = roles.Split(',');

            if (list.Length > 0)
            {
                checkedListBoxControl1.UnCheckAll();
                foreach (string value in list)
                {
                    int id = int.Parse(value);
                    foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
                    {
                        if (id.Equals((int)item.Value))
                        {
                            item.CheckState = CheckState.Checked;
                            break;
                        }

                    }
                }
            }
        }


        private void btnReLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUserData();
        }


        private void ValiedateUserName(string name)
        {
            
            var dupUsername = from user in _list
                              where user.UserName.ToLower() == name.ToLower()
                              select user;
            if (dupUsername.Count() > 0)
            {
                MessageBox.Show(Properties.Resources.Err_Duplicated);
                this.UserNameTextEdit.Focus();
            }
              
            
        }

        private void User_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _entity.User info = (_entity.User)sender;
            if (e.PropertyName == "UserName")
            {
                ValiedateUserName(info.UserName);    
            }
        }

        private void btnViewInActive_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarCheckItem item = (DevExpress.XtraBars.BarCheckItem)sender;
            if (item.Checked)
            {
                item.Caption = "With InActive";
            }
            else
                item.Caption = "Without InActive";

            BindingUserList();
        }


    
    }
}