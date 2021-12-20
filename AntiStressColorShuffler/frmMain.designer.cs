namespace AntiStressColorShuffler
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnClose = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.timAnimate = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.timClear = new System.Windows.Forms.Timer(this.components);
            this.btnAnimate = new System.Windows.Forms.Button();
            this.btnAnimateInc = new System.Windows.Forms.Button();
            this.btnAnimateDec = new System.Windows.Forms.Button();
            this.btnSizeDec = new System.Windows.Forms.Button();
            this.btnSizeInc = new System.Windows.Forms.Button();
            this.cmbShape = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnFullscreen = new System.Windows.Forms.Button();
            this.cmbPresets = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::AntiStressColorShuffler.Properties.Resources.exit;
            this.btnClose.Name = "btnClose";
            this.toolTip1.SetToolTip(this.btnClose, resources.GetString("btnClose.ToolTip"));
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pic
            // 
            resources.ApplyResources(this.pic, "pic");
            this.pic.Name = "pic";
            this.pic.TabStop = false;
            this.pic.Paint += new System.Windows.Forms.PaintEventHandler(this.pic1_Paint);
            // 
            // btnShuffle
            // 
            resources.ApplyResources(this.btnShuffle, "btnShuffle");
            this.btnShuffle.Name = "btnShuffle";
            this.toolTip1.SetToolTip(this.btnShuffle, resources.GetString("btnShuffle.ToolTip"));
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // timAnimate
            // 
            this.timAnimate.Interval = 3000;
            this.timAnimate.Tick += new System.EventHandler(this.timAnimate_Tick);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.toolTip1.SetToolTip(this.btnClear, resources.GetString("btnClear.ToolTip"));
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // timClear
            // 
            this.timClear.Interval = 300;
            this.timClear.Tick += new System.EventHandler(this.timClear_Tick);
            // 
            // btnAnimate
            // 
            resources.ApplyResources(this.btnAnimate, "btnAnimate");
            this.btnAnimate.Name = "btnAnimate";
            this.toolTip1.SetToolTip(this.btnAnimate, resources.GetString("btnAnimate.ToolTip"));
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // btnAnimateInc
            // 
            resources.ApplyResources(this.btnAnimateInc, "btnAnimateInc");
            this.btnAnimateInc.Name = "btnAnimateInc";
            this.btnAnimateInc.UseVisualStyleBackColor = true;
            this.btnAnimateInc.Click += new System.EventHandler(this.btnAnimateInc_Click);
            // 
            // btnAnimateDec
            // 
            resources.ApplyResources(this.btnAnimateDec, "btnAnimateDec");
            this.btnAnimateDec.Name = "btnAnimateDec";
            this.btnAnimateDec.UseVisualStyleBackColor = true;
            this.btnAnimateDec.Click += new System.EventHandler(this.btnAnimateDec_Click);
            // 
            // btnSizeDec
            // 
            resources.ApplyResources(this.btnSizeDec, "btnSizeDec");
            this.btnSizeDec.Name = "btnSizeDec";
            this.btnSizeDec.UseVisualStyleBackColor = true;
            this.btnSizeDec.Click += new System.EventHandler(this.btnSizeDec_Click);
            // 
            // btnSizeInc
            // 
            resources.ApplyResources(this.btnSizeInc, "btnSizeInc");
            this.btnSizeInc.Name = "btnSizeInc";
            this.btnSizeInc.UseVisualStyleBackColor = true;
            this.btnSizeInc.Click += new System.EventHandler(this.btnSizeInc_Click);
            // 
            // cmbShape
            // 
            this.cmbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbShape, "cmbShape");
            this.cmbShape.FormattingEnabled = true;
            this.cmbShape.Name = "cmbShape";
            this.cmbShape.SelectedIndexChanged += new System.EventHandler(this.cmbShape_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.toolTip1.SetToolTip(this.linkLabel1, resources.GetString("linkLabel1.ToolTip"));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnFullscreen
            // 
            resources.ApplyResources(this.btnFullscreen, "btnFullscreen");
            this.btnFullscreen.Name = "btnFullscreen";
            this.toolTip1.SetToolTip(this.btnFullscreen, resources.GetString("btnFullscreen.ToolTip"));
            this.btnFullscreen.UseVisualStyleBackColor = true;
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // cmbPresets
            // 
            this.cmbPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbPresets, "cmbPresets");
            this.cmbPresets.FormattingEnabled = true;
            this.cmbPresets.Name = "cmbPresets";
            this.cmbPresets.SelectedIndexChanged += new System.EventHandler(this.cmbPresets_SelectedIndexChanged);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cmbPresets);
            this.Controls.Add(this.btnFullscreen);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cmbShape);
            this.Controls.Add(this.btnSizeDec);
            this.Controls.Add(this.btnSizeInc);
            this.Controls.Add(this.btnAnimateDec);
            this.Controls.Add(this.btnAnimateInc);
            this.Controls.Add(this.btnAnimate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.btnClose);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.Timer timAnimate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer timClear;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.Button btnAnimateInc;
        private System.Windows.Forms.Button btnAnimateDec;
        private System.Windows.Forms.Button btnSizeDec;
        private System.Windows.Forms.Button btnSizeInc;
        private System.Windows.Forms.ComboBox cmbShape;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnFullscreen;
        private System.Windows.Forms.ComboBox cmbPresets;
    }
}
