using BookDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBLL
{
    public class CardManager
    {
        /// <summary>
        /// 检测卡片是否正确放置，并验证密码
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool CheckCard(ref int icdev, out string errorMessage)
        {
            errorMessage = null;
            icdev = DCHelper.dc_init(100, 115200); // 初始化读卡器，参数根据实际情况调整
            if (icdev <= 0)
            {
                errorMessage = "读卡器初始化失败！";
                return false;
            }

            long snr = 0;
            int dccard = DCHelper.dc_card(icdev, 0, ref snr); // 寻卡
            if (dccard != 0)
            {
                errorMessage = "请正确放置卡";
                return false;
            }

            // 验证密码
            byte[] defaultKey = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }; // 默认密钥
            int loadkey = DCHelper.dc_load_key(icdev, 0, 7, defaultKey); // 加载密钥
            if (loadkey != 0)
            {
                errorMessage = "加载密钥失败";
                return false;
            }

            int authkey = DCHelper.dc_authentication(icdev, 0, 7); // 验证
            if (authkey != 0)
            {
                errorMessage = "验证密钥失败";
                return false;
            }
            return true;
        }

        //int icdev = 0;
        //string error;
        //if (!CardService.CheckCard(ref icdev, out error))
        //{
        //    MessageBox.Show(error);
        //}
    }
}
