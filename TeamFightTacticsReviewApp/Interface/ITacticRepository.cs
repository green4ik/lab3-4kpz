using TeamFightTacticsReviewApp.Models;
namespace TeamFightTacticsReviewApp.Interface {
    public interface ITacticRepository {
        ICollection<Tactic> GetTactics(); 
        Tactic GetTactic(int id);
        Tactic GetTactic(string name);
        bool TacticExists(int id);
        bool CreateTactic(Tactic tactic);
        bool UpdateTactic(Tactic tactic);
        bool DeleteTactic(Tactic tactic);

        bool Save();
    }
}
