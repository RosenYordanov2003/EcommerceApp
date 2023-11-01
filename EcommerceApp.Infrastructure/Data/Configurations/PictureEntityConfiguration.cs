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
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b3546974-0d23-4657-a8a7-8d6abc9fc5e8/air-force-1-07-lv8-shoes-p2p25V.png"
               },
               new Picture()
               {
                   Id = 2,
                   ShoesId = 1,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/0bab9b0c-3598-4b1f-b3eb-acd64788a258/air-force-1-07-lv8-shoes-p2p25V.png"
               },
               new Picture()
               {
                   Id = 3,
                   ShoesId = 1,
                   ImgUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/67701610-e9ef-4dbf-9a3b-df35affa59cb/air-force-1-07-lv8-shoes-p2p25V.png"
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
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675.jpg"
               },
               new Picture()
               {
                   Id = 25,
                   ShoesId = 7,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_2.jpg"
               },
               new Picture()
               {
                   Id = 26,
                   ShoesId = 7,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_4.jpg"
               },
               new Picture()
               {
                   Id = 27,
                   ShoesId = 7,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_5.jpg"
               },
               new Picture()
               {
                   Id = 28,
                   ShoesId = 8,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673.jpg"
               },
               new Picture()
               {
                   Id = 29,
                   ShoesId = 8,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_2.jpg"
               },
               new Picture()
               {
                   Id = 30,
                   ShoesId = 8,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_4.jpg"
               },
               new Picture()
               {
                   Id = 31,
                   ShoesId = 8,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_5.jpg"
               },
               new Picture()
               {
                   Id = 32,
                   ShoesId = 9,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_1.jpg"
               },
               new Picture()
               {
                   Id = 33,
                   ShoesId = 9,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_2.jpg"
               },
               new Picture()
               {
                   Id = 34,
                   ShoesId = 9,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371.jpg"
               },
               new Picture()
               {
                   Id = 35,
                   ShoesId = 9,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_3.jpg"
               },
               new Picture()
               {
                   Id = 36,
                   ShoesId = 10,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521.jpg"
               },
               new Picture()
               {
                   Id = 37,
                   ShoesId = 10,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_2.jpg"
               },
               new Picture()
               {
                   Id = 38,
                   ShoesId = 10,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_3.jpg"
               },
               new Picture()
               {
                   Id = 39,
                   ShoesId = 10,
                   ImgUrl = "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_5.jpg"
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
               }
           };
        }
    }
}
