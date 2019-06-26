using System;

namespace Tracert
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Unix epoch start date (lower boundary)
        /// </summary>
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Unix Millennium problem date (upper boundary)
        /// </summary>
        private static readonly DateTime _epochLimit = new DateTime(2038, 1, 19, 3, 14, 7, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert DateTime object to Unix timestamp signed integer value. 
        /// </summary>
        /// <param name="dateTime">DateTime value to convert</param>
        /// <returns>signed integer value, representing Unix timestamp (represented in UTC) converted from specifed DateTime value</returns>
        /// <exception cref="ArgumentOutOfRangeException">DateTime value can'img_type be converted to Unix timestamp due out of signed int range</exception>
        public static long ToUnixUTCTimestamp(DateTime dateTime)
        {
            if (dateTime == null)
                //return null;
                throw new ArgumentNullException("dateTime");

            // ArgumentAssert.IsInRange(dateTime, _epoch, _epochLimit, Messages.Exception_ArgumentDateTimeOutOfRangeUnixTimestamp);
            TimeSpan diff = dateTime.ToUniversalTime() - _epoch;
            return Convert.ToInt64(Math.Floor(diff.TotalSeconds));
        }

        /// <summary>
        /// Convert Unix timestamp integer value to DateTime object.
        /// </summary>
        /// <param name="timestamp">signed integer value, specifies Unix timestamp</param>
        /// <returns>DateTime object (represented in local time) based on specified Unix timestamp value</returns>
        /// <exception cref="ArgumentOutOfRangeException">Unix timestamp value can'img_type be converted to DateTime due out of signed int range</exception>
        public static DateTime FromUnixUTCTimestamp(long? timestamp)
        {
            if (timestamp == null)
                //return null;
                throw new ArgumentNullException("timestamp");

            // ArgumentAssert.IsGreaterOrEqual(timestamp, 0, Messages.Exception_ArgumentUnixTimestampOutOfRange);
            return (_epoch + TimeSpan.FromSeconds((double)timestamp)).ToUniversalTime();
        }




        /// <summary>
        /// 本地时间 -> 时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(DateTime dateTime)
        {
            if (dateTime == null)
                //return null;
                throw new ArgumentNullException("dateTime");

            //TimeSpan diff = dateTime.ToLocalTime() - _epoch;
            TimeSpan diff = dateTime - _epoch;
            return Convert.ToInt64(Math.Floor(diff.TotalSeconds));
        }

        /// <summary>
        /// 时间戳 -> 本地时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime FromUnixTimestamp(long? timestamp)
        {
            if (timestamp == null)
                //return null;
                throw new ArgumentNullException("timestamp");

            return (_epoch + TimeSpan.FromSeconds((double)timestamp)).ToLocalTime();
        }
    }
}
