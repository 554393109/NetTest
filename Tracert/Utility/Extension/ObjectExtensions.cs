﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tracert.Extension
{
    public static class ObjectExtensions
    {
        #region 类型判断

        /// <summary>
        /// 是否为Url
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsURL(object obj)
        {
            bool isCorrect = false;
            string url = string.Empty;

            if (obj != null)
                url = obj.ToString();

            isCorrect = Regex.IsMatch(url, @"^((http|https)://)(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(/[a-zA-Z0-9\&%_\./-~-]*)?");
            return isCorrect;
        }

        /// <summary>
        /// 判断是否Int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsInt(object obj)
        {
            bool isCorrect = false;
            int val = 0;

            if (obj != null)
                isCorrect = int.TryParse(obj.ToString(), out val);

            return isCorrect;
        }

        /// <summary>
        /// 判断是否Null或string.Empty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(object obj)
        {
            bool isCorrect = false;

            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                isCorrect = true;

            return isCorrect;
        }

        #endregion 类型判断

        /// <summary>
        /// 为null时使用string.Empty
        /// obj?.ToString() ?? string.Empty;
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ValueOrEmpty(object obj)
        {
            //return (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
            //    ? string.Empty
            //    : obj.ToString();

            return obj?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// 为null或空时使用val
        /// (obj == null || string.IsNullOrWhiteSpace(obj.ToString())) ? val.ValueOrEmpty() : obj.ToString();
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ValueOrEmpty(object obj, string val)
        {
            return (obj == null || string.IsNullOrEmpty(obj.ToString()))
                ? val?.ToString() ?? string.Empty
                : obj.ToString();
        }
    }
}
