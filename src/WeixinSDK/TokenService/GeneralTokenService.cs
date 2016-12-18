/**********************************************************************************************************************
 * 描述：
 *      基本的令牌服务。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Timers;

namespace Wlitsoft.Framework.WeixinSDK.TokenService
{
    /// <summary>
    /// 基本的令牌服务。
    /// </summary>
    public class GeneralTokenService : TokenServiceBase
    {
        #region 私有属性

        /// <summary>
        /// 令牌。
        /// </summary>
        private string _token;

        /// <summary>
        /// js api 票证。
        /// </summary>
        private string _jsTickect;

        /// <summary>
        /// 定时器。
        /// </summary>
        private Timer _timer;

        #endregion

        #region 公共属性

        /// <summary>
        /// 缓存时间。单位秒。
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 运行状态标识。
        /// </summary>
        public bool RunStatus { get; set; }

        /// <summary>
        /// 上次运行时间。
        /// </summary>
        public DateTime LastRunDate { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="GeneralTokenService"/> 类的新实例。
        /// </summary>
        public GeneralTokenService()
        {
            this.Interval = 6000; //微信缓存7200秒，这边6000秒刷新一次。
            this.RunStatus = false;
        }

        #endregion

        #region 运行

        /// <summary>
        /// 运行。
        /// </summary>
        public void Run()
        {
            if (this.RunStatus)
                throw new Exception("正在运行。。。");

            this.RunStatus = true;

            //刷新令牌。
            this.RefreshToken();
            this._timer = new Timer(this.Interval * 1000);
            this._timer.Elapsed += delegate
            {
                //到期自动刷新。。。
                this.RefreshToken();
                this.RefreshJsTickect();
            };
        }

        #endregion

        #region 关闭

        /// <summary>
        /// 关闭。
        /// </summary>
        public void Close()
        {
            if (!this.RunStatus)
                throw new Exception("没有运行。。。");

            this._timer.Stop();
            this._timer.Dispose();
            this._timer = null;
            this.RunStatus = false;
        }

        #endregion

        #region TokenServiceBase 成员

        #region 获取令牌

        /// <summary>
        /// 获取令牌。
        /// <para>刷新令牌后，JSTickect会自动刷新</para>
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>令牌。</returns>
        public override string GetToken(bool isForceRefresh = false)
        {
            if (isForceRefresh)
            {
                this.RefreshToken();
                this.RefreshJsTickect();
            }
            return this._token;
        }

        #endregion

        #region 获取Js接口票证

        /// <summary>
        /// 获取Js接口票证。
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>Js接口票证</returns>
        public override string GetJsTickect(bool isForceRefresh = false)
        {
            //如果令牌为空则，
            if (string.IsNullOrEmpty(this._token))
                this.RefreshToken();

            //如果Js接口票证为空则，
            if (string.IsNullOrEmpty(this._jsTickect) || isForceRefresh)
                this.RefreshJsTickect();

            return this._jsTickect;
        }

        #endregion

        #endregion

        #region 私有方法

        #region 刷新令牌

        /// <summary>
        /// 刷新令牌。
        /// </summary>
        private void RefreshToken()
        {
            if (!this.RunStatus)
                throw new Exception("请先调用 Run 方法。");

            this.LastRunDate = DateTime.Now;
            this._token = base.BaseApiGetAccessToken();
        }

        #endregion

        #region 刷新Js接口票证

        /// <summary>
        /// 刷新Js接口票证。
        /// </summary>
        private void RefreshJsTickect()
        {
            if (!this.RunStatus)
                throw new Exception("请先调用 Run 方法。");

            this.LastRunDate = DateTime.Now;
            this._jsTickect = base.JSApiGetTickect(this._token);
        }

        #endregion

        #endregion
    }
}
