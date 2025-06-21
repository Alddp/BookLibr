namespace BookModels {

    public class BookShelfSlot {
        public int SlotId { get; set; }
        public int Floor { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string Face { get; set; }
        public int Level { get; set; }
        public string SlotCode { get; set; }
        public string Location { get; set; }
    }
}