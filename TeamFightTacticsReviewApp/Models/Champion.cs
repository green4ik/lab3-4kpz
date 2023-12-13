namespace TeamFightTacticsReviewApp.Models {
    public class Champion {
        public int Id { get; set; }
        public string Name{ get; set; } 
        public int Cost{ get; set; }
        public string Rarity{ get; set; }
        public ICollection<Item> Items{ get; set; }
    }
}
