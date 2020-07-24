using System;
using System.Windows.Forms;

namespace 车辆轨迹数据处理
{
    public partial class Frm_ParameterSetting : Form
    {
        public Frm_ParameterSetting()
        {
            InitializeComponent();
        }

        PublicVariate PublicVariate = new PublicVariate();

        private void Grp_Separator_Leave(object sender, EventArgs e)
        {
            char[] separator = new char[5];
            if (chk_TabSeparated.Checked)
                separator[0] = '\t';
            if (chk_SemicolonSeparated.Checked)
                separator[1] = ';';
            if (chk_CommaSeparated.Checked)
                separator[2] = ',';
            if (chk_SpaceSeparated.Checked)
                separator[3] = ' ';
            if (chk_OtherSeparated.Checked && txt_OtherSeparator.Text != "")
                separator[4] = txt_OtherSeparator.Text.ToCharArray()[0];
            PublicVariate.Separator = separator;

            Properties.Settings.Default.chk_TabSeparated = chk_TabSeparated.Checked;
            Properties.Settings.Default.chk_SemicolonSeparated = chk_SemicolonSeparated.Checked;
            Properties.Settings.Default.chk_CommaSeparated = chk_CommaSeparated.Checked;
            Properties.Settings.Default.chk_SpaceSeparated = chk_SpaceSeparated.Checked;
            Properties.Settings.Default.chk_OtherSeparated = chk_OtherSeparated.Checked;
            Properties.Settings.Default.txt_OtherSeparator = txt_OtherSeparator.Text;
            Properties.Settings.Default.Save();
        }
    }
}
