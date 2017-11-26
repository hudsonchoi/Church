using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace LandWin.Tools
{
    public partial class ProgressDialog : DevExpress.XtraEditors.XtraForm
    {
        public delegate void SetTitleCallback(string text);
        public delegate void SetMessageCallback(string text);
        public delegate void SetValueCallback(int value);
        public delegate void SetValueSucessCallback(int value);
        public delegate void SetValueFailCallback(int value);
        public delegate void SetMaxCallback(int max);
        public delegate void CancelEventHandler();
        public delegate void StopCallback();
        public static event CancelEventHandler CancelEvent;

        private static ProgressDialog instance;
        private static Thread thread = null;

        //text which can be shown as action which is done at the moment
        public static string actionText;

        //text which is shown in front of the numbers; e.g. actionText 102/999
        public static string actionBaseText = "";

        public static void Show(int max)
        {
            instance = new ProgressDialog(MainForm.Instance);
            instance.rProgressBar.Properties.Maximum = max;

            thread = new Thread(new ThreadStart(LaunchForm));
            thread.IsBackground = true;
            thread.Start();
        }

        public static void Stop()
        {
            if (instance != null)
            {
                if (instance.InvokeRequired)
                {
                    StopCallback s = new StopCallback(Stop);
                    instance.Invoke(s);
                }
                else
                {
                    instance.Close();
                    instance.Dispose();
                    instance = null;
                }
            }

            if (thread != null)
            {
                Thread.Sleep(0);
                thread = null;
            }
        }

        private static void LaunchForm()
        {
            ProgressDialog.instance.ShowDialog();
        }

        private ProgressDialog(Form parent)
        {
            InitializeComponent();
            if (parent != null)
            {
                Left = parent.Left + (parent.Width - Width) / 2;
                Top = parent.Top + (parent.Height - Height) / 2;
            }
            this.Height = rProgressBar.Height + rProgressBar.Top * 2 + 4;
        }

        public static void SetTitle(string title)
        {
            if (instance.InvokeRequired) //if another thread called this method
            {
                SetTitleCallback s = new SetTitleCallback(SetTitle);
                instance.Invoke(s, title);
            }
            else
            {
                instance.Text = title;
            }
        }

        public static void SetMessage(string message)
        {
            if (instance.InvokeRequired) //if another thread called this method
            {
                SetMessageCallback s = new SetMessageCallback(SetMessage);
                instance.Invoke(s, message);
            }
            else
            {
                instance.lblMessage.Text = message;
            }
        }

        public static void SetValue(int value)
        {
            if (instance.InvokeRequired) //if another thread called this method
            {
                SetValueCallback s = new SetValueCallback(SetValue);
                instance.Invoke(s, value);
            }
            else
            {
                instance.rProgressBar.Position = value;
                instance.rProgressBar.Update();
                if (!actionBaseText.Equals(""))
                    instance.lblProgress.Text = actionBaseText + " " + value + "/" + instance.rProgressBar.Properties.Maximum;
                else
                    instance.lblProgress.Text = actionText;
            }
        }

        public static void SetMax(int max)
        {
            if (instance.InvokeRequired) //if another thread called this method
            {
                SetMaxCallback s = new SetMaxCallback(SetMax);
                instance.Invoke(s, max);
            }
            else
            {
                instance.rProgressBar.Properties.Maximum = max;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You sure that you want to cancel the operation?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CancelEvent(); //raise the cancel event
            }
        }

   
    }
}