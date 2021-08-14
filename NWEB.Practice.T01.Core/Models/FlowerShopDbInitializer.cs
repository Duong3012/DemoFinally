using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Core.Models
{
    class FlowerShopDbInitializer : CreateDatabaseIfNotExists<FlowerShopDbContext>
    {
        protected override void Seed(FlowerShopDbContext context)
        {
            base.Seed(context);

            var listCategory = new List<Category>()
            {
                new Category(){CategoryName = "Hoa Hồng",Order = 1,Notes = "Có màu sắc rực rỡ"},

                new Category(){CategoryName = "Hoa Lan",Order = 2,
                    Notes = @"Hoa lan được người tiêu dùng ưa chuộng vì vẻ đẹp đặc sắc và các hình thức 
                            đa dạng của chúng. Cũng giống như cây lan, hoa lan hầu như có tất cả các màu trong 
                            cầu vồng và những kết hợp của các màu đó. Hoa lan nhỏ nhất chỉ bằng hạt gạo trong khi hoa lan
                            an lớn nhất có đường kính khoảng 1 m"},

                new Category(){CategoryName = "Hoa Đào",Order = 3,
                    Notes = "Nếu như mỗi dịp Tết đến xuân về miền Nam có hoa anh đào thì miền Bắc lại nổi bật với ánh sắc " +
                            "“liễu yếu đào tơ” của những cánh đào khoe sắc. "},

                new Category(){CategoryName = "Hoa Cúc",Order = 1,Notes = "Có màu sắc đẹp và thơm dịu"},
                new Category(){CategoryName = "Hoa Ly",Order = 3,
                    Notes = "Hoa Ly hay còn gọi là hoa loa kèn, hoa bách hợp được coi là một trong những " +
                            "loài hoa đẹp và được ưa chuộng nhất thế giới. Màu sắc của hoa vô cùng đa dạng như:" +
                            " màu vàng, màu trắng và màu đỏ"},

                new Category(){CategoryName = "Hoa Tulip",Order = 2,
                    Notes = "Tên gọi khác là khoa kim hương là một chi của loại hoa trong họ Liliaceae"},
            };
            context.Categories.AddRange(listCategory);
            context.SaveChanges();

            var listColor = new List<Color>()
            {
                new Color() {ColorName = "Red"},
                new Color() {ColorName = "Pink"},
                new Color() {ColorName = "Orange"},
                new Color() {ColorName = "Lavender"},
                new Color() {ColorName = "Blue"},
                new Color() {ColorName = "Purple"}

            };

            context.Colors.AddRange(listColor);
            context.SaveChanges();

            var listFlower = new List<Flower>()
            {
                new Flower(){
                    CategoryId = listCategory[1].Id,
                    Category = listCategory[1],
                    FlowerName = "Hòa đào nhật tân",
                    Description = "Hình ảnh cây hoa đào ngày Tết gắn liền với sắc đẹp của trăm hoa đua nở, của sắc xuân ngày tết",
                    ColorId = listColor[2].Id,
                    Color = listColor[2],
                    Image = "dao.jpg",
                    Price = 200000,
                    SalePrice = 190000,
                    StoreDate = DateTime.Now,
                    StoreInventory = 1},

                new Flower(){
                    CategoryId = listCategory[1].Id,
                    Category = listCategory[1],
                    FlowerName = "Hòa Lan Đột Biến",
                    Description = "Hình ảnh cây hoa lan gần đây rất được quan tâm với giá bán cao ngất ngưỡng làm thu hút quan tâm đến dư luận",
                    ColorId = listColor[1].Id,
                    Color = listColor[1],
                    Image = "dao.jpg",
                    Price = 1000000,SalePrice = 930000,
                    StoreDate = DateTime.Now,
                    StoreInventory = 2},

                new Flower(){
                    CategoryId = listCategory[2].Id,
                    Category = listCategory[2],
                    FlowerName = "Hoa Lan Đuôi Công",
                    Description = "Hình ảnh cây hoa lan nở sắc sỡ màu sắc làm cho không gian trở nên mát mẻ."
                    ,ColorId = listColor[3].Id,
                    Color= listColor[3],
                    Image = "dao.jpg",Price = 440000,
                    SalePrice = 400000,StoreDate = DateTime.Now,
                    StoreInventory = 3},

                new Flower(){
                    CategoryId = listCategory[1].Id,
                    Category = listCategory[1],
                    FlowerName = "Hoa Hồng Phai",
                    Description = "Đây là một loại hoa không thể thiếu trong các ngày lễ của viêt nam",
                    ColorId = listColor[5].Id,
                    Color= listColor[5],
                    Image = "dao.jpg",
                    Price = 23000,
                    SalePrice = 19000,
                    StoreDate = DateTime.Now,
                    StoreInventory = 3},

                new Flower(){
                    CategoryId = listCategory[3].Id,
                    Category = listCategory[3],
                    FlowerName = "Hòa đào phai",
                    Description = "Cứ đến dịp tết mọi người lại mua cho gia đình 1 cành đào ",
                    ColorId = listColor[4].Id,
                    Color = listColor[4],
                    Image = "dao.jpg",Price = 300000,
                    SalePrice = 290000,
                    StoreDate = DateTime.Now,
                    StoreInventory = 2},
            };

            context.Flowers.AddRange(listFlower);
            context.SaveChanges();

        }
    }
}
