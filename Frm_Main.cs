using System;
using System.Windows.Forms;

namespace 车辆轨迹数据处理 {
    public partial class Frm_Main : Form {
        public Frm_Main() {
            InitializeComponent();
        }

        readonly PublicVariate pv = new PublicVariate();
        readonly Method Method = new Method();

        private void Frm_Main_Load(object sender, EventArgs e) {
            Frm_Main_Resize(this, e);
            char[] separator = new char[5];
            if (Properties.Settings.Default.chk_TabSeparated)
                separator[0] = '\t';
            if (Properties.Settings.Default.chk_SemicolonSeparated)
                separator[1] = ';';
            if (Properties.Settings.Default.chk_CommaSeparated)
                separator[2] = ',';
            if (Properties.Settings.Default.chk_SpaceSeparated)
                separator[3] = ' ';
            if (Properties.Settings.Default.txt_OtherSeparator != "")
                separator[4] = Properties.Settings.Default.txt_OtherSeparator.ToCharArray()[0];
            PublicVariate.Separator = separator;
        }

        private void Frm_Main_Resize(object sender, EventArgs e) {
            splitContainer1.Location = new System.Drawing.Point(1, toolStrip1.Height + 1);
            splitContainer1.Height = ClientRectangle.Height - 2 - toolStrip1.Height;
            splitContainer1.Width = ClientRectangle.Width - 2;
        }

        private void Tsb_OpenDirectory_Click(object sender, EventArgs e) {
            Method.OpenDirectory(pv, Tsl_Progress, Tvw_Directory);
        }

        private void Tvw_Directory_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Node.Nodes.Count == 0) {
                string filePath = pv.DirectoryPath + Tvw_Directory.PathSeparator + e.Node.FullPath;
                if (!pv.filelist.Contains(filePath) & e.Node.Checked) {
                    pv.filelist.Add(filePath);
                }
                if (pv.filelist.Contains(filePath) & !e.Node.Checked) {
                    pv.filelist.Remove(filePath);
                }
                Tsl_Progress.Text = $"1/{pv.filelist.Count}";
            }
        }

        private void Tsb_DealData_Click(object sender, EventArgs e) {
            if (pv.filelist.Count == 0) {
                MessageBox.Show("请选择要处理的文件");
                return;
            }
            foreach (string filepath in pv.filelist) {
                Method.StatisticTrafficFlow(filepath, pv);
            }
        }

        private void Tsb_VirtualCoilSetting_Click(object sender, EventArgs e) {
            string filepath = Method.OpenFile();
            if (filepath != null) {
                try {
                    Method.ReadVirtualCoilsSetting(filepath, pv);
                    string message = string.Format("读取成功，共{0}个线圈。", pv.VirtualCoils.Count);
                    MessageBox.Show(message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        Frm_ParameterSetting Frm_ParameterSetting = null;
        private void Tsb_ParameterSetting_Click(object sender, EventArgs e) {
            Method.ShowForm(ref Frm_ParameterSetting);
        }

        private void SplitContainer1_Resize(object sender, EventArgs e) {
            Tvw_Directory.Location = new System.Drawing.Point(3, 3);
            Tvw_Directory.Height = splitContainer1.Panel1.Height - 6;
            Tvw_Directory.Width = splitContainer1.Panel1.Width - 6;

            Txt_Result.Location = new System.Drawing.Point(3, 3);
            Txt_Result.Height = splitContainer1.Panel2.Height - 6;
            Txt_Result.Width = splitContainer1.Panel2.Width - 6;
        }

        private void SplitContainer1_Panel2_Resize(object sender, EventArgs e) {
            SplitContainer1_Resize(this, e);
        }

        private void SplitContainer1_Panel1_Resize(object sender, EventArgs e) {
            SplitContainer1_Resize(this, e);
        }
    }
}
