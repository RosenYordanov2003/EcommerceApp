using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class seedClothesData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Clothes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "BrandId", "CategoryId", "Color", "Description", "Gender", "IsFeatured", "Name", "Price", "StarRating", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Gray", "Men's Jordan NBA Long-Sleeve T-Shirt", "M", false, "Chicago Bulls Essential", 40m, 4, 6 },
                    { 2, 1, 1, "Black", "Men's Jordan NBA Long-Sleeve T-Shirt", "M", false, "Chicago Bulls Essential", 40m, 4, 6 },
                    { 3, 1, 1, "Black", "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches.", "M", false, "Nike Air x Marcus Rashford", 38m, 5, 7 },
                    { 4, 1, 1, "White", "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches.", "M", false, "Nike Air x Marcus Rashford", 38m, 5, 7 },
                    { 5, 1, 1, "White", "Extra-soft, stretchy ribbed fabric helps make this slim-fitting top an everyday favourite. A mock neck and long sleeves offer a tailored look while the embroidered Swoosh logo and piping details add a touch of heritage style.", "W", false, "Women's Long-Sleeve Top", 55m, 5, 6 },
                    { 6, 1, 1, "Black", "Extra-soft, stretchy ribbed fabric helps make this slim-fitting top an everyday favourite. A mock neck and long sleeves offer a tailored look while the embroidered Swoosh logo and piping details add a touch of heritage style.", "W", true, "Women's Long-Sleeve Top", 55m, 5, 6 },
                    { 7, 1, 1, "Wine Red", "The Nike Dri-FIT One Luxe Top is designed for all the ways you work out—from yoga to HIIT to long runs. As part of the Nike Luxe line, this top defines luxury with buttery-soft and smooth fabric that breathes to keep you dry and cool. It's made from at least 75% recycled polyester fibres.", "W", false, "Nike Dri-FIT UV One Luxe", 40m, 0, 7 },
                    { 8, 1, 5, "Midnight Black", "Ready for cooler weather, the Nike Sportswear Tech Fleece Joggers feature an updated fit perfect for everyday wear. Roomy through the thigh, this tapered design narrows at the knee to give you a comfortable feel without losing the clean, tailored look you love. Tall ribbed cuffs complete the jogger look while a zipped pocket on the right leg provides secure small-item storage and elevates the look.", "M", true, "Nike Sportswear Tech Fleece", 99m, 5, 5 },
                    { 9, 1, 5, "Red", "Ready for cooler weather, the Nike Sportswear Tech Fleece Joggers feature an updated fit perfect for everyday wear. Roomy through the thigh, this tapered design narrows at the knee to give you a comfortable feel without losing the clean, tailored look you love. Tall ribbed cuffs complete the jogger look while a zipped pocket on the right leg provides secure small-item storage and elevates the look.", "M", false, "Nike Sportswear Tech Fleece", 99m, 5, 5 },
                    { 10, 1, 5, "Slate White", "A wardrobe staple, the Nike Sportswear Club Fleece Joggers combine a classic look with the soft comfort of fleece for an elevated, everyday look that you can wear every day.", "M", false, "Nike Sportswear Club Fleece", 60m, 4, 5 },
                    { 11, 1, 5, "Pink", "Rise up and transform your fleece wardrobe with strong cosy vibes. These oversized Phoenix Fleece joggers have extra room in the legs for a fit that's comfy and relaxed. The taller ribbed waistline sits higher on your hips for a stay-put, snug feel and a bold look.", "W", false, "Nike Sportswear Phoenix Fleece", 65m, 4, 5 },
                    { 12, 1, 5, "Green", "Rise up and transform your fleece wardrobe with strong cosy vibes. These oversized Phoenix Fleece joggers have extra room in the legs for a fit that's comfy and relaxed. The taller ribbed waistline sits higher on your hips for a stay-put, snug feel and a bold look.", "W", true, "Nike Sportswear Phoenix Fleece", 65m, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "Id", "ClothId", "ImgUrl", "ShoesId" },
                values: new object[,]
                {
                    { 64, 1, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/7b10b532-1524-4bac-9252-44a6fb0e3848/chicago-bulls-essential-jordan-nba-long-sleeve-t-shirt-Hs7BDJ.png", null },
                    { 65, 1, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/655bbd70-c83b-4908-97c8-3d6a9e979ec7/chicago-bulls-essential-jordan-nba-long-sleeve-t-shirt-Hs7BDJ.png", null },
                    { 66, 2, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/ba184923-802b-4452-91f2-c05c1935c833/chicago-bulls-essential-jordan-nba-long-sleeve-t-shirt-Hs7BDJ.png", null },
                    { 67, 2, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/2e897695-5f71-49d6-96d4-4760656263bc/chicago-bulls-essential-jordan-nba-long-sleeve-t-shirt-Hs7BDJ.png", null },
                    { 68, 3, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/65f8431d-b201-4835-9bd7-69ad8016c2a5/air-marcus-rashford-t-shirt-PTxmGD.png", null },
                    { 69, 3, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f8bf2b04-2031-4017-ac51-6f35f906f140/air-marcus-rashford-t-shirt-PTxmGD.png", null },
                    { 70, 4, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/4daed06a-f4c2-4eb7-b767-9083b8a059cb/air-marcus-rashford-t-shirt-PTxmGD.png", null },
                    { 71, 4, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/c2e5f80f-4e86-44f3-a857-5dc9e1316b5c/air-marcus-rashford-t-shirt-PTxmGD.png", null },
                    { 72, 4, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/265524e6-d4df-4b3f-9c2b-35d7d2034a06/air-marcus-rashford-t-shirt-PTxmGD.png", null },
                    { 73, 5, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9de4a14d-9592-44a9-b979-16d6bcfb828e/sportswear-long-sleeve-top-k7q2B0.png", null },
                    { 74, 5, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f201e04c-c494-404d-a9db-ec16a090e768/sportswear-long-sleeve-top-k7q2B0.png", null },
                    { 75, 6, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/30769c01-7e65-4701-acef-4a61c42a2e2a/sportswear-long-sleeve-top-k7q2B0.png", null },
                    { 76, 6, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/3e3da66a-96e6-49a4-a890-ed63f91077f0/sportswear-long-sleeve-top-k7q2B0.png", null },
                    { 77, 7, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/603eef38-6e20-4b67-8c2f-fefe553096ba/dri-fit-uv-one-luxe-standard-fit-short-sleeve-top-NCd1Fw.png", null },
                    { 78, 7, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/868da3be-97e1-4404-9c7a-eb85dfe095ff/dri-fit-uv-one-luxe-standard-fit-short-sleeve-top-NCd1Fw.png", null },
                    { 79, 8, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f218ca5c-6f9d-4743-9270-f16cf6442e63/sportswear-tech-fleece-joggers-h2Bmxs.png", null },
                    { 80, 8, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/7ceb3c8a-1036-4c13-a9d6-6136b8789b4f/sportswear-tech-fleece-joggers-h2Bmxs.png", null },
                    { 81, 8, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/2ce6d4a7-fe24-4e31-9c8d-0cb0f1f00c5b/sportswear-tech-fleece-joggers-h2Bmxs.png", null },
                    { 82, 9, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/e2aef028-799e-4bbe-b9c0-e06057b540fa/sportswear-tech-fleece-joggers-h2Bmxs.png", null },
                    { 83, 9, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/708e1399-9ae0-443a-90b5-c10403810446/sportswear-tech-fleece-joggers-h2Bmxs.png", null },
                    { 84, 9, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/d19bd263-f3ea-4f20-99d8-2d8809c294c6/sportswear-tech-fleece-joggers-h2Bmxs.png", null },
                    { 85, 10, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/ea0404ed-85c6-481b-94e8-0713a2518b00/sportswear-club-fleece-joggers-27ggJk.png", null },
                    { 86, 10, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/fa419b99-681e-4ad8-91e5-85469861395e/sportswear-club-fleece-joggers-27ggJk.png", null },
                    { 87, 10, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/174d46bc-92aa-48cd-87e7-9d0febd35a4b/sportswear-club-fleece-joggers-27ggJk.png", null },
                    { 88, 11, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/76543fe7-5c56-4816-ae5d-4437a38d239c/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png", null },
                    { 89, 11, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/64997362-76c3-44ed-82f3-2344071575b3/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png", null },
                    { 90, 11, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/582991d4-6e81-4478-ae40-a8bd80f70780/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png", null },
                    { 91, 12, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/946f5abf-f660-4ac7-8c2c-62359a628b18/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png", null },
                    { 92, 12, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/7bf8c2bc-d083-4c3b-aae1-1e0b04c0b42e/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png", null },
                    { 93, 12, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/2e4586cd-2027-4ae9-9dec-af8c2a9a58bd/sportswear-phoenix-fleece-high-waisted-oversized-tracksuit-bottoms-00TZkD.png", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Clothes");
        }
    }
}
