using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Net;
using Wlitsoft.Framework.Common.Security;
using Wlitsoft.Framework.WeixinSDK.Model;
using Wlitsoft.Framework.WeixinSDK.Model.PayModel;

namespace Wlitsoft.Framework.WeixinSDK.Extension
{
    public static class HttpReqeustClientEx
    {
        #region Api 调用

        /// <summary>
        /// Api 调用。
        /// </summary>
        /// <typeparam name="T">Api 返回的结果类型。</typeparam>
        /// <param name="url">Api 地址。</param>
        /// <param name="method">要使用的 Http 方法。</param>
        /// <param name="postData">如果是 Post 表示要提交的 Api 数据。</param>
        /// <returns>Api 返回的结果对象。</returns>
        public static T ApiInvokeResult<T>(string url, HttpMethod method, string postData = null)
            where T : ResultModelBase
        {
            #region 参数校验

            if (string.IsNullOrEmpty(url))
                throw new StringNullOrEmptyException(nameof(url));

            #endregion

            string responseResultString = string.Empty;

            HttpReqeustClient client = new HttpReqeustClient();
            if (method == HttpMethod.Get)
            {
                responseResultString = client.HttpGetString(url);
            }
            else if (method == HttpMethod.Post)
            {
                responseResultString = client.HttpPost(url, new StringContent(postData)); ;
            }
            WeixinApp.Logger.Debug($"ApiInvokeResult Url:{url} Method:{method} Request:{postData} Response:{responseResultString}");

            T result = responseResultString.ToJsonObject<T>();
            result.ResponseResultString = responseResultString;
            return result;
        }

        #endregion

        #region 支付 Api 调用

        /// <summary>
        /// 支付 Api 调用。
        /// </summary>
        /// <typeparam name="T">Api 返回的结果类型。</typeparam>
        /// <param name="url">Api 地址。</param>
        /// <param name="postData">要提交给 Api 的数据。</param>
        /// <param name="isUseCert">是否使用证书。</param>
        /// <returns>Api 调用返回的结果对象。</returns>
        public static T PayApiInvokeResult<T>(string url, Dictionary<string, string> postData, bool isUseCert = false)
            where T : PayResultModelBase
        {
            #region 参数校验

            if (string.IsNullOrEmpty(url))
                throw new StringNullOrEmptyException(nameof(url));

            if (postData == null)
                throw new ObjectNullException(nameof(postData));

            #endregion

            //获取参数签名。
            string sign = ParamsSignerEx.GetSign(postData);

            //组织提交数据。
            StringBuilder postDataSb = new StringBuilder();
            postDataSb.Append("<xml>");
            foreach (var sA in postData.OrderBy(x => x.Key))//参数名ASCII码从小到大排序（字典序）；
            {
                postDataSb.Append("<" + sA.Key + ">")
                   .Append(sA.Value)  //todo : 暂时不转义了。 
                   .Append("</" + sA.Key + ">");
            }
            postDataSb.Append("<sign>").Append(sign).Append("</sign>");
            postDataSb.Append("</xml>");

            HttpReqeustClient client = new HttpReqeustClient();

            if (isUseCert)
            {
                if (WeixinApp.PayApiCertificate == null)
                    throw new Exception("请先配置设置支付接口要使用的证书。");

                client.Certificate = WeixinApp.PayApiCertificate;
            }

            string result = client.HttpPost(url, new StringContent(postDataSb.ToString()));

            T resultXmlObj = result.ToXmlObject<T>();

            WeixinApp.Logger.Debug($"PayApiInvokeResult Url:{url} Method:Post Request:{postDataSb} Response:{result}");

            #region Debug 参数

            resultXmlObj.NativePostString = postDataSb.ToString();
            resultXmlObj.NativeResultString = result;

            #endregion

            return resultXmlObj;
        }

        #endregion
    }
}
