using BookDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookBLL
{
    public class CardManager
    {
        static readonly int data_mem = 29; // 存储卡号区块

        //int icdev = 0;
        //string error;
        //if (!CardService.CheckCard(ref icdev, out error))
        //{
        //    MessageBox.Show(error);
        //}

        /// <summary>
        /// 检测卡片是否正确放置，并验证密码
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="errorMessage">返回的错误消息</param>
        /// <returns></returns>
        public static bool CheckCard(ref int icdev, out string errorMessage)
        {
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
            return CheckKey(icdev, out errorMessage);
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool CheckKey(int icdev, out string errorMessage)
        {
            errorMessage = null;

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

        /// <summary>
        /// 读卡成功提示音
        /// </summary>
        /// <param name="icdev"></param>
        /// <returns></returns>
        public static int ReadSuccessBeep(int icdev)
        {
            DCHelper.dc_beep(icdev, 50);
            Thread.Sleep(100);
            int res = DCHelper.dc_beep(icdev, 50);
            return res;
        }

        /// <summary>
        /// 写卡成功提示音
        /// </summary>
        /// <param name="icdev"></param>
        /// <returns></returns>
        public static int WriteSuccessBeep(int icdev)
        {
            DCHelper.dc_beep(icdev, 100);
            Thread.Sleep(50);
            int res = DCHelper.dc_beep(icdev, 100);
            return res;
        }

        /// <summary>
        /// 开卡写入卡号到区块中
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static int WriteCardNum(int icdev, string datas, out string errorMessage)
        {
            if (CheckCard(ref icdev, out errorMessage))
            {
                WriteSuccessBeep(icdev);
                return DCHelper.dc_write(icdev, data_mem, datas);
            }
            else
                return 0;
        }
    }
}
