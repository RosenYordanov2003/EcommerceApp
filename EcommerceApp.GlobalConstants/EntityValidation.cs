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

            public const int DescriptionMaxLength = 450;
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
        public static class ProductStockEntity
        {
            public const int SizeMinLength = 1;
            public const int SizeMaxLength = 6;
        }
        public static class ShoesSizeEntity
        {
            public const double SizeMinValue = 35.00;
            public const double SizeMaxValue = 45.00;
        }
        public static class ReviewEntity
        {
            public const int ContentMaxValue = 200;
            public const int ContentMinValue = 5;

            public const int StarEvaluationMinValue = 0;
            public const int StarEvaluationMaxValue = 5;

            public const int SummaryMaxValue = 30;
        }
        public static class OrderEntity
        {
            public const int FirstNameMaxLength = 30;
            public const int FirstNameMinLength = 3;

            public const int AdressMaxLength = 60;
            public const int AdressMinLength = 4;

            public const int CountryMaxLength = 56;
            public const int CountryMinLength = 4;

            public const int ShippingMethodMaxLength = 20;

            public const int CityMaxLength = 60;
            public const int CityMinLength = 4;
        }
    }
}