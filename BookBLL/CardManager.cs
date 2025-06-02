using BookDAL;
using System.Threading;

namespace BookBLL {

    public class CardManager {
        private static readonly int data_mem = 29; // 存储卡号区块

        /// <summary>
        /// 检测卡片是否正确放置，并验证密码
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="errorMessage">返回的错误消息</param>
        /// <returns>ref int icdev</returns>
        // TODO: 重构
        private static bool CheckCard(ref int icdev, out string errorMessage) {
            icdev = DCHelper.dc_init(100, 115200); // 初始化读卡器，参数根据实际情况调整
            if (icdev <= 0) {
                errorMessage = "读卡器初始化失败！";
                return false;
            }

            long snr = 0;
            int dccard = DCHelper.dc_card(icdev, 0, ref snr); // 寻卡
            if (dccard != 0) {
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
        // TODO: 重构
        private static bool CheckKey(int icdev, out string errorMessage) {
            errorMessage = null;

            byte[] defaultKey = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }; // 默认密钥
            int loadkey = DCHelper.dc_load_key(icdev, 0, 7, defaultKey); // 加载密钥
            if (loadkey != 0) {
                errorMessage = "加载密钥失败";
                return false;
            }
            int authkey = DCHelper.dc_authentication(icdev, 0, 7); // 验证
            if (authkey != 0) {
                errorMessage = "验证密钥失败";
                return false;
            }
            return true;
        }

        private static int SuccessBeep(int icdev, int beepTime, int sleepTime) {
            DCHelper.dc_beep(icdev, beepTime);
            Thread.Sleep(sleepTime);
            return DCHelper.dc_beep(icdev, beepTime);
        }

        /// <summary>
        /// 读卡成功提示音
        /// </summary>
        /// <param name="icdev"></param>
        /// <returns></returns>
        // TODO: 重构
        public static int ReadSuccessBeep(int icdev) {
            return SuccessBeep(icdev, 50, 100);
        }

        /// <summary>
        /// 写卡成功提示音
        /// </summary>
        /// <param name="icdev"></param>
        /// <returns></returns>
        // TODO: 重构
        public static int WriteSuccessBeep(int icdev) {
            return SuccessBeep(icdev, 100, 50);
        }

        /// <summary>
        /// 开卡写入卡号到区块中
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name="errorMessage"></param>
        /// <returns>成功返回0</returns>
        // TODO: 重构
        public static int WriteCardNum(string cardNum, out string errorMessage) {
            int icdev = 0; // 初始化读卡器设备ID
            if (!CheckCard(ref icdev, out errorMessage))
                return -1;

            cardNum = cardNum.ToString().TrimEnd('\0'); // 去除末尾的空字符
            int res = DCHelper.dc_write(icdev, data_mem, cardNum);

            if (0 == res)
                WriteSuccessBeep(icdev);
            return res; // 成功写入
        }

        /// <summary>
        /// 读取区块存储的卡号
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name="errorMessage"></param>
        /// <returns>成功返回0</returns>
        // TODO: 重构
        public static bool ReadCardNum(out string cardNum, out string errorMessage) {
            cardNum = string.Empty; // 初始化cardNum
            int icdev = 0; // 初始化读卡器设备ID
            if (!CheckCard(ref icdev, out errorMessage))
                return false; // 卡片检查失败

            int res = DCHelper.dc_read(icdev, data_mem, cardNum);
            if (res == 0) {
                cardNum = cardNum.TrimEnd('\0'); // 去除末尾的空字符
                ReadSuccessBeep(icdev);
                return true; // 成功读取
            } else {
                errorMessage = "读取卡号失败";
                return false; // 读取失败
            }
        }
    }
}