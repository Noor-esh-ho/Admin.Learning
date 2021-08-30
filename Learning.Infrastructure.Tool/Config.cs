
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Linq;

namespace Learning.Infrasturcture.Tool
{
    public class LatLng
    {
        public LatLng(double x, double y)
        {
            latitude = x;
            longitude = y;
        }
        public double latitude;
        public double longitude;
    }

    /// <summary>
    /// 配置文件操作类
    /// </summary>
    public class Config
    {


        public static Random rd = new Random();


        //地球半径，单位米
        private const double EARTH_RADIUS = 6378137;
        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }

        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }

        /// <summary>
        /// 判断两个经纬度的距离
        /// </summary>
        /// <param name="j1">第一个经度</param>
        /// <param name="w1">第一个纬度</param>
        /// <param name="j2">第二个经度</param>
        /// <param name="w2">第二个纬度</param>
        /// <returns></returns>
        public double getGreatCircleDistance(double j1, double w1, double j2, double w2)
        {
            LatLng start = new LatLng(j1, w1);
            LatLng end = new LatLng(j2, w2);

            double lat1 = (Math.PI / 180) * start.latitude;
            double lat2 = (Math.PI / 180) * end.latitude;

            double lon1 = (Math.PI / 180) * start.longitude;
            double lon2 = (Math.PI / 180) * end.longitude;

            double r = 6371000; //地球半径(米)

            double dd = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1)) * r;
            return dd;
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandom(int min, int max)
        {
            return rd.Next(min, max);
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {

            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }



        

        


      

        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <returns></returns>
        public static string GUID()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }
    }
}
