using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using _entity = Dothan.Library;
using LandWin.Tools;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Card.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace LandWin.Tools
{
    public partial class MemberInfoFrm : DevExpress.XtraEditors.XtraForm
    {
        private _entity.bizCommon.Address _address;
        private _entity.bizMember.Member _member;
        private _entity.bizMember.FamilyList _family;
        private _entity.bizMember.MemberMinistrys _ministry;
        private _entity.bizMember.MemberCourses _courses;
        private _entity.bizCommon.TypeList _relastionship;
        

        public event EventHandler CheckParent;

        public void OnCheckParent()
        {
            if (CheckParent != null)
                CheckParent(this, EventArgs.Empty);
        }


        public MemberInfoFrm(int id)
        {
            InitializeComponent();

            this.btnRemove.Enabled = _entity.bizMember.Member.CanDeleteObject();
            this.xtraTabPage5.PageVisible = _entity.bizMemberVisit.MemberVisit.CanGetObject();

            InitDataBinding();

            if (id == 0)
            {
                NewMember(false);
            }
            else
            {
                LoadData(id);
            }
        }


        public bool CheckMemberId(int id)
        {
            bool result = false;

            foreach (_entity.bizMember.FamilyInfo item in _family)
                if (item.MemberId == id)
                {
                    result = true;
                    break;
                }

            return result;
        }

        private void bt_CloseFrm_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnCheckParent();
        }

        private void MemberInfoFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCheckParent();
        }

        #region Load /Save Member Data

        private void LoadData(int id)
        {
            LoadMember(id);
            LoadAddressData(_member.Addressid);
            LoadFamily(id);
            LoadCommentList();
            LoadVisitList();
            LoadDetail(id);
            LoadMinistry();
            LoadEducation();
        }

        private void LoadDetail(int id )
        {
            this.memberCellsBindingSource.DataSource = _entity.bizMember.MemberCells.Get(id);
            this.memberFellowshipsBindingSource.DataSource = _entity.bizMember.MemberFellowships.Get(id);
           
        }

        private void LoadFamily(int id)
        {
            try
            {
                _family = _entity.bizMember.FamilyList.GetList(id);
                this.familyListBindingSource.DataSource = _family;
            
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

        private void NewMember(bool family)
        {

            _member = _entity.bizMember.Member.New();
            if (family)
            {
                _member.Addressid = _address.ID;
                _member.FamilyCode = _family[0].FamilyCode;

                this.relationshipListBindingSource.DataSource = from list in _relastionship
                                                                where list.Key != 0
                                                                select list;


                var exist = from items in _family
                            where items.RelationShipCode == 1
                            select items.MemberId;
                
                if (exist.Count() == 0)
                    _member.Relationship = 1;
                else
                    _member.Relationship = 3;

                layoutControlGroup2.Enabled = false;
                txtRelastionship.Enabled = true;
            }
            else
            {
                _address = _entity.bizCommon.Address.New();
                txtRelastionship.EditValue = 0;
                txtRelastionship.Enabled = false;
            }
            _address.PropertyChanged += new PropertyChangedEventHandler(Address_PropertyChanged);
            _member.PropertyChanged += new PropertyChangedEventHandler(Member_PropertyChanged);
            pictureEdit1.Image = null;
            this.bar7.Visible = !_member.IsNew;
            this.xtraTabControl1.Enabled = !_member.IsNew;
            this.StatusSpinEdit.Enabled = true;
            this.memberBindingSource.DataSource = _member;
            this.addressBindingSource.DataSource = _address;
        }

        private void SetTools()
        {
            this.btnUploadPicture.Enabled = !_member.IsNew;
            this.btnRemovePicture.Enabled = !_member.IsNew;
            this.barSubItem5.Enabled = !_member.IsNew;
            this.btnSpliteFamily.Enabled = !_member.IsNew;
            this.btnChangeFellowship.Enabled = !_member.IsNew;
        }

        private void LoadMember(int id)
        {
            try
            {

                _member = _entity.bizMember.Member.Get(id);

                this.bar7.Visible = !_member.IsNew;
                this.xtraTabControl1.Enabled = !_member.IsNew;
                this.layoutControlGroup2.Enabled = true;
                this.StatusSpinEdit.Enabled = false;
                

                _member.BeginEdit();

                this.memberBindingSource.DataSource = _member;

                if (_member.Relationship == 0)
                {
                    this.btnSpliteFamily.Enabled = false;
                    txtRelastionship.EditValue = null;
                    txtRelastionship.Enabled = false;
                }
                else
                {
                    this.btnSpliteFamily.Enabled = true;
                    txtRelastionship.Enabled = true;
                }
                ImageLoad();


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

        private void LoadAddressData(int addressid)
        {
            try
            {
                if (_address != null && _address.ID == addressid) return;

                if (addressid == 0)
                    _address = _entity.bizCommon.Address.New();
                else
                    _address = _entity.bizCommon.Address.Get(addressid);

                _address.BeginEdit();
                _address.PropertyChanged += new PropertyChangedEventHandler(Address_PropertyChanged);
                this.addressBindingSource.DataSource = _address;

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
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            var tb = (DevExpress.XtraEditors.TextEdit)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                this.dxErrorProvider2.SetError(tb, "Please fill the required field");
            }
            else
            {
                this.dxErrorProvider2.ClearErrors();
            }
        }
        private void SaveMember()
        {
            RaiseListChangedEvents(false);
            this.addressBindingSource.EndEdit();
            this.memberBindingSource.EndEdit();
            this.memberFellowshipsBindingSource.RaiseListChangedEvents = false;
            this.memberCellsBindingSource.RaiseListChangedEvents = false;

            _entity.bizCommon.Address temp = _address.Clone();
            temp.ApplyEdit();
            try
            {
                if (!_member.IsNew)
                {

                    _entity.bizMember.MemberFellowships tempfellowship = ((_entity.bizMember.MemberFellowships)this.memberFellowshipsBindingSource.DataSource).Clone();
            
                    tempfellowship.ApplyEdit();
                    tempfellowship.Save();

                    _entity.bizMember.MemberCells tempCell = ((_entity.bizMember.MemberCells)this.memberCellsBindingSource.DataSource).Clone();

                    tempCell.ApplyEdit();
                    tempCell.Save();

                }
                _address = temp.Save();
                _member.Addressid = _address.ID;
                _entity.bizMember.Member temp2 = _member.Clone();
                temp2.ApplyEdit();
                _member = temp2.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                LoadData(_member.MemberID);
                LoadFamily(_member.MemberID);
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
                RaiseListChangedEvents(true);
                this.memberFellowshipsBindingSource.RaiseListChangedEvents = true;
                this.memberCellsBindingSource.RaiseListChangedEvents = true;
            }

        }

        protected void InitDataBinding()
        {
            this.jobListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("job", false);
            this.sexListBindingSource.DataSource = _entity.bizCommon.SexList.Get(false);
            this.marriageListBindingSource.DataSource = _entity.bizCommon.MarriageList.Get(false);

            this.entryListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("entry", false);
            _relastionship = _entity.bizCommon.TypeList.Get("relationship", false);
            this.relationshipListBindingSource.DataSource = _relastionship;
            this.baptismListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("baptism", false);
            this.subdivisionListBindingSource.DataSource = _entity.bizCommon.SubdivisionList.Get(false);

            _entity.bizAdmin.StatusTypes  status = _entity.bizAdmin.StatusTypes.Get();
            this.statusListBindingSource.DataSource = from list in status
                                                      where list.IsActive = true 
                                                      select new { Key = list.ID , Value = list.Name};

            this.ministryListBindingSource.DataSource = _entity.bizMinistry.MinistryList.Get(false);
            this.ministryRoleListBindingSource.DataSource = _entity.bizMinistry.MinistryRoleList.Get(false);
            this.courseListBindingSource.DataSource = _entity.bizCourse.CourseList.GetList();
        }

        private void Address_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Zipcode")
            {
                GetAddressByzipCode(_address.Zipcode);
            }
        }

        private void Member_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
            if (_member.IsNew && (e.PropertyName == "KoFirstName" || e.PropertyName == "KoLastName"))
            {
                if( !string.IsNullOrEmpty(_member.KoLastName) && !string.IsNullOrEmpty(_member.KoFirstName))
                {
                    CheckSameName(_member.KoName);
                }
            }

        }

        private void CheckSameName(string name)
        {
            try
            {
                _entity.bizDonate.DonateMemberList list = _entity.bizDonate.DonateMemberList.GetList(0, name, null, null, null, null);
                if (list.Count > 0)//v3.2.6 2/7/2016
                {
                    using (Tools.SearchSameNameFrm frm = new Tools.SearchSameNameFrm(list))
                    {
                        if (frm.ShowDialog() == DialogResult.OK && frm.SelectedMember.MemberID == 0)
                        {

                            _member.DonateID = frm.SelectedMember.ID;
                            _member.Addressid = frm.SelectedMember.AddressID;
                            LoadAddressData(_member.Addressid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return;
                }
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
            }
        }


        private void GetAddressByzipCode(string str)
        {
            if (string.IsNullOrEmpty(str)) return;

            using (ZipcodeFrm frm = new ZipcodeFrm(str))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _address.City = frm.ZipcodeInfo.City;
                    _address.State = frm.ZipcodeInfo.State;
                }
            }
        }

        private void RaiseListChangedEvents(bool set)
        {
            this.jobListBindingSource.RaiseListChangedEvents = set;
            this.entryListBindingSource.RaiseListChangedEvents = set;
            this.baptismListBindingSource.RaiseListChangedEvents = set;
            this.subdivisionListBindingSource.RaiseListChangedEvents = set;
            this.statusListBindingSource.RaiseListChangedEvents = set;
            this.marriageListBindingSource.RaiseListChangedEvents = set;
            this.sexListBindingSource.RaiseListChangedEvents = set;
            this.relationshipListBindingSource.RaiseListChangedEvents = set;
        }

        #endregion

        #region Print Menu
   
        /// <summary>
        /// 교인 교적부
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemberDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ReportPrint(2);
        }
        /// <summary>
        /// 교인 교적 카드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemberCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(3);
        }

        /// <summary>
        /// 교인 사진 명부
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMamberDetailwPic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(4);
        }






        /// <summary>
        ///세대별 가족현황 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barFamliyDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(7);
        }

    

        private void ReportPrint(int reportName)
        {

            string memberlist = _member.MemberID.ToString();

            if (string.IsNullOrEmpty(memberlist))
                return;

            try
            {
                Shared.ReprotManager manager = new LandWin.Shared.ReprotManager();
                switch (reportName)
                {
                    case 1:
                        manager.PrintAddressLabel(memberlist, false);
                        break;
                    case 2:
                        manager.PrintMemberDetails(memberlist);
                        break;
                    case 3:
                        manager.PrintMemberCard(memberlist);
                        break;
                    case 4:
                        manager.PrintMemberWithPic(memberlist);
                        break;
                    case 7:
                        manager.PrintMemberByFamily(memberlist);
                        break;
                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
            }

        }


        #endregion
        #region Images

        private void btnUploadPicture_Click(object sender, ItemClickEventArgs e)
        {
            
            OpenFileDialog frm = new OpenFileDialog();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Image imge = Image.FromFile(frm.FileName);
                imge = resizeImage(imge, new Size(115, 152));
                string filename = "C:\\LandWin\\DATA\\MemberImage\\"
                    + _member.MemberID + ".jpg";
                NonLockingSave(imge, filename, ImageFormat.Jpeg);
                UploadPicture(filename);
            }
        }

        private void btnRemovePicture_Click(object sender, ItemClickEventArgs e)
        {
            Image imge = Image.FromFile(@"C:\\LandWin\Data\MemberImage\Nophoto.jpg");
            imge = this.resizeImage(imge, new Size(115, 152));
            string filename = " C:\\LandWin\\DATA\\MemberImage\\"
                     + _member.MemberID + ".jpg";
            this.NonLockingSave(imge, filename, ImageFormat.Jpeg);
            this.UploadPicture(filename);
        }


        private void ImageLoad()
        {
            if (_member.IsNew) return;

           pictureEdit1.Image = Shared.Utility.LoadImage(_member.MemberID);
        }

        public void UploadPicture(string inputfilename)
        {
            try
            {

                FileInfo fileInf = new FileInfo(inputfilename);
                Shared.FtpApi api = new Shared.FtpApi();

                api.upload(fileInf.Name, inputfilename);

                _entity.FileLog.UpdateFileLog(fileInf.Name, Dothan.ApplicationContext.User.Identity.Name, DateTime.Now.ToString());
            }

            catch
            {
                MessageBox.Show("Ftp server does not accessible", "Upload Error");
                File.Delete(inputfilename);

            }
            finally
            {
                this.cardView1.RefreshData();

                ImageLoad();
            }


        }
        private Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }


        public void NonLockingSave(Image img, string fn, ImageFormat format)
        {
            // Delete destination file if it already exists
            if (File.Exists(fn))
                File.Delete(fn);

            try
            {

                #region Convert image to destination format

                MemoryStream ms = new MemoryStream();
                Image img2 = (Image)img.Clone();
                img2.Save(ms, format);
                img2.Dispose();
                byte[] byteArray = ms.ToArray();
                ms.Close();
                ms.Dispose();

                #endregion

                #region Save byte array to file

                FileStream fs = new FileStream(fn, FileMode.CreateNew, FileAccess.Write);
                try
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                }
                finally
                {
                    fs.Close();
                    fs.Dispose();
                }

                #endregion

            }
            catch
            {
                // Delete file if it was created
                if (File.Exists(fn))
                    File.Delete(fn);

                // Re-throw exception
                throw;
            }
        }
        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }


        #endregion


        #region  Function In Commmant

        private void LoadCommentList()
        {
            this.commentListBindingSource.DataSource = _entity.bizMember.CommentList.GetList(_member.MemberID);
            this.gridView1.RefreshData();
        }
        
        private void LoadComment(int id)
        {
            try
            {
                _entity.bizMember.Comment item;
                if (id == 0)
                {
                    item = _entity.bizMember.Comment.New(_member.MemberID);
                    item.Member = _member.KoName;
                   
                }
                else
                    item = _entity.bizMember.Comment.Get(id);

                using (Tools.CommentFrm frm = new Tools.CommentFrm(item))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(Properties.Resources.Success_Save);
                        LoadCommentList();
                    }

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
        private void btnAddComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_member.IsNew) return;

            LoadComment(0);
        }
        private void btnEditComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.SelectedRowsCount == 0)
                return;

            int row = gridView1.GetSelectedRows()[0];
            LoadComment((int)gridView1.GetRowCellValue(row, "ID"));
        }

        private void btnDeleteComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.SelectedRowsCount == 0)
                return;
            DialogResult result = MessageBox.Show("Do you want to delete a Selected row?", "Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int row = (gridView1.GetSelectedRows()[0]);
                _entity.bizMember.Comment.DeleteComment((int)gridView1.GetRowCellValue(row, "ID"));
                MessageBox.Show(Properties.Resources.Success_Save);
                LoadCommentList();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                LoadComment((int)gridView1.GetRowCellValue(info.RowHandle, "ID"));
            }
        }
        #endregion


        #region View Family List 



        private void cardView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (_family == null) return;

            if (e.Column.FieldName == "colPhoto" && e.IsGetData)
            {
                int id = (int)cardView1.GetRowCellValue(e.RowHandle, colMemberId);
                e.Value = Shared.Utility.LoadImage(id);
            }
        }


        private void FamilyList_DoubleClick(object sender, EventArgs e)
        {

            CardView view = (CardView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                CardHitInfo info = view.CalcHitInfo(pt);
                if (info.InCard)
                {
                    _entity.bizMember.FamilyInfo item = view.GetRow(info.RowHandle) as _entity.bizMember.FamilyInfo;

                    LoadData(item.MemberId);
                }

        }

        #endregion


        #region VisitReport functions

        private void LoadVisitList()
        {
            if(!_entity.bizMemberVisit.MemberVisit.CanGetObject()) return ;

            this.btnEditVisitReport.Enabled = _entity.bizMemberVisit.MemberVisit.CanEditObject();
            this.btnAddVisitReport.Enabled = _entity.bizMemberVisit.MemberVisit.CanAddObject();

            this.visitReportListBindingSource.DataSource = _entity.bizMemberVisit.VisitReportList.Get(_member.MemberID,null,null,null,0,0);
            this.gridView3.RefreshData();
        }

        private void btnAddVisitReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            _entity.bizMemberVisit.MemberVisit _item = _entity.bizMemberVisit.MemberVisit.New();
            _item.MemberId = _member.MemberID;
            _item.FullName = _member.KoName;
            EditVisitReport(_item);
        }

        private void EditVisitReport(_entity.bizMemberVisit.MemberVisit item)
        {
            try
            {
                MemberVisitDetailFrm frm = new MemberVisitDetailFrm(item);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadVisitList();
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

    
        private void btnEditVisitReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView3.SelectedRowsCount == 0) return;

            int row = this.gridView3.GetSelectedRows()[0];
            _entity.bizMemberVisit.MemberVisit item = _entity.bizMemberVisit.MemberVisit.Get((int)gridView3.GetRowCellValue(row, "ID"));
            EditVisitReport(item);
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            if (!_entity.bizMemberVisit.MemberVisit.CanEditObject()) return;

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                int id = ((int)view.GetRowCellValue(info.RowHandle, "Id"));
                _entity.bizMemberVisit.MemberVisit item = _entity.bizMemberVisit.MemberVisit.Get(id);
                EditVisitReport(item);
            }

        }

        #endregion

        #region Tools Functions

        /// <summary>
        /// Undo changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            _member.CancelEdit();
            this.marriageListBindingSource.ResetBindings(false);
        }
    

        private void btnSaveMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dxErrorProvider1.HasErrors || dxErrorProvider2.HasErrors)
            {
                MessageBox.Show("Please fill out all required field.");
            }
            else
            {
                SaveMember();
            }
        }

        private void btnSetFamilyOwner_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_member.Relationship == 0)
            {
                MessageBox.Show(LandWin.Properties.Resources.Current_FamilyOwner);
                return;
            }
            using (Tools.ChangeFamilyOwnerFrm frm = new Tools.ChangeFamilyOwnerFrm(_family, _member))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(_member.MemberID);
                }
            }
        }
        private void btnChangeStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StringBuilder str = new StringBuilder();

            using (Tools.StatusEditFrm frm = new Tools.StatusEditFrm())
            {

                if (_member.Relationship == 0 )
                {
                    DialogResult result = MessageBox.Show("Do you want to change status all family member? If not, You have to change a Family Owner.", "Question", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {

                        foreach (_entity.bizMember.FamilyInfo item in this._family)
                        {
                            str.Append(item.MemberId.ToString()).Append(",");
                        }
                        frm.CommandType = "Family";
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    str.Append(_member.MemberID.ToString()).Append(",");
                    frm.CommandType = "Individual";
                }
                frm.MemberList = str.ToString();
                frm.MemberName = _member.KoName;

                try
                {
                    frm.MemberStatus = StatusSpinEdit.Text;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadMember(_member.MemberID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult confirm = MessageBox.Show(Properties.Resources.Question_DeleteMember, "Warnning", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                StringBuilder str = new StringBuilder();
                DialogResult result = MessageBox.Show(Properties.Resources.Question_DeleteFamily, "Warnning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                 
                        foreach (_entity.bizMember.FamilyInfo item in _family)
                            str.Append(item.MemberId.ToString()).Append(",");
                }
                else
                    str.Append(_member.MemberID.ToString()).Append(",");


                try
                {
                    DialogResult result2 = MessageBox.Show(Properties.Resources.Question_DeleteComfirm, "Warnning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result2 == DialogResult.Yes)
                    {
                        _entity.bizMember.Member.DeleteMember(str.ToString().TrimEnd(',') , Dothan.ApplicationContext.User.Identity.Name);
                        MessageBox.Show("Memeber infomation has been deleted");
                        this.Close();
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
        }

        private void btnSpliteFamily_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_member.Relationship == 0)
            {
                return;
            }
            else
            {
                Tools.SpliteFamilyFrm frm = new Tools.SpliteFamilyFrm(_member);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(_member.MemberID);
                }
            }
        }

        private void btnAddMember_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            NewMember(true);
        }

        private void btnAddExistMember_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Tools.FamilyAddFrm frm = new FamilyAddFrm(_member.FamilyCode))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    LoadFamily(_member.FamilyCode);
                }
            }
        }
        #endregion

        #region View Memu

        /// <summary>
        /// 교적 상태 변경 로그 보기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowStatusLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                Tools.StatusLogViewFrm dlg = new Tools.StatusLogViewFrm(_member.MemberID);
                dlg.ShowDialog();
                dlg.Dispose();
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
        #endregion


        #region Eduction 
        private void LoadEducation()
        {
            _courses = _entity.bizMember.MemberCourses.Get(_member.MemberID);
            this.memberCoursesBindingSource.DataSource = _courses;
        }
        private void btnAddEducation_ItemClick(object sender, ItemClickEventArgs e)
        {
            _courses.Assign(_member.MemberID);
        }

        private void RemoveEduction(object[] row)
        {
            foreach (object obj in row)
            {
                _courses.Remove(obj as _entity.bizMember.MemberCourse);
             
            }
        }
        private void btnRemoveEducation_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView8.SelectedRowsCount == 0) return;


            RemoveEduction(Shared.UtiltyDevExpress.SelectedRows(this.gridView8));
            
        }

        private void btnSaveEducation_ItemClick(object sender, ItemClickEventArgs e)
        {

            this.gridView8.PostEditor();
            this.memberCoursesBindingSource.RaiseListChangedEvents = false;
            this.memberCoursesBindingSource.EndEdit();

            _entity.bizMember.MemberCourses temp = _courses.Clone();
            temp.ApplyEdit();
            try
            {
                _courses = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                this.memberCoursesBindingSource.DataSource = null;
                this.memberCoursesBindingSource.DataSource = _courses;
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
                this.memberCoursesBindingSource.RaiseListChangedEvents = true;
            }
        }
        #endregion

        #region Ministry List
        private void LoadMinistry()
        {
            _ministry = _entity.bizMember.MemberMinistrys.Get(_member.MemberID);
            this.memberMinistrysBindingSource.DataSource = _ministry;
        }

        private void btnSaveMinistry_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            this.gridView5.PostEditor();
            this.memberMinistrysBindingSource.RaiseListChangedEvents = false;
            this.memberMinistrysBindingSource.EndEdit();

            _entity.bizMember.MemberMinistrys temp = _ministry.Clone();
            temp.ApplyEdit();
            try
            {
                _ministry = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                this.memberMinistrysBindingSource.DataSource = null;
                this.memberMinistrysBindingSource.DataSource = _ministry;
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
                this.memberMinistrysBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void RemoveMinistry(object[] row)
        {
            foreach (object obj in row)
            {
                if ((obj as _entity.bizMember.MemberMinistry).IsNew)
                {
                    _ministry.Remove(obj as _entity.bizMember.MemberMinistry);
                }
                else
                {
                    (obj as _entity.bizMember.MemberMinistry).EndDate = DateTime.Today.ToString();

                }
            }
        }

        private void btnAddMinistry_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ministry.Assign(_member.MemberID);
        }

        private void btnRemoveMinistry_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView5.SelectedRowsCount == 0) return;

            RemoveMinistry(Shared.UtiltyDevExpress.SelectedRows(this.gridView5));

        }
        #endregion

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(this.Baptism_YearTextEdit);
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(this.BirthDayTextEdit);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(this.RegDateTextEdit);
        }

        private void btnChangeFellowship_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (Tools.FellowshipLookupFrm frm = new FellowshipLookupFrm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _entity.bizMember.Member.ToUpdateFellowship(_member.MemberID, frm.SelectedFellowship);
                        LoadData(_member.MemberID);
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
            }
        }

        private void StatusSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            _member.Status =(int)StatusSpinEdit.EditValue;
            
        }

        private void btnDeleteVisitReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView3.SelectedRowsCount == 0)
                return;
            DialogResult result = MessageBox.Show("Do you want to delete a Selected row?", "Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int row = (gridView3.GetSelectedRows()[0]);
                _entity.bizMemberVisit.MemberVisit.Delete((int)gridView3.GetRowCellValue(row, "ID"));
                MessageBox.Show(Properties.Resources.Success_Save);
                LoadVisitList();
            }
        }

   
    }

}