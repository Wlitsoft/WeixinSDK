/**********************************************************************************************************************
 * 描述：
 *      消息处理配置信息构造者。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

using System;
using System.IO;
using System.Linq;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Config.Model;
using Wlitsoft.Framework.WeixinSDK.Configuration;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Config.Builder
{
    /// <summary>
    /// 消息处理配置信息构造者。
    /// </summary>
    public static class MessageProcessConfigurationBuilder
    {
        /// <summary>
        /// 根据 json 配置文件构造。
        /// </summary>
        /// <param name="configFilePath">配置文件路径.</param>
        /// <returns>一个 <see cref="DevConfiguration"/> 实例。</returns>
        public static MessageProcessConfiguration BuildByJsonFile(string configFilePath)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(configFilePath))
                throw new StringNullOrEmptyException(nameof(configFilePath));

            #endregion

            string fileText = File.ReadAllText(configFilePath);
            MessageProcessModel processModel = fileText.ToJsonObject<MessageProcessModel>();

            MessageProcessConfiguration config = new MessageProcessConfiguration();

            if (processModel.MessageList.Any())
            {
                foreach (MessageModel model in processModel.MessageList)
                {
                    #region 类型校验

                    if (!typeof(IWeixinMessageProcess).IsAssignableFrom(model.Type))
                        throw new Exception($"类型（{model.Type.FullName}）必须是（{typeof(IWeixinMessageProcess).FullName}）的派生类。");

                    #endregion

                    config.MessageList.Add(new MessageConfiguration(model.MsgType,
                        (IWeixinMessageProcess)Activator.CreateInstance(model.Type)));
                }
            }

            if (processModel.EventMessageList.Any())
            {
                foreach (EventMessageModel model in processModel.EventMessageList)
                {
                    #region 类型校验

                    if (!typeof(IWeixinMessageProcess).IsAssignableFrom(model.Type))
                        throw new Exception($"类型（{model.Type.FullName}）必须是（{typeof(IWeixinMessageProcess).FullName}）的派生类。");

                    #endregion

                    config.EventMessageList.Add(new EventMessageConfiguration(model.EventType,
                        (IWeixinMessageProcess)Activator.CreateInstance(model.Type))
                    { EventKey = model.EventKey });
                }
            }
            return config;
        }
    }
}
