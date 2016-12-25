/**********************************************************************************************************************
 * 描述：
 *      微信消息处理基类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
namespace Wlitsoft.Framework.WeixinSDK.Core
{
    /// <summary>
    /// 微信消息处理基类。
    /// </summary>
    public abstract class WeixinMessageProcessBase
    {
        #region 公共属性

        /// <summary>
        /// 获取或设置 请求消息。
        /// </summary>
        public IRequestMessage RequestMessage { protected get; set; }

        /// <summary>
        /// 获取或设置 响应消息。
        /// </summary>
        public IResponseMessage ResponseMessage { get; protected set; }

        /// <summary>
        /// 获取或设置 是否响应一个空字符串给微信服务器。
        /// <para>默认为 <c>false</c>，当消息处理逻辑不需要给发送方响应消息则将该属性设置为 <c>true</c>。</para>
        /// </summary>
        public bool IsResponseEmptyString { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="WeixinMessageProcessBase"/> 的新实例。
        /// </summary>
        protected WeixinMessageProcessBase()
        {

        }

        #endregion

        #region 抽象方法

        /// <summary>
        /// 执行处理。
        /// </summary>
        public abstract void Process();

        #endregion

        #region 保护方法

        /// <summary>
        /// 根据请求消息类型获取对应类型的请求消息。
        /// </summary>
        /// <typeparam name="TRequestMessage">请求消息类型。</typeparam>
        /// <returns>请求消息对象。</returns>
        protected TRequestMessage GetRequestMessage<TRequestMessage>()
        {
            return (TRequestMessage)this.RequestMessage;
        }

        #endregion
    }
}
