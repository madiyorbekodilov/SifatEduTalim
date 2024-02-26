using Microsoft.AspNetCore.Http;

namespace SifatEdu.Service.Extentions;

public static class Convertor
{
    public static byte[] ToByte(this IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        formFile.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}