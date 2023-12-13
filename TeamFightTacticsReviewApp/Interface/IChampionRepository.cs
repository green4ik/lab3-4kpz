using TeamFightTacticsReviewApp.Models;

namespace TeamFightTacticsReviewApp.Interface {
    public interface IChampionRepository {
        ICollection<Champion> GetChampions();
        Champion GetChampion(int id);
        bool ChampionExists(int id);
        bool CreateChampion(Champion tactic);
        bool UpdateChampion(Champion champion);
        bool DeleteChampion(Champion champion);
        bool Save();
    }
}
