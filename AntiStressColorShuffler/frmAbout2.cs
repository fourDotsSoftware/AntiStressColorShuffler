using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AntiStressColorShuffler
{
    public partial class frmAbout : Form
    {
        public static string lblf = "";

        public static string[] bufluf = new string[5];
        public static List<string> lstbufluf = new List<string>();

        // license email
        public static string LDT = "";

        public frmAbout()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.anti_stress_color_shuffler_48;
        }
                     
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text = Module.ApplicationTitle + "\n\n" +
            "Developed by Alexander Triantafyllou\n" +
            "Copyright © 2019 - 4dots Software\n";

            ullProductWebpage.Text = Module.ProductWebpageURL;

            /*
            if (!SettingsHelper.RenMove && !frmPurchase.RenMove)
            {
                if (frmAbout.LDT == string.Empty)
                {
                    lblRegistered.Text = TranslateHelper.Translate("Trial Version - Unlicensed");
                }
                else if (frmAbout.LDT.StartsWith("BUS"))
                {
                    lblRegistered.Text = TranslateHelper.Translate("Business Version - Licensed");
                }
                else if (!frmAbout.LDT.StartsWith("BUS"))
                {
                    lblRegistered.Text = TranslateHelper.Translate("Personal/EDU Version - Licensed");
                }

                lblLicenseKey.Text = frmAbout.LDT;

                if (frmAbout.LDT != string.Empty)
                {
                    btnRegister.Visible = false;
                    btnBuy.Visible = false;
                }
            }
            else
            {
                lblRegistered.Text = TranslateHelper.Translate("Trial Version - Unlicensed");
            }*/

            DownloadSuggestionsHelper ds = new DownloadSuggestionsHelper();
            ds.SetupDownloadMenuItems(downloadToolStripMenuItem);

            AddLanguageMenuItems();
        }

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Properties.Settings.Default.Language == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);

                if (k < 25)
                {
                    languages1ToolStripMenuItem.DropDownItems.Add(ti);
                }
                else
                {
                    languages2ToolStripMenuItem.DropDownItems.Add(ti);
                }

                //languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            //for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            for (int k = 0; k < languages1ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages1ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }

            for (int k = 0; k < languages2ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages2ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }

        private bool InChangeLanguage = false;

        private void ChangeLanguage(string language_code)
        {
            try
            {
                InChangeLanguage = true;

                Properties.Settings.Default.Language = language_code;
                frmLanguage.SetLanguage();

                Properties.Settings.Default.Save();

                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);

                Environment.Exit(0);                
            }
            finally
            {
                InChangeLanguage = false;
            }
        }

        #endregion
                
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/support/");
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Module.BuyURL);

            System.Diagnostics.Process.Start("http://www.4dots-software.com/donate.php");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //frmAdeia f = new frmAdeia();
            //f.ShowDialog();
        }

        #region Help

        private void helpGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.StartupPath + "\\Video Cutter Joiner Expert - User's Manual.chm");
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private void pleaseDonateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/donate.php");
        }

        private void dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/downloads/4dots-Software-PRODUCT-CATALOG.pdf");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void tiHelpFeedback_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void visit4dotsSoftwareWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateHelper.CheckVersion(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch { }
        }

        #endregion
    }
}