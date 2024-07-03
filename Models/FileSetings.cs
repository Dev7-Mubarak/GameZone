namespace GameZone.Models
{
    public static class FileSetings
    {
        public const string ImagesPath = "/Assets/Images/Rests";

        public const string AllowedExtenstions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }

}
