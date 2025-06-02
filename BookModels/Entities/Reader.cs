using System;

namespace BookModels {

    public class Reader {
        public string CardNum { get; set; }
        public string UserName { get; set; }
        public string StudentId { get; set; }
        public string Phone { get; set; }
        public string ClassName { get; set; }
        public string Photo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}