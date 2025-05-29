using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace BookDAL
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
    }
}
