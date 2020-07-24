using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace 车辆轨迹数据处理
{
    public class PublicVariate
    {
        public int CurrentTime { get; set; } = 0;
        public string DirectoryPath { get; set; } = "";
        public static char[] Separator = { };
        public List<string> filelist = new List<string>();
        // 用来记录线圈的字典
        public List<VirtualCoil> VirtualCoils = new List<VirtualCoil>();
        // 用来临时存放车辆的信息，key=trackid，value=[刚被观测到的time,驶出的时间time]
        public Dictionary<string, Int64[]> tempCars = new Dictionary<string, Int64[]>();
        // 车辆列表，用来记录通过交叉口的所有车辆的信息，key=time+","+trackid，value=car
        public Dictionary<string, Car> Cars = new Dictionary<string, Car>();

        /// <summary>
        /// 对车辆各种属性进行设置
        /// </summary>
        public struct Car
        {
            public string ID { get; set; }          // 车辆ID由Traceid和time组成，是车辆的唯一标识
            public string CarType { get; set; }     // 记录车辆类型，后期用来判断大车率等
            public long EnTime { get; set; }        // 车辆进入观测区域的时间,13位时间戳格式
            public string EnRoad { get; set; }      // 车辆从哪个路口进入交叉口
            public string EnLaneID { get; set; }    // 车辆从哪个车道进入交叉口
            public long ExTime { get; set; }        // 车辆驶出观测区域的时间,13位时间戳格式
            public string ExRoad { get; set; }      // 车辆从哪个路口驶出交叉口
            public string ExLaneID { get; set; }    // 车辆从哪个车道驶出交叉口
            public double Distance { get; set; }    // 车辆过停车线后在交叉口的行驶里程
            public double AvgSpeed { get; set; }    // 车辆通过交叉口的平均速度
            public double SignalDelay { get; set; } // 由于信号灯导致的信控延误
            public double Delay { get; set; }       // 车辆通过交叉口的延误
            public int ParkingTimes { get; set; }   // 车辆通过交叉口的停车次数
            public int QueueLength { get; set; }    // 车辆排队长度
            public int QueueTimes { get; set; }     // 车辆排队次数，用来判断二次排队等
            public int Count { get; set; }          // 车辆通过交叉口过程中产生的数据条数
        }

        /// <summary>
        /// 定义矩形虚拟线圈所在位置
        /// </summary>
        public struct VirtualCoil
        {
            public string ID { get; set; }              // 线圈的唯一标识符
            public string LaneID { get; set; }          // 线圈所在车道的编号
            public string Approach { get; set; }       // 线圈在车道的方向，车道方向如：北进口、东出口
            public string LaneType { get; set; }        // 车道类型，左转、直行等
            public string CrossName { get; set; }         // 线圈所在交叉口的名称
            public GraphicsPath Polygon { get; set; }   // 线圈包含的区域
        }
    }
}
