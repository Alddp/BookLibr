using System;

namespace BookModels {

    public class Reader {
        public string CardNum { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }

        public string StudentId { get; set; }
        public string Phone { get; set; }
        public string ClassName { get; set; }
        public string Photo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        // 私有静态字段存储实例
        private static Reader _instance;

        // 私有构造函数，防止外部实例化
        public Reader() { }

        // 公共静态属性获取单例
        public static Reader Instance {
            get {
                if (_instance == null) {
                    _instance = new Reader();
                }
                return _instance;
            }
            set {
                ResetInstance();
                _instance = value;
            }
        }

        // 用于清除单例实例，方便测试或重新赋值
        public static void ResetInstance() {
            _instance = null;
        }
    }
}