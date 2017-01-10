/**********************************************************************************************************************
 * 描述：
 *      支付 Api。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月07日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.PayModel;

namespace Wlitsoft.Framework.WeixinSDK.Api
{
    /// <summary>
    /// 支付 Api。
    /// </summary>
    public static class PayApi
    {
        #region 统一下单

        /// <summary>
        /// 统一下单。
        /// <para>
        /// 除被扫支付场景以外，商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易回话标识后再按扫码、JSAPI、APP等不同场景生成交易串调起支付。 
        /// </para>
        /// <param name="device_info">(必填) 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"。</param>
        /// <param name="nonce_str">(必填) String(32) 随机字符串，不长于32位。</param>
        /// <param name="body">(必填) String(32) 商品描述 商品或支付单简要描</param>
        /// <param name="detail"> String(8192) 商品详情  商品名称明细列表</param>
        /// <param name="attach"> String(127) 附加数据，在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据</param>
        /// <param name="out_trade_no">(必填) String(32) 商家订单ID,32个字符内、可包含字母, 其他说明见第4.2节商户订单号:http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2 </param>
        /// <param name="fee_type">符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见第4.2节货币类型: http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2 </param>
        /// <param name="total_fee">(必填) Int 订单总金额，只能为整数，详见第4.2节支付金额:http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2 </param>
        /// <param name="spbill_create_ip">(必填) String(32)终端IP APP和网页支付提交用户端IP，Native支付填调用微信支付API的机器IP。</param>
        /// <param name="time_start">String(14) 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。</param>
        /// <param name="time_expire">String(14) 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。</param>
        /// <param name="goods_tag">String(32) 商品标记，代金券或立减优惠功能的参数，说明详见第10节代金券或立减优惠：http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=10_1 </param>
        /// <param name="notify_url">(必填) String(256)  接收微信支付异步通知回调地址 </param>
        /// <param name="trade_type">(必填) String(16) 交易类型，取值如下：JSAPI，NATIVE，APP，详细说明见第4.2节参数规定：http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2 </param>
        /// <param name="product_id">(trade_type=NATIVE，此参数必传)String(32) 商品ID，trade_type=NATIVE，此参数必传。此id为二维码中包含的商品ID，商户自行定义。 </param>
        /// <param name="openid">(trade_type=JSAPI，此参数必传)String(128)用户标识，trade_type=JSAPI，此参数必传，用户在商户appid下的唯一标识。下单前需要调用【网页授权获取用户信息】接口获取到用户的Openid。 </param>
        /// <returns>统一下单返回结果对象。</returns>
        /// </summary>
        public static UnifiedOrderResultModel UnifiedOrder(string device_info, string nonce_str, string body, string detail, string attach,
            string out_trade_no, string fee_type, int total_fee, string spbill_create_ip, string time_start,
            string time_expire, string goods_tag,
            string notify_url, string trade_type, string product_id, string openid)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                {"appid", WeixinApp.DevConfig.AppID},
                {"mch_id", WeixinApp.DevConfig.PayConfig.MchId},
                {"device_info", device_info},
                {"nonce_str", nonce_str},
                {"body", body},
                {"detail", detail},
                {"attach", attach},
                {"out_trade_no", out_trade_no},
                {"fee_type", fee_type},
                {"total_fee", total_fee.ToString()},
                {"spbill_create_ip", spbill_create_ip},
                {"time_start", time_start},
                {"time_expire", time_expire},
                {"goods_tag", goods_tag},
                {"notify_url", notify_url},
                {"trade_type", trade_type},
                {"product_id", product_id},
                {"openid", openid}
            };

            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            return HttpReqeustClientEx.PayApiInvokeResult<UnifiedOrderResultModel>(url, postData);
        }

        #endregion

        #region 查询订单

        /// <summary>
        /// 查询订单。
        /// <para>该接口提供所有微信支付订单的查询，商户可以通过该接口主动查询订单状态，完成下一步的业务逻辑。 </para>
        /// </summary>
        /// <param name="transaction_id">String(32) 微信订单号 微信的订单号，优先使用 </param>
        /// <param name="out_trade_no">(transaction_id为空时必填) String(32) 商户订单号 商户系统内部的订单号，当没提供transaction_id时需要传这个。 </param>
        /// <returns>查询订单返回结果对象。</returns>
        public static OrderQueryResultModel OrderQuery(string transaction_id, string out_trade_no)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                {"appid", WeixinApp.DevConfig.AppID},
                {"mch_id", WeixinApp.DevConfig.PayConfig.MchId},
                {"transaction_id", transaction_id},
                {"out_trade_no", out_trade_no},
                {"nonce_str", Common.Extension.StringExtension.NewNonceStr(32)}
            };

            var url = "https://api.mch.weixin.qq.com/pay/orderquery";
            return HttpReqeustClientEx.PayApiInvokeResult<OrderQueryResultModel>(url, postData);
        }

        #endregion

        #region 关闭订单

        /// <summary>
        /// 关闭订单。
        /// <para>以下情况需要调用关单接口：商户订单支付失败需要生成新单号重新发起支付，要对原订单号调用关单，避免重复支付；系统下单后，用户支付超时，系统退出不再受理，避免用户继续，请调用关单接口。</para>
        /// </summary>
        /// <param name="out_trade_no">(transaction_id为空时必填) String(32) 商户订单号 商户系统内部的订单号，当没提供transaction_id时需要传这个。 </param>
        /// <returns>关闭订单返回结果对象。</returns>
        public static CloseOrderResultModel CloseOrder(string transaction_id, string out_trade_no)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                {"appid", WeixinApp.DevConfig.AppID},
                {"mch_id", WeixinApp.DevConfig.PayConfig.MchId},
                {"transaction_id", transaction_id},
                {"out_trade_no", out_trade_no},
                {"nonce_str", Common.Extension.StringExtension.NewNonceStr(32)}
            };

            string url = "https://api.mch.weixin.qq.com/pay/closeorder";
            return HttpReqeustClientEx.PayApiInvokeResult<CloseOrderResultModel>(url, postData);
        }

        #endregion

        #region 申请退款

        /// <summary>
        /// 申请退款。
        /// <para>
        /// 当交易发生之后一段时间内，由于买家或者卖家的原因需要退款时，卖家可以通过退款接口将支付款退还给买家，微信支付将在收到退款请求并且验证成功之后，按照退款规则将支付款按原路退到买家帐号上。
        /// </para>
        /// </summary>
        /// <param name="device_info">(必填) 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"。</param>
        /// <param name="transaction_id">String(32) 微信订单号 微信的订单号，优先使用 </param>
        /// <param name="out_trade_no">(transaction_id为空时必填) String(32) 商户订单号 transaction_id、out_trade_no二选一，如果同时存在优先级：transaction_id> out_trade_no </param>
        /// <param name="out_refund_no">(必填) String(32) 商户退款单号 商户系统内部的退款单号，商户系统内部唯一，同一退款单号多次请求只退一笔 </param>
        /// <param name="total_fee">(必填) int 总金额 订单总金额，单位为分，只能为整数。 </param>
        /// <param name="refund_fee">(必填) int  退款金额 退款总金额，订单总金额，单位为分，只能为整数</param>
        /// <param name="refund_fee_type">String(8) 货币种类 符合ISO 4217标准的三位字母代码，默认人民币：CNY</param>
        /// <param name="op_user_id">(必填) String(32) 操作员 操作员帐号, 默认为商户号mch_id </param>
        /// <returns>申请退款返回结果模型。</returns>
        public static RefundResultModel Refund(string device_info, string transaction_id, string out_trade_no, string out_refund_no, int total_fee, int refund_fee, string refund_fee_type, string op_user_id)
        {
            var postData = new Dictionary<string, string>
            {
                {"appid", WeixinApp.DevConfig.AppID},
                {"mch_id", WeixinApp.DevConfig.PayConfig.MchId},
                {"device_info", device_info},
                {"nonce_str", Common.Extension.StringExtension.NewNonceStr(32)},
                {"transaction_id", transaction_id},
                {"out_trade_no", out_trade_no},
                {"out_refund_no", out_refund_no},
                {"total_fee", total_fee.ToString()},
                {"refund_fee", refund_fee.ToString()},
                {"refund_fee_type", refund_fee_type},
                {"op_user_id", op_user_id}
            };

            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            return HttpReqeustClientEx.PayApiInvokeResult<RefundResultModel>(url, postData, true);
        }

        #endregion

        #region 查询退款

        /// <summary>
        /// 查询退款。
        /// <para>提交退款申请后，通过调用该接口查询退款状态。退款有一定延时，用零钱支付的退款20分钟内到账，银行卡支付的退款3个工作日后重新查询退款状态。</para> 
        /// </summary>
        /// <param name="device_info">(必填) 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"。</param>
        /// <param name="transaction_id">String(32) 微信订单号 微信的订单号，优先使用 </param>
        /// <param name="out_trade_no">String(32) 商户订单号 transaction_id、out_trade_no二选一，如果同时存在优先级：transaction_id> out_trade_no </param>
        /// <param name="out_refund_no">String(32) 商户退款单号 商户系统内部的退款单号，商户系统内部唯一，同一退款单号多次请求只退一笔 </param>
        /// <param name="refund_id"> String(28) 微信退款单号  refund_id、out_refund_no、out_trade_no、transaction_id四个参数必填一个，如果同时存在优先级为： refund_id>out_refund_no>transaction_id>out_trade_no  </param>
        /// <returns>查询退款返回结果对象。</returns>
        public static RefundQueryResultModel RefundQuery(string device_info, string transaction_id, string out_trade_no, string out_refund_no, string refund_id)
        {
            var postData = new Dictionary<string, string>
            {
                {"appid", WeixinApp.DevConfig.AppID},
                {"mch_id", WeixinApp.DevConfig.PayConfig.MchId},
                {"device_info", device_info},
                {"nonce_str", Common.Extension.StringExtension.NewNonceStr(32)},
                {"transaction_id", transaction_id},
                {"out_trade_no", out_trade_no},
                {"out_refund_no", out_refund_no},
                {"refund_id", refund_id}
            };

            string url = "https://api.mch.weixin.qq.com/pay/refundquery";
            return HttpReqeustClientEx.PayApiInvokeResult<RefundQueryResultModel>(url, postData);
        }

        #endregion
    }
}
