using TeamFightTacticsReviewApp.Data;
using TeamFightTacticsReviewApp.Interface;
using TeamFightTacticsReviewApp.Models;
namespace TeamFightTacticsReviewApp.Repository {
    public class TacticRepository : ITacticRepository {
        private readonly DataContext context;
        public TacticRepository(DataContext _context) {
            context = _context;
        }

        public bool CreateTactic(Tactic tactic) {
            context.Add(tactic);
            return Save();
        }

        public bool DeleteTactic(Tactic tactic) { 
            context.Remove(tactic);
            return Save();
        }

        public Tactic GetTactic(int id) {
            return context.Tactics.Where(p => p.Id == id).FirstOrDefault(); 
        }

        public Tactic GetTactic(string name) {
            return context.Tactics.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Tactic> GetTactics() {
            return context.Tactics.OrderBy(p => p.Id).ToList();
        }

        public bool Save() {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TacticExists(int id) {
            return context.Tactics.Any(p => p.Id ==id);
        }

        public bool UpdateTactic(Tactic tactic) {
            context.Update(tactic);
            return Save();
        }
    }
}
