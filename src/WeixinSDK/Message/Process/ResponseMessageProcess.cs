/**********************************************************************************************************************
 * 描述：
 *      发送响应消息处理。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月04日	 新建
 * 
 *********************************************************************************************************************/
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Message.Response;

namespace Wlitsoft.Framework.WeixinSDK.Message.Process
{
    /// <summary>
    /// 发送响应消息处理。
    /// </summary>
    public class ResponseMessageProcess
    {
        /// <summary>
        /// 将要响应的消息模型对象解析为响应给微信服务器的 XML 文本。
        /// </summary>
        /// <typeparam name="T">要解析的消息模型类型。</typeparam>
        /// <param name="responseMessageObj">要解析的消息模型对象。</param>
        /// <returns>要响应给微信服务器的 XML 文本。</returns>
        public static string Parse<T>(T responseMessageObj)
            where T : ResponseMessageBase
        {
            #region 参数校验

            if (responseMessageObj == null)
                throw new ObjectNullException(nameof(responseMessageObj));

            #endregion

            return responseMessageObj.ToXmlString();
        }
    }
}
