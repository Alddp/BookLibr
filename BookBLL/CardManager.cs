using BookBLL.Utils;
using BookHardWare;
using BookModels.Errors;
using System.Threading;

namespace BookBLL {

    public class CardManager {
        private static readonly int data_mem = 29; // 存储卡号区块

        /// <summary>
        /// 检测卡片是否正确放置，并验证密码
        /// </summary>
        /// <returns>TData 为icdev</returns>
        private static OperationResult<int> CheckIcdev() {
            int icdev = DCHelper.dc_init(100, 115200); // 初始化读卡器，参数根据实际情况调整

            if (icdev <= 0)
                return OperationResult<int>.Fail(ErrorCode.UnknownError, "读卡器初始化失败!");

            long snr = 0;
            if (0 == DCHelper.dc_card(icdev, 0, ref snr)) // 寻卡 != 0) {
                return OperationResult<int>.Fail(ErrorCode.UnknownError, "请正确放置卡");

            // 验证密码
            return CheckKey(icdev);
        }

        // 验证密码
        private static OperationResult<int> CheckKey(int icdev) {
            var res = ResultWrapper.Wrap(() => {
                byte[] defaultKey = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }; // 默认密钥
                int loadkey = DCHelper.dc_load_key(icdev, 0, 7, defaultKey); // 加载密钥
                if (loadkey != 0) {
                    return OperationResult<int>.Fail(ErrorCode.UnknownError, "加载密钥失败");
                }
                int authkey = DCHelper.dc_authentication(icdev, 0, 7); // 验证
                if (authkey != 0) {
                    return OperationResult<int>.Fail(ErrorCode.UnknownError, "验证密钥失败");
                }
                return OperationResult<int>.Ok(icdev);
            });
            return res.Data;
        }

        private static OperationResult<int> SuccessBeep(int icdev, int beepTime, int sleepTime) {
            var res = ResultWrapper.Wrap(() => {
                DCHelper.dc_beep(icdev, beepTime);
                Thread.Sleep(sleepTime);
                DCHelper.dc_beep(icdev, beepTime);
                return 0;
            });

            if (res.Success && res.Data == 1) {
                return res;
            }
            return OperationResult<int>.Fail(ErrorCode.UnknownError);
        }

        // 读卡成功提示音
        public static OperationResult<int> ReadSuccessBeep(int icdev) {
            return SuccessBeep(icdev, 50, 100);
        }

        // 写卡成功提示音
        public static OperationResult<int> WriteSuccessBeep(int icdev) {
            return SuccessBeep(icdev, 100, 50);
        }

        // 开卡写入卡号到区块中,成功返回0
        public static OperationResult<int> WriteCardNum(string cardNum) {
            var IcdevRes = CheckIcdev();// 初始化读卡器设备ID
            if (!IcdevRes.Success)
                return OperationResult<int>.Fail();
            int icdev = IcdevRes.Data;
            cardNum = cardNum.ToString().TrimEnd('\0'); // 去除末尾的空字符

            if (0 == DCHelper.dc_write(icdev, data_mem, cardNum)) {
                WriteSuccessBeep(icdev);
                return OperationResult<int>.Ok(); // 成功写入
            }
            return OperationResult<int>.Fail(ErrorCode.UnknownError);
        }

        // 读取区块存储的卡号, 成功返回0
        //TODO:
        public static OperationResult<string> ReadCardNum() {
            string cardNum = string.Empty; // 初始化cardNum
            int icdev = 0; // 初始化读卡器设备ID
            var checkCard = CheckIcdev();
            if (!checkCard.Success)
                return OperationResult<string>.Fail(ErrorCode.UnknownError, "卡片检查失败"); // 卡片检查失败

            int res = DCHelper.dc_read(icdev, data_mem, cardNum);
            if (res == 0) {
                cardNum = cardNum.TrimEnd('\0'); // 去除末尾的空字符
                ReadSuccessBeep(icdev);
                return OperationResult<string>.Ok(cardNum);
            } else {
                return OperationResult<string>.Fail(ErrorCode.UnknownError, "读取卡号失败");
            }
        }
    }
}