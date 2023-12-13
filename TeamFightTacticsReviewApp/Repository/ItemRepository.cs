using TeamFightTacticsReviewApp.Data;
using TeamFightTacticsReviewApp.Interface;
using TeamFightTacticsReviewApp.Models;

namespace TeamFightTacticsReviewApp.Repository {
    public class ItemRepository : IItemRepository {
        private readonly DataContext context;

        ItemRepository(DataContext context) {
            this.context = context;
        }

        public Item GetItem(int id) {
            return context.Items.Where(i => i.Id == id).FirstOrDefault();
        }

        public ICollection<Item> GetItems() {
            return context.Items.OrderBy(i => i.Id).ToList();
        }

        public bool ItemExists(int id) {
            return context.Items.Any(i => i.Id == id);
        }
    }
}
