/**********************************************************************************************************************
 * 描述：
 *      模板消息 Api。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.TemplateMessageApiModel;

namespace Wlitsoft.Framework.WeixinSDK.Api
{
    /// <summary>
    /// 模板消息 Api。
    /// </summary>
    public static class TemplateMessageApi
    {
        #region 发送模板消息

        /// <summary>
        /// 发送模板消息。
        /// </summary>
        /// <param name="openId">发送给用户的编号。</param>
        /// <param name="templateId">要使用的模板编号。</param>
        /// <param name="detailUrl">模板消息的详情链接地址。</param>
        /// <param name="topColor">模板消息头 html 颜色。</param>
        /// <param name="parameterDic">模板参数字典。</param>
        /// <returns>发送模板消息结果对象。</returns>
        public static SendTemplateMessageResultModel SendTemplateMessage(string openId, string templateId, string detailUrl, string topColor, TemplateMessageParameterDictionary parameterDic)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(openId))
                throw new StringNullOrEmptyException(nameof(openId));

            if (string.IsNullOrEmpty(templateId))
                throw new StringNullOrEmptyException(nameof(templateId));

            if (string.IsNullOrEmpty(detailUrl))
                throw new StringNullOrEmptyException(nameof(detailUrl));

            if (string.IsNullOrEmpty(topColor))
                throw new StringNullOrEmptyException(nameof(topColor));

            if (parameterDic == null)
                throw new ObjectNullException(nameof(parameterDic));

            #endregion

            string url = $"https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={WeixinApp.TokenService.GetToken()}";

            #region 组织数据

            var postdata = new
            {
                touser = openId,
                template_id = templateId,
                url = detailUrl,
                topcolor = topColor,
                data = parameterDic
            };

            #endregion

            return url.PostJson<SendTemplateMessageResultModel>(postdata);
        }

        #endregion
    }
}
