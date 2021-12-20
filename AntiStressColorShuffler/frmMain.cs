using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AntiStressColorShuffler
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.anti_stress_color_shuffler_48;
        }

        private bool InLoad = false;


        private void frmReport_Load(object sender, EventArgs e)
        {
            try
            {

                InLoad = true;

                cmbPresets.Items.Add(TranslateHelper.Translate("Preset") + " 1");
                cmbPresets.Items.Add(TranslateHelper.Translate("Preset") + " 2");
                cmbPresets.Items.Add(TranslateHelper.Translate("Preset") + " 3");
                cmbPresets.Items.Add(TranslateHelper.Translate("Preset") + " 4");
                cmbPresets.Items.Add(TranslateHelper.Translate("Preset") + " 5");
                cmbPresets.Items.Add(TranslateHelper.Translate("Preset") + " 6");
                cmbPresets.Items.Add(TranslateHelper.Translate("Preset") + " 7");

                cmbShape.Items.Add(TranslateHelper.Translate("Triangles"));
                cmbShape.Items.Add(TranslateHelper.Translate("Rectangles"));
                cmbShape.Items.Add(TranslateHelper.Translate("Circles"));
                cmbShape.Items.Add(TranslateHelper.Translate("Linear"));
                cmbShape.Items.Add(TranslateHelper.Translate("Bars"));

                cmbShape.SelectedIndex = Properties.Settings.Default.ShapeType;

                SetToolTips();

                this.Text = Module.ApplicationTitle;

                try
                {
                    System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
                    KnownColor[] allColors = new KnownColor[colorsArray.Length];
                    Array.Copy(colorsArray, allColors, colorsArray.Length);

                }
                catch { }

                UpdateHelper.InitializeCheckVersionWeek();

                if (!Properties.Settings.Default.Initialized)
                {
                    Properties.Settings.Default.Initialized = true;

                    cmbPresets.SelectedIndex = 3;
                    btnAnimate_Click(null, null);
                }

            }
            finally
            {
                InLoad = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int kCount = 0;
        private int jCount = 0;

        private void pic1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            timAnimate.Enabled = false;

            timClear.Enabled = false;

            PaintPic();
        }

        private void timAnimate_Tick(object sender, EventArgs e)
        {
            PaintPic();
        }

        List<int> lstClearRectangle = new List<int>();

        private void timClear_Tick(object sender, EventArgs e)
        {
            if (lstClearRectangle.Count == 0)
            {
                timClear.Enabled = false;

                //MessageBox.Show("Cleared All !");

                timClear.Enabled = false;

                return;
            }


            Random r = new Random();

            int rri = r.Next(0, lstClearRectangle.Count - 1);

            int ri = lstClearRectangle[rri];            

            lstClearRectangle.RemoveAt(rri);

            int dw = pic.Width % Properties.Settings.Default.ShapeSize;
            decimal ddw = (decimal)dw;
            decimal d2 = (decimal)2;
            decimal dk = ddw / d2;
            int idk = (int)dk;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (Properties.Settings.Default.ShapeType == 4)
                {
                    int rk = ri;

                    g.FillRectangle(Brushes.White,
                   idk+rk * Properties.Settings.Default.ShapeSize,
                   0,
                   Properties.Settings.Default.ShapeSize,
                   bmp.Height);
                }
                else
                {
                    int rk = ri / jCount;
                    int rj = ri % jCount;

                    g.FillRectangle(Brushes.White,
                   idk+rk * Properties.Settings.Default.ShapeSize,
                   rj * Properties.Settings.Default.ShapeSize,
                   Properties.Settings.Default.ShapeSize,
                   Properties.Settings.Default.ShapeSize);
                }
            }

            pic.Image = bmp;

            pic.Invalidate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            timClear.Enabled = false;

            timAnimate.Enabled = false;

            lstClearRectangle.Clear();            

            if (Properties.Settings.Default.ShapeType != 4)
            {
                for (int k = 0; k < kCount; k++)
                {
                    for (int j = 0; j < jCount; j++)
                    {
                        lstClearRectangle.Add(k * jCount + j);
                    }
                }
            }
            else
            {
                for (int k = 0; k < kCount; k++)
                {
                    lstClearRectangle.Add(k);
                }
            }            

            timClear.Enabled = true;
        }

        private void btnSizeInc_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShapeSize = Properties.Settings.Default.ShapeSize + 4;

            SetToolTips();

            PaintPic();
        }

        private void btnSizeDec_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShapeSize = Math.Max(4,Properties.Settings.Default.ShapeSize - 4);

            SetToolTips();

            PaintPic();
        }

        private Bitmap bmp = null;

        private bool InPaintPic = false;

        private void PaintPic()
        {
            if (InPaintPic) return;

            try
            {
                InPaintPic = true;

                try
                {
                    if (bmp != null)
                    {
                        bmp.Dispose();
                        bmp = null;
                        GC.Collect();
                        //GC.WaitForPendingFinalizers();
                    }
                }
                catch { }

                bmp = new Bitmap(pic.Width, pic.Height);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    try
                    {
                        System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
                        KnownColor[] allColors = new KnownColor[colorsArray.Length];
                        Array.Copy(colorsArray, allColors, colorsArray.Length);

                        Random r = new Random();

                        int width = Properties.Settings.Default.ShapeSize;
                        int height = Properties.Settings.Default.ShapeSize;

                        kCount = 0;
                        jCount = 0;

                        int dw = pic.Width % width;
                        decimal ddw = (decimal)dw;
                        decimal d2 = (decimal)2;
                        decimal dk = ddw / d2;
                        int idk = (int)dk;

                        for (int k = idk; k <= pic.Width - width; k += width)
                        {
                            kCount++;

                            if (Properties.Settings.Default.ShapeType != 4)
                            {
                                for (int j = 0; j <= pic.Height - height; j += height)
                                {
                                    if (k == idk)
                                    {
                                        jCount++;
                                    }

                                    //Color c = Color.FromKnownColor(allColors[r.Next(0, allColors.Length - 1)]);
                                    Color c = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                                    Color c1 = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));

                                    //Brush b=new SolidBrush(c);

                                    //System.Drawing.Drawing2D.LinearGradientBrush lbr = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(width, 0), c, c1);

                                    //System.Drawing.Drawing2D.LinearGradientBrush lbr = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(width, 0), c, Color.White);

                                    if (Properties.Settings.Default.ShapeType == 0)
                                    {

                                        // Create a path that consists of a single ellipse.
                                        GraphicsPath path = new GraphicsPath();

                                        path.AddPolygon(new Point[] { new Point(k, j + height), new Point(k + width / 2, j), new Point(k + width, j + height) });

                                        // Use the path to construct a brush.
                                        PathGradientBrush pthGrBrush = new PathGradientBrush(path);
                                        // Set the color at the center of the path to blue.
                                        //1pthGrBrush.CenterColor = Color.FromArgb(255, 0, 0, 255);

                                        pthGrBrush.CenterColor = Color.White;

                                        // Set the color along the entire boundary 
                                        // of the path to aqua.
                                        Color[] colors = { c };

                                        pthGrBrush.SurroundColors = colors;

                                        g.FillPolygon(pthGrBrush, new Point[] { new Point(k, j + height), new Point(k + width / 2, j), new Point(k + width, j + height) });

                                        pthGrBrush.Dispose();
                                        path.Dispose();
                                    }
                                    else if (Properties.Settings.Default.ShapeType == 1)
                                    {
                                        GraphicsPath path = new GraphicsPath();

                                        path.AddRectangle(new Rectangle(k, j, width, height));

                                        // Use the path to construct a brush.
                                        PathGradientBrush pthGrBrush = new PathGradientBrush(path);

                                        pthGrBrush.CenterColor = Color.White;

                                        // Set the color along the entire boundary 
                                        // of the path to aqua.
                                        Color[] colors = { c };

                                        pthGrBrush.SurroundColors = colors;

                                        g.FillRectangle(pthGrBrush, k, j, width, height);

                                        pthGrBrush.Dispose();
                                        path.Dispose();
                                    }
                                    else if (Properties.Settings.Default.ShapeType == 2)
                                    {
                                        GraphicsPath path = new GraphicsPath();

                                        path.AddEllipse(new Rectangle(k, j, width, height));

                                        // Use the path to construct a brush.
                                        PathGradientBrush pthGrBrush = new PathGradientBrush(path);

                                        pthGrBrush.CenterColor = Color.White;

                                        // Set the color along the entire boundary 
                                        // of the path to aqua.
                                        Color[] colors = { c };

                                        pthGrBrush.SurroundColors = colors;

                                        g.FillEllipse(pthGrBrush, k, j, width, height);

                                        pthGrBrush.Dispose();
                                        path.Dispose();
                                    }
                                    else if (Properties.Settings.Default.ShapeType == 3)
                                    {
                                        System.Drawing.Drawing2D.LinearGradientBrush lbr = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(k, j), new Point(k + width, j), c, Color.White);

                                        g.FillRectangle(lbr, k, j, width, height);

                                        lbr.Dispose();

                                        //e.Graphics.FillRectangle(b, k, j, width, height);                                    

                                        //b.Dispose();                                    
                                    }
                                }
                            }
                            else if (Properties.Settings.Default.ShapeType==4)
                            {
                                Color c = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));

                                System.Drawing.Drawing2D.LinearGradientBrush lbr = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(k, 0), new Point(k + width, 0), c, Color.White);

                                g.FillRectangle(lbr, k,0, width, pic.Height);

                                lbr.Dispose();
                            }
                        }
                    }
                    catch { }
                }

                try
                {
                    if (pic.Image != null)
                    {
                        pic.Image.Dispose();
                        pic.Image = null;
                        GC.Collect();
                        //GC.WaitForPendingFinalizers();
                    }
                }
                catch { }

                pic.Image = bmp;

                pic.Invalidate();

            }
            finally
            {
                InPaintPic = false;
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                PaintPic();

                if (timClear.Enabled)
                {
                    timClear.Enabled = false;

                    btnClear_Click(null, null);
                }
            }
        }

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            timAnimate.Interval = Properties.Settings.Default.AnimationSpeed;

            timClear.Enabled = false;

            timAnimate.Enabled = true;
        }

        private void btnAnimateDec_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AnimationSpeed = Math.Max(500,Properties.Settings.Default.AnimationSpeed - 1000);

            SetToolTips();

            btnAnimate_Click(null, null);
        }

        private void btnAnimateInc_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AnimationSpeed == 500)
            {
                Properties.Settings.Default.AnimationSpeed = 1000;
            }
            else
            {
                Properties.Settings.Default.AnimationSpeed = Properties.Settings.Default.AnimationSpeed + 1000;
            }

            SetToolTips();

            btnAnimate_Click(null, null);
        }

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShapeType = cmbShape.SelectedIndex;

            PaintPic();
        }

        private void SetToolTips()
        {
            if (Properties.Settings.Default.AnimationSpeed == 500)
            {
                toolTip1.SetToolTip(btnAnimateDec, TranslateHelper.Translate("Set Animation Speed to ") + "500"+" ms");
                toolTip1.SetToolTip(btnAnimateInc, TranslateHelper.Translate("Set Animation Speed to ") + "1000" + " ms");
            }
            else if (Properties.Settings.Default.AnimationSpeed == 1000)
            {
                toolTip1.SetToolTip(btnAnimateDec, TranslateHelper.Translate("Set Animation Speed to ") + "500" + " ms");
                toolTip1.SetToolTip(btnAnimateInc, TranslateHelper.Translate("Set Animation Speed to ") + "2000" + " ms");
            }
            else
            {
                int an = Properties.Settings.Default.AnimationSpeed;

                int an1 = an - 1000;
                int an2 = an + 1000;

                toolTip1.SetToolTip(btnAnimateDec, TranslateHelper.Translate("Set Animation Speed to ") + an1.ToString() + " ms");
                toolTip1.SetToolTip(btnAnimateInc, TranslateHelper.Translate("Set Animation Speed to ") + an2.ToString() + " ms");
            }

            if (Properties.Settings.Default.ShapeSize == 4)
            {
                toolTip1.SetToolTip(btnSizeDec, TranslateHelper.Translate("Decrease Shape Size to ") + "4" + " pixels");
                toolTip1.SetToolTip(btnSizeInc, TranslateHelper.Translate("Increase Shape Size to ") + "8" + " pixels");                
            }
            else
            {
                int sz = Properties.Settings.Default.ShapeSize;

                int sz1 = sz - 4;
                int sz2 = sz + 4;

                toolTip1.SetToolTip(btnSizeDec, TranslateHelper.Translate("Decrease Shape Size to ") + sz1.ToString() + " pixels");
                toolTip1.SetToolTip(btnSizeInc, TranslateHelper.Translate("Increase Shape Size to ") + sz2.ToString() + " pixels");
                
            }
        }

        private void urlLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private bool wasMaxBeforeFullscreen = false;

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            foreach (Control co in this.Controls)
            {
                if (co != pic)
                {
                    co.Visible = false;
                }
            }

            string str1 = this.Width.ToString() + "|" + this.Height.ToString();
                        
            this.Tag = str1;

            wasMaxBeforeFullscreen = (WindowState == FormWindowState.Maximized);            

            string str = pic.Width.ToString() + "|" + pic.Height.ToString();            

            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = System.Windows.Forms.Screen.FromHandle(this.Handle).Bounds;

            pic.Bounds = System.Windows.Forms.Screen.FromHandle(this.Handle).Bounds;
            pic.Tag = str;

            PaintPic();

            this.CenterToScreen();

            this.BringToFront();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                int spos1 = this.Tag.ToString().IndexOf("|");

                if (spos1 > 0)
                {
                    if (!wasMaxBeforeFullscreen)
                    {
                        WindowState = FormWindowState.Normal;
                    }

                    this.FormBorderStyle = FormBorderStyle.Sizable;

                    int width = int.Parse(this.Tag.ToString().Substring(0, spos1));
                    int height = int.Parse(this.Tag.ToString().Substring(spos1 + 1));

                    this.Width = width;
                    this.Height = height;                                                            
                }

                int spos = pic.Tag.ToString().IndexOf("|");

                if (spos > 0)
                {                    
                    int width = int.Parse(pic.Tag.ToString().Substring(0, spos));
                    int height = int.Parse(pic.Tag.ToString().Substring(spos+1));

                    pic.Width = width;
                    pic.Height = height;
                    pic.Top = 0;
                    pic.Left = 0;

                    foreach (Control co in this.Controls)
                    {
                        co.Visible = true;
                    }                                        
                }
            }
        }

        private void cmbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPresets.SelectedIndex == 0)
            {
                Properties.Settings.Default.ShapeType = 1;
                Properties.Settings.Default.ShapeSize = 8;
            }
            else if (cmbPresets.SelectedIndex == 1)
            {
                Properties.Settings.Default.ShapeType = 2;
                Properties.Settings.Default.ShapeSize = 12;
            }
            else if (cmbPresets.SelectedIndex == 2)
            {
                Properties.Settings.Default.ShapeType = 4;
                Properties.Settings.Default.ShapeSize = 8;
            }
            else if (cmbPresets.SelectedIndex == 3)
            {
                Properties.Settings.Default.ShapeType = 4;
                Properties.Settings.Default.ShapeSize = 16;
            }
            else if (cmbPresets.SelectedIndex == 4)
            {
                Properties.Settings.Default.ShapeType = 0;
                Properties.Settings.Default.ShapeSize = 28;
            }
            else if (cmbPresets.SelectedIndex == 5)
            {
                Properties.Settings.Default.ShapeType = 3;
                Properties.Settings.Default.ShapeSize = 28;
            }
            else if (cmbPresets.SelectedIndex == 6)
            {
                Properties.Settings.Default.ShapeType = 1;
                Properties.Settings.Default.ShapeSize = 16;
            }

            PaintPic();

            if (!InLoad)
            {
                btnAnimate_Click(null, null);
            }
        }
    }
}
