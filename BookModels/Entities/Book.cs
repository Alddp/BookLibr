namespace BookModels {

    public class Book {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Price { get; set; }
        public string Inventory { get; set; }
        public string Picture { get; set; }
        public int SlotId { get; set; }
        public string PopulerPercent { get; set; }
    }
}