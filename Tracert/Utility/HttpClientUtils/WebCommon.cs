using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tracert.HttpClientUtils
{
    public class WebCommon
    {
        public static string BuildHash(IDictionary parameters, bool needEncode = true)
        {
            string str_param = string.Empty;
            if (parameters != null && parameters.Count > 0)
            {
                var parameters_temp = new Dictionary<string, string>();
                foreach (DictionaryEntry item in parameters)
                    parameters_temp.Add(item.Key?.ToString(), item.Value?.ToString() ?? string.Empty);

                str_param = _BuildHash(parameters: parameters_temp, needEncode: needEncode);
            }
            return str_param;
        }

        private static string _BuildHash(IDictionary<string, string> parameters, bool needEncode)
        {
            StringBuilder builder = new StringBuilder();

            var enumerator = parameters.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string key = enumerator.Current.Key;
                string val = enumerator.Current.Value;

                // 忽略参数名或参数值为空的参数
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(val))
                    continue;

                if (needEncode)
                    builder.Append("&").Append(key).Append("=").Append(Uri.EscapeDataString(val));
                else
                    builder.Append("&").Append(key).Append("=").Append(val);
            }
            return builder.ToString().TrimStart('&');
        }

        public static string BuildXml(IDictionary parameters)
        {
            string str_param = null;
            if (parameters != null && parameters.Count > 0)
            {
                var parameters_temp = new Dictionary<string, string>();
                foreach (DictionaryEntry item in parameters)
                    parameters_temp.Add(item.Key?.ToString(), item.Value?.ToString() ?? string.Empty);

                str_param = _BuildXml(parameters: parameters_temp);
            }

            return str_param;
        }

        private static string _BuildXml(IDictionary<string, string> parameters)
        {
            var builder = new StringBuilder();
            var enumerator = parameters.GetEnumerator();

            builder.Append("<xml>");
            while (enumerator.MoveNext())
            {
                var key = enumerator.Current.Key;
                var val = enumerator.Current.Value;

                // 忽略参数名或参数值为空的参数
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(val))
                    continue;

                builder.Append("<").Append(key).Append(">");
                //builder.Append(Globals.UrlEscape(val));
                builder.Append(val);
                builder.Append("</").Append(key).Append(">");
            }
            builder.Append("</xml>");

            return builder.ToString();
        }
    }
}
