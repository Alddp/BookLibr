using System;

namespace BookModels {

    public class Borrow {
        public string BorrowId { get; set; }
        public string UserId { get; set; }
        public string BookId { get; set; }
        public string BookName { get; set; }
        public string BorrowAdminId { get; set; }
        public string ReturnAdminId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}