/**********************************************************************************************************************
 * 描述：
 *      微信消息处理接口。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

namespace Wlitsoft.Framework.WeixinSDK.Core
{
    /// <summary>
    /// 微信消息处理接口。
    /// </summary>
    public interface IWeixinMessageProcess
    {
        #region 属性

        /// <summary>
        /// 设置 请求消息。
        /// </summary>
        IRequestMessage RequestMessage { set; }

        /// <summary>
        /// 获取 相应消息。
        /// </summary>
        IResponseMessage ResponseMessage { get; }

        /// <summary>
        /// 获取或设置 是否响应一个空字符串给微信服务器。
        /// <para>默认为 <c>false</c>，当消息处理逻辑不需要给发送方响应消息则将该属性设置为 <c>true</c>。</para>
        /// </summary>
        bool IsResponseEmptyString { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 执行处理。
        /// </summary>
        void Process();

        #endregion

    }
}
