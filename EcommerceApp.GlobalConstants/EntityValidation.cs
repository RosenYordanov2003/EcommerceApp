namespace EcommerceApp.GlobalConstants
{
    public static class EntityValidation
    {
        public static class CategoryEntity
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int GenderMinLength = 3;
            public const int GenderMaxLength = 15;
        }
        public static class BrandEntity
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }
        public static class ClothesEntity
        {
            public const int NameMinLength = 3; 
            public const int NameMaxLength = 55;

            public const int ColorMinLength = 3;
            public const int ColorMaxLength = 34;

            public const int GenderMinLength = 3;
            public const int GenderMaxLength = 5;
        }
        public static class ShoesEntity
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 55;

            public const int ColorMinLength = 3;
            public const int ColorMaxLength = 34;

            public const int GenderMinLength = 3;
            public const int GenderMaxLength = 5;
        }
        public static class ClothesSizeEntity
        {
            public const int SizeMinLength = 1;
            public const int SizeMaxLength = 10;
        }
        public static class ShoesSizeEntity
        {
            public const double SizeMinValue = 30.00;
            public const double SizeMaxValue = 50.00;
        }
    }
}