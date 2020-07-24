namespace 车辆轨迹数据处理
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Tsb_OpenDirectory = new System.Windows.Forms.ToolStripButton();
            this.Tsb_VirtualCoilSetting = new System.Windows.Forms.ToolStripButton();
            this.Tsb_ParameterSetting = new System.Windows.Forms.ToolStripButton();
            this.Tsb_DealData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Tsl_Progress = new System.Windows.Forms.ToolStripLabel();
            this.Tapb_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.Tvw_Directory = new System.Windows.Forms.TreeView();
            this.Txt_Result = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Tsl_RowCount = new System.Windows.Forms.ToolStripLabel();
            this.Tsb_ShowVirtualCoil = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsb_OpenDirectory,
            this.toolStripSeparator2,
            this.Tsb_VirtualCoilSetting,
            this.Tsb_ParameterSetting,
            this.Tsb_ShowVirtualCoil,
            this.Tsb_DealData,
            this.toolStripSeparator1,
            this.Tsl_RowCount,
            this.Tapb_Progress,
            this.Tsl_Progress});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(693, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Tsb_OpenDirectory
            // 
            this.Tsb_OpenDirectory.AutoSize = false;
            this.Tsb_OpenDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Tsb_OpenDirectory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_OpenDirectory.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_OpenDirectory.Image")));
            this.Tsb_OpenDirectory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Tsb_OpenDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_OpenDirectory.Name = "Tsb_OpenDirectory";
            this.Tsb_OpenDirectory.Size = new System.Drawing.Size(35, 35);
            this.Tsb_OpenDirectory.Text = "打开目录";
            this.Tsb_OpenDirectory.Click += new System.EventHandler(this.Tsb_OpenDirectory_Click);
            // 
            // Tsb_VirtualCoilSetting
            // 
            this.Tsb_VirtualCoilSetting.AutoSize = false;
            this.Tsb_VirtualCoilSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Tsb_VirtualCoilSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_VirtualCoilSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Tsb_VirtualCoilSetting.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_VirtualCoilSetting.Image")));
            this.Tsb_VirtualCoilSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Tsb_VirtualCoilSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_VirtualCoilSetting.Name = "Tsb_VirtualCoilSetting";
            this.Tsb_VirtualCoilSetting.Size = new System.Drawing.Size(35, 35);
            this.Tsb_VirtualCoilSetting.Text = "读取线圈配置文件";
            this.Tsb_VirtualCoilSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.Tsb_VirtualCoilSetting.Click += new System.EventHandler(this.Tsb_VirtualCoilSetting_Click);
            // 
            // Tsb_ParameterSetting
            // 
            this.Tsb_ParameterSetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Tsb_ParameterSetting.AutoSize = false;
            this.Tsb_ParameterSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_ParameterSetting.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_ParameterSetting.Image")));
            this.Tsb_ParameterSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Tsb_ParameterSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_ParameterSetting.Name = "Tsb_ParameterSetting";
            this.Tsb_ParameterSetting.Size = new System.Drawing.Size(35, 35);
            this.Tsb_ParameterSetting.Text = "参数设置";
            this.Tsb_ParameterSetting.Click += new System.EventHandler(this.Tsb_ParameterSetting_Click);
            // 
            // Tsb_DealData
            // 
            this.Tsb_DealData.AutoSize = false;
            this.Tsb_DealData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Tsb_DealData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_DealData.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_DealData.Image")));
            this.Tsb_DealData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Tsb_DealData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_DealData.Name = "Tsb_DealData";
            this.Tsb_DealData.Size = new System.Drawing.Size(35, 35);
            this.Tsb_DealData.Text = "处理文件";
            this.Tsb_DealData.Click += new System.EventHandler(this.Tsb_DealData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // Tsl_Progress
            // 
            this.Tsl_Progress.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tsl_Progress.Name = "Tsl_Progress";
            this.Tsl_Progress.Size = new System.Drawing.Size(45, 35);
            this.Tsl_Progress.Text = "(0/0)";
            // 
            // Tapb_Progress
            // 
            this.Tapb_Progress.Name = "Tapb_Progress";
            this.Tapb_Progress.Size = new System.Drawing.Size(100, 35);
            // 
            // Tvw_Directory
            // 
            this.Tvw_Directory.CheckBoxes = true;
            this.Tvw_Directory.Location = new System.Drawing.Point(3, 3);
            this.Tvw_Directory.Name = "Tvw_Directory";
            this.Tvw_Directory.Size = new System.Drawing.Size(339, 383);
            this.Tvw_Directory.TabIndex = 2;
            this.Tvw_Directory.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Tvw_Directory_AfterCheck);
            // 
            // Txt_Result
            // 
            this.Txt_Result.Location = new System.Drawing.Point(3, 3);
            this.Txt_Result.Multiline = true;
            this.Txt_Result.Name = "Txt_Result";
            this.Txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Txt_Result.Size = new System.Drawing.Size(338, 383);
            this.Txt_Result.TabIndex = 17;
            this.Txt_Result.Text = "要保证数据是按照时间升序排列的";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Tvw_Directory);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.SplitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Txt_Result);
            this.splitContainer1.Panel2.Resize += new System.EventHandler(this.SplitContainer1_Panel2_Resize);
            this.splitContainer1.Size = new System.Drawing.Size(693, 389);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 19;
            this.splitContainer1.Resize += new System.EventHandler(this.SplitContainer1_Resize);
            // 
            // Tsl_RowCount
            // 
            this.Tsl_RowCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tsl_RowCount.Name = "Tsl_RowCount";
            this.Tsl_RowCount.Size = new System.Drawing.Size(19, 35);
            this.Tsl_RowCount.Text = "0";
            // 
            // Tsb_ShowVirtualCoil
            // 
            this.Tsb_ShowVirtualCoil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_ShowVirtualCoil.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_ShowVirtualCoil.Image")));
            this.Tsb_ShowVirtualCoil.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Tsb_ShowVirtualCoil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_ShowVirtualCoil.Name = "Tsb_ShowVirtualCoil";
            this.Tsb_ShowVirtualCoil.Size = new System.Drawing.Size(36, 35);
            this.Tsb_ShowVirtualCoil.Text = "显示线圈";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 429);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Frm_Main";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Resize += new System.EventHandler(this.Frm_Main_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TreeView Tvw_Directory;
        private System.Windows.Forms.ToolStripButton Tsb_DealData;
        private System.Windows.Forms.ToolStripButton Tsb_OpenDirectory;
        private System.Windows.Forms.ToolStripButton Tsb_VirtualCoilSetting;
        private System.Windows.Forms.ToolStripButton Tsb_ParameterSetting;
        private System.Windows.Forms.TextBox Txt_Result;
        private System.Windows.Forms.ToolStripProgressBar Tapb_Progress;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel Tsl_Progress;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripLabel Tsl_RowCount;
        private System.Windows.Forms.ToolStripButton Tsb_ShowVirtualCoil;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

