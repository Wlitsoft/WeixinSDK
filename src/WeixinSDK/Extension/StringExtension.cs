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
        #region 使用 Get 方式调用 Api 并获取结果

        /// <summary>
        /// 使用 Get 方式调用 Api 并获取结果。
        /// </summary>
        /// <typeparam name="T">JSON对象类型。</typeparam>
        /// <param name="url">要请求的 url 地址。</param>
        /// <returns>响应的 JSON 对象。</returns>
        public static T GetApiInvokeResult<T>(this string url)
            where T : ResultModelBase
        {
            #region 参数校验

            if (string.IsNullOrEmpty(url))
                throw new StringNullOrEmptyException(nameof(url));

            #endregion

            return HttpReqeustClientEx.ApiInvokeResult<T>(url, HttpMethod.Get);
        }

        #endregion

        #region 使用 Post 方式调用 Api 并获取结果

        /// <summary>
        /// 使用 Post 方式调用 Api 并获取结果。
        /// </summary>
        /// <typeparam name="T">JSON对象类型。</typeparam>
        /// <param name="url">要请求的 url 地址。</param>
        /// <param name="postData">要请求的数据。</param>
        /// <returns>响应的 JSON 对象。</returns>
        public static T PostApiInvokeResult<T>(this string url, object postData)
            where T : ResultModelBase
        {
            return PostApiInvokeResult<T>(url, postData.ToJsonString());
        }

        /// <summary>
        /// 使用 Post 方式调用 Api 并获取结果。
        /// </summary>
        /// <typeparam name="T">JSON对象类型。</typeparam>
        /// <param name="url">要请求的 url 地址。</param>
        /// <param name="postData">要请求的数据。</param>
        /// <returns>响应的 JSON 对象。</returns>
        public static T PostApiInvokeResult<T>(this string url, string postData)
            where T : ResultModelBase
        {
            #region 参数校验

            if (string.IsNullOrEmpty(url))
                throw new StringNullOrEmptyException(nameof(url));

            #endregion

            return HttpReqeustClientEx.ApiInvokeResult<T>(url, HttpMethod.Post, postData);
        }

        #endregion
    }
}
