using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLiber
{
    public class DCHelper
    {
        [DllImport("dcrf32.dll")]
        public static extern int dc_init(int port, Int32 baud); //读写器初始化

        [DllImport("dcrf32.dll")]
        public static extern int dc_exit(int icdev);

        [DllImport("dcrf32.dll")]
        public static extern int dc_beep(int icdev, int _Msec);  //控制蜂鸣器

        [DllImport("dcrf32.dll")]
        public static extern short dc_card(int icdev, int Mode, ref long Snr);   //读写器寻卡

        [DllImport("dcrf32.dll")]
        public static extern int dc_load_key(int icdev, int Mode, int SecNr, byte[] NKey);  //将密码转载到读写设备中

        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication(int icdev, int Mode, int SecNr);   //验证密码

        [DllImport("dcrf32.dll")]
        public static extern int dc_write(int icdev, int Adr, string Data);  // 写卡操作

        [DllImport("dcrf32.dll")]
        public static extern int dc_read(int icdev, int Adr, string Data);  // 读卡操作

        public static bool CheckCard(ref int icdev)
        {
            // 首先检查是否已连接读卡器并找到卡
            icdev = DCHelper.dc_init(100, 115200); // 初始化读卡器，参数根据实际情况调整
            if (icdev <= 0)
            {
                MessageBox.Show("读卡器初始化失败！");
                return false;
            }

            long snr = 0;
            int dccard = DCHelper.dc_card(icdev, 0, ref snr); // 寻卡
            if (dccard != 0)
            {
                MessageBox.Show("请正确放置卡");
                return false;
            }

            // 验证密码
            byte[] defaultKey = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }; // 默认密钥
            int loadkey = DCHelper.dc_load_key(icdev, 0, 7, defaultKey); // 加载密钥
            if (loadkey != 0)
                return false;

            int authkey = DCHelper.dc_authentication(icdev, 0, 7); // 验证
            if (authkey != 0)
                return false;
            return true;
        }
    }
}
