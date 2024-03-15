namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static System.Net.WebRequestMethods;

    public class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasData(GeneratePictures());
        }

        private static IEnumerable<Picture> GeneratePictures()
        {
           return new List<Picture>()
           {
               new Picture()
               {
                   Id = 1,
                   ShoesId = 1,
                   ImgUrl = "https://www.jdsports.cy/2680033-product_horizontal/nike-af1-jd-blk-blk-crim.jpg"
               },
               new Picture()
               {
                   Id = 2,
                   ShoesId = 1,
                   ImgUrl = "https://d2sw2hhlzkf9db.cloudfront.net/uploads/2022/11/Nike-Air-Force-1-07-LV8-DZ4514-001-5.jpg"
               },
               new Picture()
               {
                   Id = 3,
                   ShoesId = 1,
                   ImgUrl = "https://static.glami.ro/img/800x800bt/404805616-nike-air-force-1-lv8-gs-jdc-fb8036-001.jpg"
               },
               new Picture()
               {
                   Id = 4,
                   ShoesId = 1,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9fec2c65-bf79-49ae-b6fa-158e74827be2/air-force-1-07-lv8-shoes-p2p25V.png"
               },
               new Picture()
               {
                   Id = 5,
                   ShoesId = 2,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/c599987c-9750-459a-badf-35805b4571e7/mercurial-vapor-15-pro-football-boot-4R8klC.png"
               },
               new Picture()
               {
                   Id = 6,
                   ShoesId = 2,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/576f6b39-4803-42ec-84f8-b57d2da31093/mercurial-vapor-15-pro-football-boot-4R8klC.png"
               },
               new Picture()
               {
                   Id = 7,
                   ShoesId = 2,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/5e5eb7a2-59e5-44d7-bcde-e7389c729991/mercurial-vapor-15-pro-football-boot-4R8klC.png"
               },
               new Picture()
               {
                   Id = 8,
                   ShoesId = 2,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9d2426ad-828b-45f1-888e-7ea3af347b20/mercurial-vapor-15-pro-football-boot-4R8klC.png"
               },
               new Picture()
               {
                   Id = 9,
                   ShoesId = 3,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/ecba7aa5-adf6-4a1d-855e-58df68fb9170/mercurial-superfly-9-elite-football-boot-D6qDRk.png"
               },
               new Picture()
               {
                   Id = 10,
                   ShoesId = 3,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/1e8ec3dd-4463-4e20-a5b1-f25c15869887/mercurial-superfly-9-elite-football-boot-D6qDRk.png"
               },
               new Picture()
               {
                   Id = 11,
                   ShoesId = 3,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/285cb55e-8273-459c-a261-dfd4a2c29ac8/mercurial-superfly-9-elite-football-boot-D6qDRk.png"
               },
               new Picture()
               {
                   Id = 12,
                   ShoesId = 3,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/0eba4f6d-54d3-4411-9343-f6f8fcdcf048/mercurial-superfly-9-elite-football-boot-D6qDRk.png"
               },
               new Picture()
               {
                   Id = 13,
                   ShoesId = 4,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/44103b50-8fd8-4316-91c9-526a794ed12f/air-max-tw-shoes-bfGWNc.png"
               },
               new Picture()
               {
                   Id = 14,
                   ShoesId = 4,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/5638aa3c-36da-438f-a41c-7cbd9ec9dce1/air-max-tw-shoes-bfGWNc.png"
               },
               new Picture()
               {
                   Id = 15,
                   ShoesId = 4,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9265edc0-eb2e-40de-a224-1da42557b371/air-max-tw-shoes-bfGWNc.png"
               },
               new Picture()
               {
                   Id = 16,
                   ShoesId = 4,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/3a59615f-7032-4c60-8848-5267fcdba4b6/air-max-tw-shoes-bfGWNc.png",
               },
               new Picture()
               {
                   Id = 17,
                   ShoesId = 5,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/efc9de26-5f37-4a37-a49b-3bf8639076d0/air-max-scorpion-flyknit-shoes-jhBW7t.png"
               },
               new Picture()
               {
                   Id = 18,
                   ShoesId = 5,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/e6ef5f97-e01d-4e3c-b929-e7f95a566f44/air-max-scorpion-flyknit-shoes-jhBW7t.png"
               },
               new Picture()
               {
                   Id = 19,
                   ShoesId = 5,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/3c93e6be-3b5f-4336-af41-da346f127403/air-max-scorpion-flyknit-shoes-jhBW7t.png"
               },
               new Picture()
               {
                   Id = 20,
                   ShoesId = 5,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/d788cb32-f0e4-4426-acdf-f25b4ad3d574/air-max-scorpion-flyknit-shoes-jhBW7t.png"
               },
               new Picture()
               {
                   Id = 21,
                   ShoesId = 6,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/yommy4ijgwgrzbebxtvm/air-vapormax-plus-shoes-yATY9p7E.png"
               },
               new Picture()
               {
                   Id = 22,
                   ShoesId = 6,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/ehxtdksphjfm10zn2goz/air-vapormax-plus-shoes-yATY9p7E.png"
               },
               new Picture()
               {
                   Id = 23,
                   ShoesId = 6,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/bv4nc2mve7pvlkhzzh9s/air-vapormax-plus-shoes-yATY9p7E.png"
               },
               new Picture()
               {
                   Id = 24,
                   ShoesId = 7,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/e9091962695943f6a5ed67219538ad6d_9366/Ultraboost_1.0_Shoes_Grey_IF1912_04_standard.jpg"
               },
               new Picture()
               {
                   Id = 25,
                   ShoesId = 7,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b8c729aec8104a78a71a1b99013b100f_9366/Ultraboost_1.0_Shoes_Grey_IF1912_02_standard_hover.jpg"
               },
               new Picture()
               {
                   Id = 26,
                   ShoesId = 7,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/7f359276eda44bd1b5406251b2be5d55_9366/Ultraboost_1.0_Shoes_Grey_IF1912_03_standard.jpg"
               },
               new Picture()
               {
                   Id = 27,
                   ShoesId = 7,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b8c729aec8104a78a71a1b99013b100f_9366/Ultraboost_1.0_Shoes_Grey_IF1912_02_standard_hover.jpg"
               },
               new Picture()
               {
                   Id = 28,
                   ShoesId = 8,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b79a6a72567845b4b8a6a6cd35426ef9_9366/Pureboost_23_Running_Shoes_Green_IF1548_01_standard.jpg"
               },
               new Picture()
               {
                   Id = 29,
                   ShoesId = 8,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/9a8c1e54acab4922a97463898dfa5b6b_9366/Pureboost_23_Running_Shoes_Green_IF1548_02_standard_hover.jpg"
               },
               new Picture()
               {
                   Id = 30,
                   ShoesId = 8,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/2850801c47684ba7a0aee1c75ca864fd_9366/Pureboost_23_Running_Shoes_Green_IF1548_03_standard.jpg"
               },
               new Picture()
               {
                   Id = 31,
                   ShoesId = 8,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b0742a0521ca4a67856b4f1fff27e6b3_9366/Pureboost_23_Running_Shoes_Green_IF1548_04_standard.jpg"
               },
               new Picture()
               {
                   Id = 32,
                   ShoesId = 9,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/1856d88d74fe4d02b678ea56a7130b97_9366/Adizero_Impact_American_Football_Cleats_Black_ID1828_01_standard.jpg"
               },
               new Picture()
               {
                   Id = 33,
                   ShoesId = 9,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/419feb4c7ba3459f9eed646c26645387_9366/Adizero_Impact_American_Football_Cleats_Black_ID1828_02_standard_hover.jpg"
               },
               new Picture()
               {
                   Id = 34,
                   ShoesId = 9,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/e12b2c6d8c4b4ec68dc2dc0ea32804dc_9366/Adizero_Impact_American_Football_Cleats_Black_ID1828_03_standard.jpg"
               },
               new Picture()
               {
                   Id = 35,
                   ShoesId = 9,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/ef07175df84147b9becfe5dae432b104_9366/Adizero_Impact_American_Football_Cleats_Black_ID1828_04_standard.jpg"
               },
               new Picture()
               {
                   Id = 36,
                   ShoesId = 10,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/2872eabe08dd4141a718bf2326e19ca0_9366/Adizero_Electric_American_Football_Cleats_White_IE4374_01_standard.jpg"
               },
               new Picture()
               {
                   Id = 37,
                   ShoesId = 10,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/beddd0544dc94959b107e174d8a4294f_9366/Adizero_Electric_American_Football_Cleats_White_IE4374_02_standard_hover.jpg"
               },
               new Picture()
               {
                   Id = 38,
                   ShoesId = 10,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/09f4413fe2d54fe0b34434de76c25fdf_9366/Adizero_Electric_American_Football_Cleats_White_IE4374_03_standard.jpg"
               },
               new Picture()
               {
                   Id = 39,
                   ShoesId = 10,
                   ImgUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/6c0cac3d8958498694ae53c78ad021bc_9366/Adizero_Electric_American_Football_Cleats_White_IE4374_04_standard.jpg"
               },
               new Picture()
               {
                   Id = 40,
                   ShoesId = 11,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Predator%2019%203%20Laceless%20Firm%20G%201115.jpg"
               },
               new Picture()
               {
                   Id = 41,
                   ShoesId = 11,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Predator%2019%203%20Laceless%20Firm%20G%201115_2.jpg"
               },
               new Picture()
               {
                   Id = 42,
                   ShoesId = 11,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Predator%2019%203%20Laceless%20Firm%20G%201115_3.jpg"
               },
               new Picture()
               {
                   Id = 43,
                   ShoesId = 11,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Predator%2019%203%20Laceless%20Firm%20G%201115_4.jpg"
               },
               new Picture()
               {
                   Id = 44,
                   ShoesId = 12,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/392434/02/sv01/fnd/EEA/fmt/png/Slipstream-Xtreme-Sneakers"
               },
               new Picture()
               {
                   Id = 45,
                   ShoesId = 12,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/392434/02/bv/fnd/EEA/fmt/png/Slipstream-Xtreme-Sneakers"
               },
               new Picture()
               {
                   Id = 46,
                   ShoesId = 12,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/392434/02/sv02/fnd/EEA/fmt/png/Slipstream-Xtreme-Sneakers"
               },
               new Picture()
               {
                   Id = 47,
                   ShoesId = 12,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/392434/02/sv04/fnd/EEA/fmt/png/Slipstream-Xtreme-Sneakers"
               },
               new Picture()
               {
                   Id = 48,
                   ShoesId = 13,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/387544/02/sv01/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers"
               },
               new Picture()
               {
                   Id = 49,
                   ShoesId = 13,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/02/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers"
               },
               new Picture()
               {
                   Id = 50,
                   ShoesId = 13,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/02/bv/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers"
               },
               new Picture()
               {
                   Id = 51,
                   ShoesId = 13,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/02/sv02/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers"
               },
               new Picture()
               {
                   Id = 52,
                   ShoesId = 14,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/387544/16/sv01/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers"
               },
               new Picture()
               {
                   Id = 53,
                   ShoesId = 14,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/387544/16/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers"
               },
               new Picture()
               {
                   Id = 54,
                   ShoesId = 14,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/16/bv/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers"
               },
               new Picture()
               {
                   Id = 55,
                   ShoesId = 14,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/16/sv04/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers"
               },
               new Picture()
               {
                   Id = 56,
                   ShoesId = 15,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/107214/03/sv01/fnd/EEA/fmt/png/ULTRA-ULTIMATE-MG-Football-Cleats-Men"
               },
               new Picture()
               {
                   Id = 57,
                   ShoesId = 15,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107214/03/bv/fnd/EEA/fmt/png/ULTRA-ULTIMATE-MG-Football-Cleats-Men"
               },
               new Picture()
               {
                   Id = 58,
                   ShoesId = 15,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107214/03/sv02/fnd/EEA/fmt/png/ULTRA-ULTIMATE-MG-Football-Cleats-Men"
               },
               new Picture()
               {
                   Id = 59,
                   ShoesId = 15,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107214/03/sv04/fnd/EEA/fmt/png/ULTRA-ULTIMATE-MG-Football-Cleats-Men"
               },
               new Picture()
               {
                   Id = 60,
                   ShoesId = 16,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/107535/03/sv01/fnd/EEA/fmt/png/ULTRA-PLAY-IT-Youth-Football-Boots"
               },
               new Picture()
               {
                   Id = 61,
                   ShoesId = 16,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107535/03/sv02/fnd/EEA/fmt/png/ULTRA-PLAY-IT-Youth-Football-Boots"
               },
               new Picture()
               {
                   Id = 62,
                   ShoesId = 16,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107535/03/sv02/fnd/EEA/fmt/png/ULTRA-PLAY-IT-Youth-Football-Boots"
               },
               new Picture()
               {
                   Id = 63,
                   ShoesId = 16,
                   ImgUrl = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107535/03/sv04/fnd/EEA/fmt/png/ULTRA-PLAY-IT-Youth-Football-Boots"
               },
               new Picture()
               {
                   Id = 64,
                   ClothId = 1,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/7b10b532-1524-4bac-9252-44a6fb0e3848/chicago-bulls-essential-jordan-nba-long-sleeve-t-shirt-Hs7BDJ.png",
               },
               new Picture()
               {
                   Id = 65,
                   ClothId = 1,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/655bbd70-c83b-4908-97c8-3d6a9e979ec7/chicago-bulls-essential-jordan-nba-long-sleeve-t-shirt-Hs7BDJ.png",
               },
               new Picture()
               {
                   Id = 66,
                   ClothId = 2,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/ba184923-802b-4452-91f2-c05c1935c833/chicago-bulls-essential-jordan-nba-long-sleeve-t-shirt-Hs7BDJ.png"
               },
               new Picture()
               {
                   Id = 67,
                   ClothId = 2,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/2e897695-5f71-49d6-96d4-4760656263bc/chicago-bulls-essential-jordan-nba-long-sleeve-t-shirt-Hs7BDJ.png",
               },
               new Picture()
               {
                   Id = 68,
                   ClothId = 3,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/65f8431d-b201-4835-9bd7-69ad8016c2a5/air-marcus-rashford-t-shirt-PTxmGD.png"
               },
               new Picture()
               {
                   Id = 69,
                   ClothId = 3,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f8bf2b04-2031-4017-ac51-6f35f906f140/air-marcus-rashford-t-shirt-PTxmGD.png"
               },
               new Picture()
               {
                   Id = 70,
                   ClothId = 4,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/4daed06a-f4c2-4eb7-b767-9083b8a059cb/air-marcus-rashford-t-shirt-PTxmGD.png"
               },
               new Picture()
               {
                   Id = 71,
                   ClothId = 4,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/c2e5f80f-4e86-44f3-a857-5dc9e1316b5c/air-marcus-rashford-t-shirt-PTxmGD.png"
               },
               new Picture()
               {
                   Id = 72,
                   ClothId = 4,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/265524e6-d4df-4b3f-9c2b-35d7d2034a06/air-marcus-rashford-t-shirt-PTxmGD.png"
               },
               new Picture()
               {
                   Id = 73,
                   ClothId = 5,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9de4a14d-9592-44a9-b979-16d6bcfb828e/sportswear-long-sleeve-top-k7q2B0.png"
               },
               new Picture()
               {
                   Id = 74,
                   ClothId = 5,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f201e04c-c494-404d-a9db-ec16a090e768/sportswear-long-sleeve-top-k7q2B0.png"
               },
               new Picture()
               {
                   Id = 75,
                   ClothId = 6,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/30769c01-7e65-4701-acef-4a61c42a2e2a/sportswear-long-sleeve-top-k7q2B0.png"
               },
               new Picture()
               {
                   Id = 76,
                   ClothId = 6,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/3e3da66a-96e6-49a4-a890-ed63f91077f0/sportswear-long-sleeve-top-k7q2B0.png"
               },
               new Picture()
               {
                   Id = 77,
                   ClothId = 7,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/603eef38-6e20-4b67-8c2f-fefe553096ba/dri-fit-uv-one-luxe-standard-fit-short-sleeve-top-NCd1Fw.png"
               },
               new Picture()
               {
                   Id = 78,
                   ClothId = 7,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/868da3be-97e1-4404-9c7a-eb85dfe095ff/dri-fit-uv-one-luxe-standard-fit-short-sleeve-top-NCd1Fw.png"
               },
               new Picture()
               {
                   Id = 79,
                   ClothId = 8,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f218ca5c-6f9d-4743-9270-f16cf6442e63/sportswear-tech-fleece-joggers-h2Bmxs.png"
               },
               new Picture()
               {
                   Id = 80,
                   ClothId = 8,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/7ceb3c8a-1036-4c13-a9d6-6136b8789b4f/sportswear-tech-fleece-joggers-h2Bmxs.png"
               },
               new Picture()
               {
                   Id = 81,
                   ClothId = 8,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/2ce6d4a7-fe24-4e31-9c8d-0cb0f1f00c5b/sportswear-tech-fleece-joggers-h2Bmxs.png"
               },
               new Picture()
               {
                   Id = 82,
                   ClothId = 9,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/e2aef028-799e-4bbe-b9c0-e06057b540fa/sportswear-tech-fleece-joggers-h2Bmxs.png"
               },
               new Picture()
               {
                   Id = 83,
                   ClothId = 9,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/708e1399-9ae0-443a-90b5-c10403810446/sportswear-tech-fleece-joggers-h2Bmxs.png"
               },
               new Picture()
               {
                   Id = 84,
                   ClothId = 9,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/d19bd263-f3ea-4f20-99d8-2d8809c294c6/sportswear-tech-fleece-joggers-h2Bmxs.png"
               },
               new Picture()
               {
                   Id = 85,
                   ClothId = 10,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/ea0404ed-85c6-481b-94e8-0713a2518b00/sportswear-club-fleece-joggers-27ggJk.png"
               },
               new Picture()
               {
                   Id = 86,
                   ClothId = 10,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/fa419b99-681e-4ad8-91e5-85469861395e/sportswear-club-fleece-joggers-27ggJk.png"
               },
               new Picture()
               {
                   Id = 87,
                   ClothId = 10,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/174d46bc-92aa-48cd-87e7-9d0febd35a4b/sportswear-club-fleece-joggers-27ggJk.png"
               },
               new Picture()
               {
                   Id = 88,
                   ClothId = 11,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/76543fe7-5c56-4816-ae5d-4437a38d239c/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png"
               },
               new Picture()
               {
                   Id = 89,
                   ClothId = 11,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/64997362-76c3-44ed-82f3-2344071575b3/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png"
               },
               new Picture()
               {
                   Id = 90,
                   ClothId = 11,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/582991d4-6e81-4478-ae40-a8bd80f70780/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png"
               },
               new Picture()
               {
                   Id = 91,
                   ClothId = 12,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/946f5abf-f660-4ac7-8c2c-62359a628b18/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png"
               },
               new Picture()
               {
                   Id = 92,
                   ClothId = 12,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/7bf8c2bc-d083-4c3b-aae1-1e0b04c0b42e/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png"
               },
               new Picture()
               {
                   Id = 93,
                   ClothId = 12,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/2e4586cd-2027-4ae9-9dec-af8c2a9a58bd/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png"
               }
           };
        }
    }
}
