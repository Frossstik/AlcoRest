using AlcoRest.Data.Models;

namespace AlcoRest.Data
{
    public class AlcoObjects
    {
        private static Dictionary<string, Category> _Category;
        private static Dictionary<string, Category> Categories
        {
            get
            {
                if (_Category == null)
                {
                    var clist = new Category[]
                    {
                        new Category
                        {
                        name = "Пиво",
                        description = "Слабоалкогольный хмельной напиток"
                        },
                        new Category {

                            name = "Коньяк",
                            description = "Крепкий алкогольный дистиллят винограда"

                        },
                        new Category {
                            name = "Водка",
                            description = "Крепкий алкогольный напиток, представляющий собой спирт с водой"
                        }
                    };
                    _Category = new Dictionary<string, Category>();
                    foreach (Category c in clist)
                        _Category.Add(c.name, c);
                }
                return _Category;

            }
        }
        public static void Initial(AlcoContext context)
        {

            if (!context.categories.Any())
            {
                context.categories.AddRange(Categories.Select(c => c.Value));
            }
            if (!context.products.Any())
            {
                context.AddRange(
                    new Product
                    {
                        name = "Балтика 7",
                        country = "Россия",
                        imageUrl = "Нету",
                        volume = 0.5M,
                        spirtVolume = 4.5M,
                        price = 50,
                        count = 100,
                        status = 0,
                        Category = Categories["Пиво"]
                    },
                    new Product
                    {
                        name = "Corona Extra",
                        country = "Мексика",
                        imageUrl = "Нету",
                        volume = 0.33M,
                        spirtVolume = 4.5M,
                        price = 110,
                        count = 0,
                        status = Models.Enums.CountDescription.OutOfStock,
                        Category = Categories["Пиво"]
                    },
                    new Product
                    {
                        name = "Арарат",
                        country = "Армения",
                        imageUrl = "Нету",
                        volume = 0.7M,
                        spirtVolume = 40,
                        price = 1000,
                        count = 15,
                        status = 0,
                        Category = Categories["Коньяк"]

                    },
                    new Product
                    {
                        name = "Absolut",
                        country = "Швеция",
                        imageUrl = "Нету",
                        volume = 0.5M,
                        spirtVolume = 40,
                        price = 800,
                        count = 3,
                        status = 0,
                        Category = Categories["Водка"]
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
