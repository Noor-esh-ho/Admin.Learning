using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrasturcture.Tool
{
    public static class DateUtil
    {

        /// <summary>
        /// 获取当月第一天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetMonthFirstDay()
        {
            return DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
        }

        /// <summary>
        /// 获取当月最后一天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetMonthLastDay()
        {
            return GetMonthFirstDay().AddMonths(1).AddSeconds(-1);
        }

        /// <summary>
        /// 通过时间生成 对应字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateToString(DateTime? dt, out int surplusSS)
        {
            surplusSS = -10;

            var now = DateTime.Now;
            var newDt = dt.Value;
            TimeSpan ts = newDt - now;
            var day = (int)(ts.TotalDays);
            string msg = "";
            switch (day)
            {
                case 1:
                    msg = "明天";
                    break;
                case 2:
                    msg = "后天";
                    break;
                case 0:
                    surplusSS = (int)ts.TotalSeconds;
                    if (surplusSS < 0)
                    {
                        msg = $"<del>{dt.Value.ToString("MM月dd日")}</del> <label class='label label-danger'>已过期<label>";
                    }
                    else
                    {
                        msg = $" {ts.Hours}时 {ts.Minutes}分 {ts.Seconds}秒 后";
                    }
                    break;
                case -1:
                    msg = "<del>昨天</del> <label style='float:right;margin-right:5px;' class='label label-danger' >已过期</label>";
                    break;
                case -2:
                    msg = "<del>前天</del> <label style='float:right;margin-right:5px;' class='label label-danger' >已过期</label>";
                    break;
                default:
                    if (day > 0)
                    {
                        msg = $"还剩 {day} 天";
                    }
                    else
                    {
                        msg = $"<del>{Math.Abs(day)}天前</del> <label style='float:right;margin-right:5px;' class='label label-danger' >已过期</label>";
                    }
                    break;
            }

            return msg;


        }

        /// <summary>  
        /// 得到本周第一天(以星期天为第一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekFirstDaySun(DateTime datetime)
        {
            //星期天为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>  
        /// 得到本周第一天(以星期一为第一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>  
        /// 得到本周最后一天(以星期六为最后一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekLastDaySat(DateTime datetime)
        {
            //星期六为最后一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (7 - weeknow) - 1;

            //本周最后一天  
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        /// <summary>  
        /// 得到本周最后一天(以星期天为最后一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekLastDaySun(DateTime datetime)
        {
            //星期天为最后一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最后一天  
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }




        /// <summary>
        /// 获取时间为本月第几周
        /// </summary>
        /// <param name="daytime"></param>
        /// <returns></returns>
        public static int GetWeekNumInMonth(DateTime daytime)
        {
            int dayInMonth = daytime.Day;
            //本月第一天  
            DateTime firstDay = daytime.AddDays(1 - daytime.Day);
            //本月第一天是周几  
            int weekday = (int)firstDay.DayOfWeek;
            //本月第一周有几天  
            int firstWeekEndDay = 7 - (weekday - 1);
            //当前日期和第一周之差  
            int diffday = dayInMonth - firstWeekEndDay;
            diffday = diffday > 0 ? diffday : 1;
            //当前是第几周,如果整除7就减一天  
            int WeekNumInMonth = ((diffday % 7) == 0
             ? (diffday / 7 - 1)
             : (diffday / 7)) + 1 + (dayInMonth > firstWeekEndDay ? 1 : 0);

            if ((int)firstDay.DayOfWeek != 1)
            {
                WeekNumInMonth--;//如果本月第一天不是一周开始则需要减去一周
            }
            return WeekNumInMonth;

        }

        /// <summary>
        /// 获取日期为年度第几周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }

        /// <summary>
        /// 将时间转换为星期几
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToWeek(DateTime dateTime) => dateTime.ToString("dddd", new System.Globalization.CultureInfo("zh-CN"));


        /// <summary>
        /// 将数字转换未星期几
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static string ToWeek(int? week)
        {
            string str = "";
            switch (week)
            {
                case 0:
                    str = "星期天";
                    break;
                case 1:
                    str = "星期一";
                    break;
                case 2:
                    str = "星期二";
                    break;
                case 3:
                    str = "星期三";
                    break;
                case 4:
                    str = "星期四";
                    break;
                case 5:
                    str = "星期五";
                    break;
                case 6:
                    str = "星期六";
                    break;
                default:
                    str = "未知";
                    break;
                    ;
            }
            return str;
        }

    }
}
