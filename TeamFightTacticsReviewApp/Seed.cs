using TeamFightTacticsReviewApp.Data;
using TeamFightTacticsReviewApp.Models;

namespace TeamFightTacticsReviewApp {
    public class Seed {
        private readonly DataContext dataContext;
        public Seed(DataContext dataContext) {
            this.dataContext = dataContext;
        }
        public void seedDataContext() {
            if(!dataContext.Tactics.Any()) {
                var tactics = new List<Tactic>() {
                    new Tactic() {
                      Name = "Illia",
                      Champions = new List<Champion>() {
                          new Champion() {
                              Cost = 4,
                              Name = "Kaisa",
                              Rarity = "Epic",
                              Items = new List<Item>() {
                                  new Item() {
                                      Name = "Guinsoos",
                                  },
                                  new Item() {
                                      Name = "Bow"
                                  }
                              }
                          },
                           new Champion() {
                              Cost = 5,
                              Name = "Belveth",
                              Rarity = "Legendary",
                              Items = new List<Item>() {
                                  new Item() {
                                      Name = "Vaarmog",
                                  },
                                  new Item() {
                                      Name = "Rod"
                                  }
                              }
                          },
                            new Champion() {
                              Cost = 1,
                              Name = "Malzahar",
                              Rarity = "Common",
                               Items = new List<Item>() {
                                  new Item() {
                                      Name = "Jakso",
                                  },
                                  new Item() {
                                      Name = "Belt"
                                  }
                              }
                          },
                      }
                    },
                     new Tactic() {
                      Name = "Dan",
                      Champions = new List<Champion>() {
                          new Champion() {
                              Cost = 2,
                              Name = "Naafiri",
                              Rarity = "Uncommon",
                              Items = new List<Item>() {
                                  new Item() {
                                      Name = "Rabadon's",
                                  },
                                  new Item() {
                                      Name = "Cloak"
                                  }
                              }
                          },
                           new Champion() {
                              Cost = 5,
                              Name = "Aatrox",
                              Rarity = "Legendary",
                               Items = new List<Item>() {
                                  new Item() {
                                      Name = "Guinsoos",
                                  },
                                  new Item() {
                                      Name = "Bow"
                                  }
                              }
                          },
                            new Champion() {
                              Cost = 4,
                              Name = "Jarvan",
                              Rarity = "Epic",
                               Items = new List<Item>() {
                                  new Item() {
                                      Name = "Guinsoos",
                                  },
                                  new Item() {
                                      Name = "Bow"
                                  }
                              }
                          },
                      }
                    },
                      new Tactic() {
                      Name = "Mike",
                      Champions = new List<Champion>() {
                          new Champion() {
                              Cost = 3,
                              Name = "Quinn",
                              Rarity = "Rare",
                               Items = new List<Item>() {
                                  new Item() {
                                      Name = "Guinsoos",
                                  },
                                  new Item() {
                                      Name = "Bow"
                                  }
                              }
                          },
                           new Champion() {
                              Cost = 4,
                              Name = "Fiora",
                              Rarity = "Epic",
                               Items = new List<Item>() {
                                  new Item() {
                                      Name = "Guinsoos",
                                  },
                                  new Item() {
                                      Name = "Bow"
                                  }
                              }
                          },
                            new Champion() {
                              Cost = 1,
                              Name = "Kayle",
                              Rarity = "Common",
                               Items = new List<Item>() {
                                  new Item() {
                                      Name = "Guinsoos",
                                  },
                                  new Item() {
                                      Name = "Bow"
                                  }
                              }
                          },
                      }
                    },

                };
                dataContext.Tactics.AddRange(tactics);
                dataContext.SaveChanges();
            }
        }
    }
}
