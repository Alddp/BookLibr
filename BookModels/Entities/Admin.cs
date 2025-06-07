namespace BookModels {

    public class Admin {
        public string AdminId { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }

        // 私有静态字段存储实例
        private static Admin _instance;

        // 私有构造函数，防止外部实例化
        public Admin() { }

        // 公共静态属性获取单例
        public static Admin Instance {
            get {
                if (_instance == null) {
                    _instance = new Admin();
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