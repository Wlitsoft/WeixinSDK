/**********************************************************************************************************************
 * 描述：
 *      字典排序。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月04日	 新建
 * 
 *********************************************************************************************************************/
using System.Collections;

namespace Wlitsoft.Framework.WeixinSDK.Message.Security.Crypto
{
    /// <summary>
    /// 字典排序。
    /// <para>微信官方提供。</para>
    /// </summary>
    internal sealed class DictionarySort : IComparer
    {
        public int Compare(object oLeft, object oRight)
        {
            string sLeft = oLeft as string;
            string sRight = oRight as string;
            int iLeftLength = sLeft.Length;
            int iRightLength = sRight.Length;
            int index = 0;
            while (index < iLeftLength && index < iRightLength)
            {
                if (sLeft[index] < sRight[index])
                    return -1;
                else if (sLeft[index] > sRight[index])
                    return 1;
                else
                    index++;
            }
            return iLeftLength - iRightLength;

        }
    }
}
