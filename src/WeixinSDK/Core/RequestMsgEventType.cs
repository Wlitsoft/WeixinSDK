/**********************************************************************************************************************
 * 描述：
 *      事件类型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 *********************************************************************************************************************/

using System.ComponentModel;

namespace Wlitsoft.Framework.WeixinSDK.Core
{
    /// <summary>
    /// 事件类型。
    /// </summary>
    public enum RequestMsgEventType
    {
        /// <summary>
        /// 订阅。
        /// </summary>
        [Description("subscribe")]
        Subscribe,

        /// <summary>
        /// 取消订阅。
        /// </summary>
        [Description("unsubscribe")]
        UnSubscribe,

        /// <summary>
        /// 扫描带参数二维码。
        /// </summary>
        [Description("SCAN")]
        Scan,

        /// <summary>
        /// 上报地理位置。
        /// </summary>
        [Description("LOCATION")]
        Location,

        /// <summary>
        /// 点击菜单拉取消息。
        /// </summary>
        [Description("CLICK")]
        Click,

        /// <summary>
        /// 点击菜单跳转链接。
        /// </summary>
        [Description("VIEW")]
        View,

        /// <summary>
        /// 扫码推事件。
        /// </summary>
        [Description("scancode_push")]
        ScanCodePush,

        /// <summary>
        /// 扫码推事件且弹出“消息接收中”提示框。
        /// </summary>
        [Description("scancode_waitmsg")]
        ScanCodeWaitMsg,

        /// <summary>
        /// 弹出系统拍照发图。
        /// </summary>
        [Description("pic_sysphoto")]
        PicSysPhoto,

        /// <summary>
        /// 弹出拍照或者相册发图。
        /// </summary>
        [Description("pic_photo_or_album")]
        PicPhotoOrAlbum,

        /// <summary>
        /// 弹出微信相册发图器。
        /// </summary>
        [Description("pic_weixin")]
        PicWeixin,

        /// <summary>
        /// 弹出地理位置选择器。
        /// </summary>
        [Description("location_select")]
        LocationSelect,

        #region 服务器推送事件

        /// <summary>
        /// 群发完成推送。
        /// </summary>
        [Description("MASSSENDJOBFINISH")]
        MassSendJobFinish,

        /// <summary>
        /// 模板消息发送完成推送。
        /// </summary>
        [Description("TEMPLATESENDJOBFINISH")]
        TemplateSendJobFinish,

        /// <summary>
        /// 资质认证成功。
        /// </summary>
        [Description("qualification_verify_success")]
        QualificationVerifySuccess,

        /// <summary>
        /// 资质认证失败。
        /// </summary>
        [Description("qualification_verify_fail")]
        QualificationVerifyFail,

        /// <summary>
        /// 名称认证成功（即命名成功）。
        /// </summary>
        [Description("naming_verify_success")]
        NamingVerifySuccess,

        /// <summary>
        /// 名称认证失败。
        /// </summary>
        [Description("naming_verify_fail")]
        NamingVerifyFail,

        /// <summary>
        /// 年审通知。
        /// </summary>
        [Description("annual_renew")]
        AnnualRenew,

        /// <summary>
        /// 认证过期失效通知。
        /// </summary>
        [Description("verify_expired")]
        VerifyExpired,

        #endregion
    }
}
