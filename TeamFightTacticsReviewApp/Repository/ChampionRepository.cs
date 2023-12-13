using TeamFightTacticsReviewApp.Data;
using TeamFightTacticsReviewApp.Interface;
using TeamFightTacticsReviewApp.Models;

namespace TeamFightTacticsReviewApp.Repository {
    public class ChampionRepository : IChampionRepository {
        private readonly DataContext context;

        public ChampionRepository(DataContext context) {
            this.context = context;
        }
        public bool ChampionExists(int id) {
            return context.Champions.Any(c => c.Id == id);
        }

        public bool CreateChampion(Champion tactic) {
            context.Add(tactic);
            return Save();
        }

        public bool DeleteChampion(Champion champion) {
            context.Remove(champion);
            return Save();
        }

        public Champion GetChampion(int id) {
            return context.Champions.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Champion> GetChampions() {
            return context.Champions.OrderBy(c => c.Id).ToList();
        }

        public bool Save() {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateChampion(Champion champion) {
            context.Update(champion);
            return Save();
        }
    }
}
