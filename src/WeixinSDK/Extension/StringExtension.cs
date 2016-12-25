/**********************************************************************************************************************
 * 描述：
 *      字符串静态扩展类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using System.Net.Http;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Net;
using Wlitsoft.Framework.WeixinSDK.Model;

namespace Wlitsoft.Framework.WeixinSDK.Extension
{
    /// <summary>
    /// 字符串静态扩展类。
    /// </summary>
    public static class StringExtension
    {

        #region 发送 http GET 请求获取响应的 JSON 对象

        /// <summary>
        /// 发送 http GET 请求获取响应的 JSON 对象。
        /// </summary>
        /// <typeparam name="T">JSON对象类型。</typeparam>
        /// <param name="url">要请求的 url 地址。</param>
        /// <returns>响应的 JSON 对象。</returns>
        public static T GetJson<T>(this string url)
            where T : ResultModelBase
        {
            #region 参数校验

            if (string.IsNullOrEmpty(url))
                throw new StringNullOrEmptyException(nameof(url));

            #endregion

            HttpReqeustClient client = new HttpReqeustClient();
            string responseResultString = client.HttpGetString(url);
            WeixinApp.Logger.Debug($"Url:{url} Method:GET Response:{responseResultString}");
            return HttpResponseResultStringProcess<T>(responseResultString);
        }

        #endregion

        #region 根据请求数据发送 http POST 请求获取相应的 JSON 对象

        /// <summary>
        /// 根据请求数据发送 http POST 请求获取相应的 JSON 对象。
        /// </summary>
        /// <typeparam name="T">JSON对象类型。</typeparam>
        /// <param name="url">要请求的 url 地址。</param>
        /// <param name="postData">要请求的数据。</param>
        /// <returns>响应的 JSON 对象。</returns>
        public static T PostJson<T>(this string url, object postData)
            where T : ResultModelBase
        {
            return PostJson<T>(url, postData.ToJsonString());
        }

        /// <summary>
        /// 根据请求数据发送 http POST 请求获取相应的 JSON 对象。
        /// </summary>
        /// <typeparam name="T">JSON对象类型。</typeparam>
        /// <param name="url">要请求的 url 地址。</param>
        /// <param name="postData">要请求的数据。</param>
        /// <returns>响应的 JSON 对象。</returns>
        public static T PostJson<T>(this string url, string postData)
            where T : ResultModelBase
        {
            #region 参数校验

            if (string.IsNullOrEmpty(url))
                throw new StringNullOrEmptyException(nameof(url));

            #endregion

            HttpReqeustClient client = new HttpReqeustClient();
            string responseResultString = client.HttpPost(url, new StringContent(postData));
            WeixinApp.Logger.Debug($"Url:{url} Method:POST Request:{postData} Response:{responseResultString}");
            return HttpResponseResultStringProcess<T>(responseResultString);
        }

        #endregion

        #region 私有方法

        #region Http 响应结果字符串处理

        /// <summary>
        /// Http 响应结果字符串处理。
        /// </summary>
        /// <typeparam name="T">要转换成的对象类型。</typeparam>
        /// <param name="responseResultString">响应结果字符串。</param>
        /// <returns>响应的结果对象。</returns>
        private static T HttpResponseResultStringProcess<T>(string responseResultString)
            where T : ResultModelBase
        {
            ResultModelBase result = responseResultString.ToJsonObject<T>();
            result.ResponseResultString = responseResultString;
            return (T)result;
        }

        #endregion

        #endregion

    }
}
