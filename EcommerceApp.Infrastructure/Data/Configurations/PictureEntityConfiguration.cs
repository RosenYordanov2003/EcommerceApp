namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using static System.Net.WebRequestMethods;

    public class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasData(GeneratePictures());
        }

        private IEnumerable<Picture> GeneratePictures()
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
               }
           };
        }
    }
}
