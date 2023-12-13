namespace TeamFightTacticsReviewApp.Models {
    public class Tactic {
        public int Id { get; set; }
        public ICollection<Champion> Champions { get; set; } = new List<Champion>();
        public string Name { get; set; }
    }
}
