namespace FiscalInfoApp.Common
{
    public static class DataConstants
    {
        public static class CompanyConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;

            public const int CityMinLength = 3;
            public const int CityMaxLength = 20;

            public const int StreetMinLength = 5;
            public const int StreetMaxLength = 40;
        }

        public static class PetrolStationConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;

            public const int CityMinLength = 3;
            public const int CityMaxLength = 20;

            public const int StreetMinLength = 5;
            public const int StreetMaxLength = 40;
        }

        public static class FiscalPrinterConstants
        {
            public const int OsNumberLength = 8;
            public const int MemotyNumberLength = 8;
            public const int FdridLength = 7;
        }

        public static class SimCardConstants
        {
            public const int SimCardImsiLength = 15;
            public const int SimCardGsmNumberLength = 12;

            public const int OperatorNameMinLength = 1;
            public const int OperatorNameMaxLength = 10;
        }

        public static class FuelDispenserConstants
        {
            public const int FuelDispenserNumberMin = 1;
            public const int FuelDispenserNumberMax = 20;

            public const int BrandMinLength = 1;
            public const int BrandMaxLength = 20;

            public const int ModelMinLength = 1;
            public const int ModelMaxLength = 30;

            public const int NozzleCountMin = 1;
            public const int NozzleCountMax = 12;

            public const int MidCertificateMinLength = 4;
            public const int MidCertificateMaxLength = 20;
        }

        public static class FuelTankConstants
        {
            public const int TankMinNumber = 1;
            public const int TankMaxNumber = 10;

            public const double FullVolumeMin = 1000;
            public const double FullVolumeMax = 60_000;

            public const double DiameterMinCm = 100;
            public const double DiameterMaxCm = 1000;

            public const int FuelTypeMinLength = 3;
            public const int FuelTypeMaxLength = 20;
        }

        public static class OilLevelTypeConstants
        {
            public const int BrandMinLength = 1;
            public const int BrandMaxLength = 20;

            public const int ModelMinLength = 1;
            public const int ModelMaxLength = 30;
        }

        public static class ProbeConstants
        {
            public const double ProbeMinLengthCm = 100;
            public const double ProbeMaxLengthCm = 500;

            public const int FloatSizeMinMm = 50;
            public const int FloatSizeMaxMm = 110;

            public const int FloatFuelTypeMinLength = 3;
            public const int FloatFuelTypeMaxLength = 10;
        }

        public static class CommControllerConstants
        {
            public const int CommTypeMinLength = 1;
            public const int CommTypeMaxLength = 10;

            public const int BoxColorMinLength = 1;
            public const int BoxColorMaxLength = 10;
        }

        public static class CommentConstants
        {
            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 1000;
        }
    }
}
