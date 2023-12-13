using TeamFightTacticsReviewApp.Models;

namespace TeamFightTacticsReviewApp.Interface {
    public interface IItemRepository {
        ICollection<Item> GetItems();
        Item GetItem(int id);
        bool ItemExists(int id);
    }
}
