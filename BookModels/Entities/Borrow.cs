using System;

namespace BookModels {

    public class Borrow {
        public int BorrowId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int BorrowAdminId { get; set; }
        public int? ReturnAdminId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}