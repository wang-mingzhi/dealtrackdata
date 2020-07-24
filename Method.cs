using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace 车辆轨迹数据处理 {
    class Method {
        /// <summary>
        /// 打开新的窗体
        /// </summary>
        /// <typeparam name="T">窗体对象：Form</typeparam>
        /// <param name="form">窗体实例</param>
        /// <param name="MdiParent">父窗体</param>
        public void ShowForm<T>(ref T form, Form MdiParent = null) where T : Form, new() {
            if (form == null || form.IsDisposed) {
                form = new T();
                if (MdiParent != null) {
                    form.MdiParent = MdiParent;
                }
            }
            else {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
            }
            form.Show();
        }

        public string OpenFile() {
            OpenFileDialog fileDialog = new OpenFileDialog {
                Filter = "csv文件|*.csv|txt文件|*.txt"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                return fileDialog.FileName;
            }
            return null;
        }

        #region  // 打开目录
        public void OpenDirectory(PublicVariate pv, ToolStripLabel label, TreeView treeView) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog {
                ShowNewFolderButton = true,
                Description = "请选择一个文件夹",
                SelectedPath = Properties.Settings.Default.DirectoryPath
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                pv.filelist.Clear();
                label.Text = $"1/{pv.filelist.Count}";
                PaintTreeView(treeView, folderBrowserDialog.SelectedPath);
                pv.DirectoryPath = folderBrowserDialog.SelectedPath;
            }

            Properties.Settings.Default.DirectoryPath = pv.DirectoryPath;
            Properties.Settings.Default.Save();
        }

        private void PaintTreeView(TreeView treeView, string filepath) {
            try {
                treeView.Nodes.Clear();

                DirectoryInfo[] dir = new DirectoryInfo(filepath).GetDirectories();
                FileInfo[] file = new DirectoryInfo(filepath).GetFiles();

                for (int i = 0; i < dir.Count(); i++)  // 循环文件夹
                {
                    treeView.Nodes.Add(dir[i].Name);
                    GetMultiNode(treeView.Nodes[i], $"{filepath}\\{dir[i].Name}");
                }

                for (int j = 0; j < file.Count(); j++)  // 循环文件
                {
                    treeView.Nodes.Add(file[j].Name);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GetMultiNode(TreeNode treeNode, string path) {
            if (Directory.Exists(path)) {
                DirectoryInfo[] dir = new DirectoryInfo(path).GetDirectories();
                FileInfo[] file = new DirectoryInfo(path).GetFiles();

                if (dir.Count() + file.Count() != 0) {
                    for (int j = 0; j < dir.Count(); j++) {
                        treeNode.Nodes.Add(dir[j].Name);
                        GetMultiNode(treeNode.Nodes[j], $"{path}\\{dir[j].Name}");
                    }

                    for (int j = 0; j < file.Count(); j++) {
                        treeNode.Nodes.Add(file[j].Name);
                    }
                    return true;
                }
            }
            return false;
        }
        #endregion

        public void ReadVirtualCoilsSetting(string filepath, PublicVariate publicVariate) {
            StreamReader sr = new StreamReader(filepath, Encoding.UTF8);
            _ = sr.ReadLine();
            string line;
            while ((line = sr.ReadLine()) != null) {
                string[] lines = line.Split(PublicVariate.Separator);
                PublicVariate.VirtualCoil virtualCoil = new PublicVariate.VirtualCoil {
                    CrossName = lines[0],
                    LaneID = lines[1],
                    LaneType = lines[2],
                    Approach = lines[3]
                };
                if (lines.Length < 10 | (lines.Length - 4) / 2 != 0) {
                    string message = string.Format("不能形成成闭合区域！\r\n{0}", line);
                    MessageBox.Show(message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                GraphicsPath myGraphicsPath = new GraphicsPath();
                PointF[] pointF = new PointF[2];
                for (int i = 4; i < lines.Length; i += 2) {
                    pointF[i] = new PointF(float.Parse(lines[i]), float.Parse(lines[i + 1]));
                }
                myGraphicsPath.AddClosedCurve(pointF, 1);
                publicVariate.VirtualCoils.Add(virtualCoil);
            }
        }

        #region  // 统计交通量
        PublicVariate.Car GetCar;
        public void StatisticTrafficFlow(string filepath, PublicVariate publicVariate) {
            /*
             * 前提假设是：1、车辆总是会从一个进口道进入，从一个出口道出交叉口
             *             2、同一时刻不会存在trackID相同的车辆
             * step1：把line中的信息解析到track里
             * step2：判断车辆是否在字典carList中，若在则读取车辆的trackID和time组成唯一ID，否则添加一条记录；
             * step3：根据step2的ID，判断字典Cars里是否存在该条记录，若无，则新添加一条记录
             * step4：根据step2的ID，然后通过遍历判断车辆是否经过某个线圈，并记录相关信息
             * step5：若车辆从出口道出，则把该车辆的记录从carList中删除
             */
            if (!File.Exists(filepath)) {
                string message = string.Format("文件:{0}\t不存在", filepath);
                MessageBox.Show(message, "系统提示");
                return;
            }

            StreamReader sr = new StreamReader(filepath, Encoding.UTF8);
            _ = sr.ReadLine();
            string line;
            while ((line = sr.ReadLine()) != null) {
                try {
                    // step1:
                    string[] lines = line.Split(PublicVariate.Separator);
                    long time = Convert.ToInt64(lines[1]);
                    string crossID = lines[2];
                    string trackID = lines[5];
                    string carType = lines[9];
                    float x = float.Parse(lines[17]);
                    float y = float.Parse(lines[18]);

                    // step2:
                    if (!publicVariate.tempCars.ContainsKey(trackID)) {
                        publicVariate.tempCars.Add(trackID, new Int64[] { time, time });
                    }
                    // 当超过1600毫秒以上时，同一个trackID认为代表不同车辆
                    if (Math.Abs(time - publicVariate.tempCars[trackID][1]) >= 1600) {
                        publicVariate.tempCars[trackID] = new Int64[] { time, time };
                    }
                    publicVariate.tempCars[trackID][1] = time;
                    string car_key = trackID + "," + publicVariate.tempCars[trackID][0];

                    // step3:
                    if (!publicVariate.Cars.ContainsKey(car_key)) {
                        GetCar = new PublicVariate.Car {
                            ID = car_key,
                            CarType = carType,
                            ExTime = time
                        };
                        publicVariate.Cars.Add(car_key, GetCar);
                    }

                    // step4:判断在哪个线圈，假设数据是按照时间顺序从小到大排列的
                    PublicVariate.Car car = publicVariate.Cars[car_key];
                    string lantype = "道";
                    if (car.EnRoad != null & car.ExRoad != null) {
                        continue;
                    }
                    else if (car.EnRoad == null) {
                        lantype = "进口";
                    }
                    else if (car.ExRoad == null) {
                        lantype = "出口";
                    }

                    foreach (PublicVariate.VirtualCoil virtualCoil in publicVariate.VirtualCoils) {
                        if (crossID == virtualCoil.CrossName & virtualCoil.Approach.Contains(lantype) &
                            virtualCoil.Polygon.IsVisible(x, y)) {
                            car.ExTime = time;
                            car.ExRoad = virtualCoil.Approach;
                            car.ExLaneID = virtualCoil.LaneID;
                            break;
                        }
                    }
                    publicVariate.Cars[car_key] = car;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    continue;
                }
            }
            sr.Dispose();
        }
        #endregion

        public void StatisticParkingTimes() {

        }

        // 增加、读取、修改、判断系统配置文件
        #region
        public void AddItem(string keyName, string keyValue) {
            //添加配置文件的项，键为keyName，值为keyValue
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(keyName, keyValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public bool ExistItem(string keyName) {
            //判断配置文件中是否存在键为keyName的项
            foreach (string key in ConfigurationManager.AppSettings) {
                if (key == keyName) {
                    return true;
                }
            }
            return false;
        }

        public string ValueOfItem(string keyName) {
            //返回配置文件中键为keyName的项的值
            return ConfigurationManager.AppSettings[keyName];
        }

        public void ModifyItem(string keyName, string newKeyValue) {
            //修改配置文件中键为keyName的项的值
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[keyName].Value = newKeyValue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void RemoveItem(string keyName) {
            //删除配置文件键为keyName的项
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(keyName);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static T GetSection<T>(string name) where T : ConfigurationSection {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.GetSection(name) as T;
        }
        #endregion
    }
}
