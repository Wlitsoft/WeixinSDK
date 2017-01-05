/**********************************************************************************************************************
 * 描述：
 *      微信消息加密解密。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月04日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Wlitsoft.Framework.WeixinSDK.Message.Security.Crypto
{
    /// <summary>
    /// 微信消息加密解密。
    /// <para>微信官方提供。</para>
    /// </summary>
    public class WeixinMsgCrypto
    {

        #region 私有属性

        readonly string m_sToken;
        readonly string m_sEncodingAESKey;
        readonly string m_sAppID;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="WeixinMsgCrypto"/> 类的新实例。
        /// </summary>
        /// <param name="sToken">公众平台上，开发者设置的Token。</param>
        /// <param name="sEncodingAESKey">公众平台上，开发者设置的EncodingAESKey。</param>
        /// <param name="sAppID">公众帐号的appid。</param>
        public WeixinMsgCrypto(string sToken, string sEncodingAESKey, string sAppID)
        {
            m_sToken = sToken;
            m_sAppID = sAppID;
            m_sEncodingAESKey = sEncodingAESKey;
        }

        /// <summary>
        /// 根据配置文件的相关配置初始化 <see cref="WeixinMsgCrypto"/> 类的新实例。
        /// </summary>
        public WeixinMsgCrypto()
        {
            m_sToken = WeixinApp.DevConfig.Token;
            m_sAppID = WeixinApp.DevConfig.AppID;
            m_sEncodingAESKey = WeixinApp.DevConfig.EncodingAESKey;
        }

        #endregion

        #region 检验消息的真实性，并且获取解密后的明文

        /// <summary>
        /// 检验消息的真实性，并且获取解密后的明文。
        /// </summary>
        /// <param name="sMsgSignature">签名串，对应URL参数的msg_signature。</param>
        /// <param name="sTimeStamp">时间戳，对应URL参数的timestamp。</param>
        /// <param name="sNonce">随机串，对应URL参数的nonce。</param>
        /// <param name="sPostData">密文，对应POST请求的数据。</param>
        /// <param name="sMsg">解密后的原文，当return返回0时有效。</param>
        /// <returns>成功0，失败返回对应的错误码。</returns>
        public int DecryptMsg(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData, ref string sMsg)
        {
            if (m_sEncodingAESKey.Length != 43)
            {
                return (int)WeixinMsgCryptoErrorCode.IllegalAesKey;
            }
            XmlDocument doc = new XmlDocument();
            XmlNode root;
            string sEncryptMsg;
            try
            {
                doc.LoadXml(sPostData);
                root = doc.FirstChild;
                sEncryptMsg = root["Encrypt"].InnerText;
            }
            catch (Exception)
            {
                return (int)WeixinMsgCryptoErrorCode.ParseXml_Error;
            }
            //verify signature
            int ret = 0;
            ret = VerifySignature(m_sToken, sTimeStamp, sNonce, sEncryptMsg, sMsgSignature);
            if (ret != 0)
                return ret;
            //decrypt
            string cpid = "";
            try
            {
                sMsg = Cryptography.AES_decrypt(sEncryptMsg, m_sEncodingAESKey, ref cpid);
            }
            catch (FormatException)
            {
                return (int)WeixinMsgCryptoErrorCode.DecodeBase64_Error;
            }
            catch (Exception)
            {
                return (int)WeixinMsgCryptoErrorCode.DecryptAES_Error;
            }
            if (cpid != m_sAppID)
                return (int)WeixinMsgCryptoErrorCode.ValidateAppid_Error;
            return 0;
        }

        #endregion

        #region 将企业号回复用户的消息加密打包

        /// <summary>
        /// 将企业号回复用户的消息加密打包。
        /// </summary>
        /// <param name="sReplyMsg">企业号待回复用户的消息，xml格式的字符串。</param>
        /// <param name="sTimeStamp">时间戳，可以自己生成，也可以用URL参数的timestamp。</param>
        /// <param name="sNonce">随机串，可以自己生成，也可以用URL参数的nonce。</param>
        /// <param name="sEncryptMsg">加密后的可以直接回复用户的密文，包括msg_signature, timestamp, nonce, encrypt的xml格式的字符串,当return返回0时有效。</param>
        /// <returns>成功0，失败返回对应的错误码。</returns>
        public int EncryptMsg(string sReplyMsg, string sTimeStamp, string sNonce, ref string sEncryptMsg)
        {
            if (m_sEncodingAESKey.Length != 43)
            {
                return (int)WeixinMsgCryptoErrorCode.IllegalAesKey;
            }
            string raw = "";
            try
            {
                raw = Cryptography.AES_encrypt(sReplyMsg, m_sEncodingAESKey, m_sAppID);
            }
            catch (Exception)
            {
                return (int)WeixinMsgCryptoErrorCode.EncryptAES_Error;
            }
            string MsgSigature = "";
            int ret = 0;
            ret = GenarateSinature(m_sToken, sTimeStamp, sNonce, raw, ref MsgSigature);
            if (0 != ret)
                return ret;
            sEncryptMsg = "";

            string EncryptLabelHead = "<Encrypt><![CDATA[";
            string EncryptLabelTail = "]]></Encrypt>";
            string MsgSigLabelHead = "<MsgSignature><![CDATA[";
            string MsgSigLabelTail = "]]></MsgSignature>";
            string TimeStampLabelHead = "<TimeStamp><![CDATA[";
            string TimeStampLabelTail = "]]></TimeStamp>";
            string NonceLabelHead = "<Nonce><![CDATA[";
            string NonceLabelTail = "]]></Nonce>";
            sEncryptMsg = sEncryptMsg + "<xml>" + EncryptLabelHead + raw + EncryptLabelTail;
            sEncryptMsg = sEncryptMsg + MsgSigLabelHead + MsgSigature + MsgSigLabelTail;
            sEncryptMsg = sEncryptMsg + TimeStampLabelHead + sTimeStamp + TimeStampLabelTail;
            sEncryptMsg = sEncryptMsg + NonceLabelHead + sNonce + NonceLabelTail;
            sEncryptMsg += "</xml>";
            return 0;
        }

        #endregion

        #region 私有方法

        #region 校验签名

        /// <summary>
        /// 校验签名。
        /// </summary>
        private static int VerifySignature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, string sSigture)
        {
            string hash = "";
            int ret = 0;
            ret = GenarateSinature(sToken, sTimeStamp, sNonce, sMsgEncrypt, ref hash);
            if (ret != 0)
                return ret;
            //System.Console.WriteLine(hash);
            if (hash == sSigture)
                return 0;
            else
            {
                return (int)WeixinMsgCryptoErrorCode.ValidateSignature_Error;
            }
        }

        #endregion

        #region 生成签名

        /// <summary>
        /// 生成签名。
        /// </summary>
        private static int GenarateSinature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, ref string sMsgSignature)
        {
            ArrayList AL = new ArrayList();
            AL.Add(sToken);
            AL.Add(sTimeStamp);
            AL.Add(sNonce);
            AL.Add(sMsgEncrypt);
            AL.Sort(new DictionarySort());
            string raw = "";
            for (int i = 0; i < AL.Count; ++i)
            {
                raw += AL[i];
            }

            SHA1 sha;
            ASCIIEncoding enc;
            string hash = "";
            try
            {
                sha = new SHA1CryptoServiceProvider();
                enc = new ASCIIEncoding();
                byte[] dataToHash = enc.GetBytes(raw);
                byte[] dataHashed = sha.ComputeHash(dataToHash);
                hash = BitConverter.ToString(dataHashed).Replace("-", "");
                hash = hash.ToLower();
            }
            catch (Exception)
            {
                return (int)WeixinMsgCryptoErrorCode.ComputeSignature_Error;
            }
            sMsgSignature = hash;
            return 0;
        }

        #endregion

        #endregion

    }
}
