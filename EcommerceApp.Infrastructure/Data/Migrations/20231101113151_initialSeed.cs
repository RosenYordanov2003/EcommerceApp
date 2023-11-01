using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class initialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_MainCategory_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    StarRating = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clothes_MainCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MainCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clothes_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarRating = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoes_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shoes_MainCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MainCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shoes_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothId = table.Column<int>(type: "int", nullable: true),
                    ShoesId = table.Column<int>(type: "int", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Clothes_ClothId",
                        column: x => x.ClothId,
                        principalTable: "Clothes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Picture_Shoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://static.vecteezy.com/system/resources/previews/010/994/412/non_2x/nike-logo-black-with-name-clothes-design-icon-abstract-football-illustration-with-white-background-free-vector.jpg", "Nike" },
                    { 2, "https://galleriaburgas.bg/?go=_common&p=companylogo&type=big&companyId=166", "Adidas" },
                    { 3, "https://modista.bg/image/catalog/aaaaaaaaa%20loga/PUMA-logo.jpg", "Puma" },
                    { 4, "https://img.guess.com/image/upload/q_auto/v1/NA/Asset/North%20America/E-Commerce/Shared/Guess-196x196.png", "Guess" },
                    { 5, "https://img.freepik.com/premium-vector/tommy-hilfiger-logo-set-top-clothing-brand-editorial-logotype-zdolbuniv-ukraine-april-26-2023_505956-735.jpg?w=2000", "Tommy Hilfiger" },
                    { 6, "https://www.logo-designer.co/storage/2022/08/2022-hugo-boss-new-logo-design.png", "HUGO BOSS" },
                    { 7, "https://i.pinimg.com/736x/6d/2c/cd/6d2ccd795e409bb68eec5db364e797ef.jpg", "Zara" }
                });

            migrationBuilder.InsertData(
                table: "MainCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "T-Shirts" },
                    { 2, "Jeans" },
                    { 3, "Jackets" },
                    { 4, "Coats" },
                    { 5, "Trousers" },
                    { 6, "Skirts" },
                    { 7, "Shorts" },
                    { 8, "Shirts" },
                    { 9, "Shoes" },
                    { 10, "Sweatshirts" }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "MainCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 9, "Sports Shoes" },
                    { 2, 9, "Sandals" },
                    { 3, 9, "Trainers" },
                    { 4, 9, "Football Boats" },
                    { 5, 8, "Football Shirts" },
                    { 6, 8, "Long sleeve shirts" },
                    { 7, 8, "Short sleeve shirts" },
                    { 8, 8, "Dress Shirts" },
                    { 9, 7, "Swimming Shorts" },
                    { 10, 7, "Football Shorts" },
                    { 11, 7, "Cargo Shorts" },
                    { 12, 7, "Bermuda Shorts" },
                    { 13, 6, "Line Skirts" },
                    { 14, 6, "Tube Skirts" },
                    { 15, 6, "Cicle Skirts" },
                    { 16, 4, "Wrap Coats" },
                    { 17, 4, "Trench Coats" },
                    { 18, 4, "Fur Coats" },
                    { 19, 3, "Bomber Jackets" },
                    { 20, 3, "Denim Jackets" },
                    { 21, 3, "Biker Jackets" },
                    { 22, 2, "Straight leg jeans" },
                    { 23, 2, "Tapered jeans" },
                    { 24, 1, "Polo T-Shirts" },
                    { 25, 1, "Singlet T-shirts" },
                    { 26, 1, "Pocket T-shirts" },
                    { 27, 10, "Hooded Sweatshirts" },
                    { 28, 10, "Sweatshirts without a hood" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "BrandId", "CategoryId", "Color", "Description", "Gender", "Name", "Price", "StarRating", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, 1, 9, "Black", "The radiance lives on in the Nike Air Force 1 '07 LV8. Crossing hardwood comfort with off-court flair, these kicks put a fresh spin on a hoops classic. Soft suede overlays pair with era-echoing '80s construction and reflective-design Swoosh logos to bring you nothing-but-net style while hidden full-length Air units add the legendary comfort you know and love.", "Men", "Nike Air Force 1 '07 LV8", 130m, 5, 3 },
                    { 2, 1, 9, "White", "The pitch is yours when you lace up in the Vapor 15 Pro AG-Pro. It's loaded with a Zoom Air unit, so you can dominate in the waning minutes of a match—when it matters most. Fast is in the Air.", "Men", "Nike Mercurial Vapor 15 Pro", 160m, 5, 4 },
                    { 3, 1, 9, "Black", "Instantly tilt the pitch in the bold design of the Superfly 9 Elite SG-Pro. We added a Zoom Air unit, made specifically for football, and grippy texture up top for exceptional touch, so you can dominate in the waning minutes of a match—when it matters most. Feel the explosive speed as you race around the pitch, making the critical plays with velocity and pace. Fast is in the Air. This version has Anti-Clog Traction on the soleplate, which helps prevent mud from sticking.", "Men", "Nike Mercurial Superfly 9 Elite", 250m, 5, 4 },
                    { 4, 1, 9, "Black", "So you're in love with the classic look of the '90s, but you've got a thing for today's fast-paced culture. Meet the Air Max TW. Inspired by the treasured franchise that brought Nike Air cushioning to the world and laid the foundation for the track-to-street aesthetic, its eye-catching design delivers a 1–2 punch of comfort and fashion. Ready to highlight any 'fit, its lightweight upper pairs angular and organic lines to create an entrancing haptic effect. The contrasting colourways make it easy to style. And if you're ready for the next step, the 5 windows underfoot deliver a modern edge to visible Air cushioning.", "Men", "Nike Air Max TW", 0m, 5, 3 },
                    { 5, 1, 9, "Black", "We looked into the future and it's gonna be comfy. Featuring a \"point-loaded\" Air unit (cushioning that forms to your every step), the Air Max Scorpion Flyknit delivers a futuristic sensation. And because looks count, we've crafted the upper from incredibly soft chenille-like fabric.", "Women", "Nike Air Max Scorpion Flyknit", 160m, 5, 3 },
                    { 6, 1, 9, "Blue", "The Nike Air VaporMax Plus looks to the past and propels you into the future. Nodding to the 1998 Air Max Plus with its floating cage, padded upper and heel logo, it adds revolutionary VaporMax Air technology to ramp up the comfort and create a modern look.", "Men", "Nike Air VaporMax Plus", 180m, 5, 3 },
                    { 7, 2, 9, "Dark Blue", "Designed for athletes who run to stay fit for their sport, these running shoes support multidirectional movements with flexible cushioning and a wide, stable platform in the forefoot and heel. They have a seamless, sock-like mesh upper with targeted areas of support and stretch for an adaptive fit.\r\nRunner type\r\nNeutral shoes for the versatile runner\r\nAdaptive fit\r\nSeamless Forgedmesh upper designed with areas of support and stretch to help ensure a custom fit that adapts to every move\r\nSpringy cushioning\r\nBounce cushioning provides enhanced comfort and flexibility\r\nReliable traction\r\nContinental™ Rubber outsole for extraordinary traction in wet and dry conditions", "Men", "Adidas Alphabounce Beyond Team", 70m, 4, 1 },
                    { 8, 2, 9, "Dark Red", "Designed for athletes who run to stay fit for their sport, these running shoes support multidirectional movements with flexible cushioning and a wide, stable platform in the forefoot and heel. They have a seamless, sock-like mesh upper with targeted areas of support and stretch for an adaptive fit.\r\nRunner type\r\nNeutral shoes for the versatile runner\r\nAdaptive fit\r\nSeamless Forgedmesh upper designed with areas of support and stretch to help ensure a custom fit that adapts to every move\r\nSpringy cushioning\r\nBounce cushioning provides enhanced comfort and flexibility\r\nReliable traction\r\nContinental™ Rubber outsole for extraordinary traction in wet and dry conditions", "Men", "Adidas Alphabounce Beyond Team", 70m, 4, 1 },
                    { 9, 2, 9, "Orange", "Dominate space. Command the play. Create goal-destined shots from impossible angles. Control the game with every touch in ACE. These juniors' soccer cleats have a 3D Control Skin upper that delivers precise control with zero wear-in time. Designed to dominate on firm ground.", "Men", "Adidas ACE 17.3 Firm Ground", 78.41m, 0, 4 },
                    { 10, 2, 9, "White", "Showcase your playmaking speed in these football cleats. Designed for easy on and off, they feature a textile upper with a sock-like construction for lightweight stability and lockdown as you create havoc at the line of scrimmage. The cleated outsole provides traction for quick cuts and pivots.. These juniors' soccer cleats have a 3D Control Skin upper that delivers precise control with zero wear-in time. Designed to dominate on firm ground.", "Men", "Adidas Adizero 8.0", 83.41m, 0, 4 },
                    { 11, 2, 9, "Red", "If your command of the field leaves your rivals' tactics in tatters, you're ready to own Predators. Built for precision on firm ground, these soccer cleats have a supportive mesh upper that wraps around your foot to lock you in. This eliminates the need for laces and leaves more room for ball control. Embossing on the surface adds confidence to every touch.", "Men", "Adidas Predator 19.3 Laceless Firm Ground", 83.41m, 0, 4 },
                    { 12, 3, 9, "Black", "We’re taking Slipstream to the extreme. This disruptive new version features an iconic Slipstream leather upper with elevated details, and a edgier sole with exaggerated proportions and rugged details. This execution features a leather base with nubuck overlays, a suede Formstrip with deep debossed lines and suede details.", "Men", "Slipstream Xtreme Sneakers", 140m, 0, 1 },
                    { 13, 3, 9, "White", "Back in 1987, the PUMA Slipstream Mid entered the scene as a basketball sneaker. A high-flying, slam-dunking, statement-making basketball sneaker. Now, it’s joined by the Slipstream – a rework of the original that brings an all-new energy to the game while staying true to the OG’s sporting roots.", "Women", "Slipstream Leather Sneakers", 70m, 0, 1 },
                    { 14, 3, 9, "Red", "Back in 1987, the PUMA Slipstream Mid entered the scene as a basketball sneaker. A high-flying, slam-dunking, statement-making basketball sneaker. Now, it’s joined by the Slipstream – a rework of the original that brings an all-new energy to the game while staying true to the OG’s sporting roots.", "Women", "Slipstream Leather Sneakers", 70m, 0, 1 },
                    { 15, 3, 9, "Green", "ULTRA - Not even you knew you could be this fast. Turn seconds into records with the ULTRA ULTIMATE football boot. Lighter means quicker, so the ULTRAWEAVE upper material makes every gram and every second count. Ultra-light. Ultra-fast. ULTRA ULTIMATE.", "Men", "ULTRA ULTIMATE MG Football Cleats Men", 70m, 0, 4 },
                    { 16, 3, 9, "Blue", "ULTRA - Not even you knew you could be this fast. Turn seconds into records with the ULTRA ULTIMATE football boot. Lighter means quicker, so the ULTRAWEAVE upper material makes every gram and every second count. Ultra-light. Ultra-fast. ULTRA ULTIMATE.", "Men", "ULTRA PLAY IT Youth Football Boots", 60m, 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "Id", "ClothId", "ImgUrl", "ShoesId" },
                values: new object[,]
                {
                    { 1, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b3546974-0d23-4657-a8a7-8d6abc9fc5e8/air-force-1-07-lv8-shoes-p2p25V.png", 1 },
                    { 2, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/0bab9b0c-3598-4b1f-b3eb-acd64788a258/air-force-1-07-lv8-shoes-p2p25V.png", 1 },
                    { 3, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/67701610-e9ef-4dbf-9a3b-df35affa59cb/air-force-1-07-lv8-shoes-p2p25V.png", 1 },
                    { 4, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9fec2c65-bf79-49ae-b6fa-158e74827be2/air-force-1-07-lv8-shoes-p2p25V.png", 1 },
                    { 5, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/c599987c-9750-459a-badf-35805b4571e7/mercurial-vapor-15-pro-football-boot-4R8klC.png", 2 },
                    { 6, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/576f6b39-4803-42ec-84f8-b57d2da31093/mercurial-vapor-15-pro-football-boot-4R8klC.png", 2 },
                    { 7, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/5e5eb7a2-59e5-44d7-bcde-e7389c729991/mercurial-vapor-15-pro-football-boot-4R8klC.png", 2 },
                    { 8, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9d2426ad-828b-45f1-888e-7ea3af347b20/mercurial-vapor-15-pro-football-boot-4R8klC.png", 2 },
                    { 9, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/ecba7aa5-adf6-4a1d-855e-58df68fb9170/mercurial-superfly-9-elite-football-boot-D6qDRk.png", 3 },
                    { 10, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/1e8ec3dd-4463-4e20-a5b1-f25c15869887/mercurial-superfly-9-elite-football-boot-D6qDRk.png", 3 },
                    { 11, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/285cb55e-8273-459c-a261-dfd4a2c29ac8/mercurial-superfly-9-elite-football-boot-D6qDRk.png", 3 },
                    { 12, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/0eba4f6d-54d3-4411-9343-f6f8fcdcf048/mercurial-superfly-9-elite-football-boot-D6qDRk.png", 3 },
                    { 13, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/44103b50-8fd8-4316-91c9-526a794ed12f/air-max-tw-shoes-bfGWNc.png", 4 },
                    { 14, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/5638aa3c-36da-438f-a41c-7cbd9ec9dce1/air-max-tw-shoes-bfGWNc.png", 4 },
                    { 15, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9265edc0-eb2e-40de-a224-1da42557b371/air-max-tw-shoes-bfGWNc.png", 4 },
                    { 16, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/3a59615f-7032-4c60-8848-5267fcdba4b6/air-max-tw-shoes-bfGWNc.png", 4 },
                    { 17, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/efc9de26-5f37-4a37-a49b-3bf8639076d0/air-max-scorpion-flyknit-shoes-jhBW7t.png", 5 },
                    { 18, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/e6ef5f97-e01d-4e3c-b929-e7f95a566f44/air-max-scorpion-flyknit-shoes-jhBW7t.png", 5 },
                    { 19, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/3c93e6be-3b5f-4336-af41-da346f127403/air-max-scorpion-flyknit-shoes-jhBW7t.png", 5 },
                    { 20, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/d788cb32-f0e4-4426-acdf-f25b4ad3d574/air-max-scorpion-flyknit-shoes-jhBW7t.png", 5 },
                    { 21, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/yommy4ijgwgrzbebxtvm/air-vapormax-plus-shoes-yATY9p7E.png", 6 },
                    { 22, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/ehxtdksphjfm10zn2goz/air-vapormax-plus-shoes-yATY9p7E.png", 6 },
                    { 23, null, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/bv4nc2mve7pvlkhzzh9s/air-vapormax-plus-shoes-yATY9p7E.png", 6 },
                    { 24, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675.jpg", 7 },
                    { 25, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_2.jpg", 7 },
                    { 26, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_4.jpg", 7 },
                    { 27, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_5.jpg", 7 },
                    { 28, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673.jpg", 8 },
                    { 29, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_2.jpg", 8 },
                    { 30, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_4.jpg", 8 },
                    { 31, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_5.jpg", 8 },
                    { 32, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_1.jpg", 9 },
                    { 33, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_2.jpg", 9 },
                    { 34, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371.jpg", 9 },
                    { 35, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_3.jpg", 9 },
                    { 36, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521.jpg", 10 },
                    { 37, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_2.jpg", 10 },
                    { 38, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_3.jpg", 10 },
                    { 39, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_5.jpg", 10 },
                    { 40, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Predator%2019%203%20Laceless%20Firm%20G%201115.jpg", 11 },
                    { 41, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Predator%2019%203%20Laceless%20Firm%20G%201115_2.jpg", 11 },
                    { 42, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Predator%2019%203%20Laceless%20Firm%20G%201115_3.jpg", 11 }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "Id", "ClothId", "ImgUrl", "ShoesId" },
                values: new object[,]
                {
                    { 43, null, "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Predator%2019%203%20Laceless%20Firm%20G%201115_4.jpg", 11 },
                    { 44, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/392434/02/sv01/fnd/EEA/fmt/png/Slipstream-Xtreme-Sneakers", 12 },
                    { 45, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/392434/02/bv/fnd/EEA/fmt/png/Slipstream-Xtreme-Sneakers", 12 },
                    { 46, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/392434/02/sv02/fnd/EEA/fmt/png/Slipstream-Xtreme-Sneakers", 12 },
                    { 47, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/392434/02/sv04/fnd/EEA/fmt/png/Slipstream-Xtreme-Sneakers", 12 },
                    { 48, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/387544/02/sv01/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers", 13 },
                    { 49, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/02/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers", 13 },
                    { 50, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/02/bv/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers", 13 },
                    { 51, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/02/sv02/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers", 13 },
                    { 52, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/387544/16/sv01/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers", 14 },
                    { 53, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/387544/16/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers", 14 },
                    { 54, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/16/bv/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers", 14 },
                    { 55, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/387544/16/sv04/fnd/EEA/fmt/png/Slipstream-Leather-Sneakers", 14 },
                    { 56, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/107214/03/sv01/fnd/EEA/fmt/png/ULTRA-ULTIMATE-MG-Football-Cleats-Men", 15 },
                    { 57, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107214/03/bv/fnd/EEA/fmt/png/ULTRA-ULTIMATE-MG-Football-Cleats-Men", 15 },
                    { 58, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107214/03/sv02/fnd/EEA/fmt/png/ULTRA-ULTIMATE-MG-Football-Cleats-Men", 15 },
                    { 59, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107214/03/sv04/fnd/EEA/fmt/png/ULTRA-ULTIMATE-MG-Football-Cleats-Men", 15 },
                    { 60, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/107535/03/sv01/fnd/EEA/fmt/png/ULTRA-PLAY-IT-Youth-Football-Boots", 16 },
                    { 61, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107535/03/sv02/fnd/EEA/fmt/png/ULTRA-PLAY-IT-Youth-Football-Boots", 16 },
                    { 62, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107535/03/sv02/fnd/EEA/fmt/png/ULTRA-PLAY-IT-Youth-Football-Boots", 16 },
                    { 63, null, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/107535/03/sv04/fnd/EEA/fmt/png/ULTRA-PLAY-IT-Youth-Football-Boots", 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_BrandId",
                table: "Clothes",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_CategoryId",
                table: "Clothes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_SubCategoryId",
                table: "Clothes",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ClothId",
                table: "Picture",
                column: "ClothId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ShoesId",
                table: "Picture",
                column: "ShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_BrandId",
                table: "Shoes",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_CategoryId",
                table: "Shoes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_SubCategoryId",
                table: "Shoes",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_MainCategoryId",
                table: "SubCategory",
                column: "MainCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "MainCategory");
        }
    }
}
