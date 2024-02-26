namespace SifatEdu.Service.Helpers;

public class MediaHelper
{
    public static string MakeImageName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extention = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid() + extention;
        return name;
    }

    public static string[] GetImageExtention()
    {
        return new string[]
        {
            // JPG files
            ".jpg", ".jpeg",
            // Png files
            ".png",
            // Bmp files
            ".bmp",
            // Svg files
            ".svg"
        };
    }
}