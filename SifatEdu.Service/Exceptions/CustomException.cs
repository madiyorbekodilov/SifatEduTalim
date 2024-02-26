namespace SifatEdu.Service.Exceptions;

public class CustomException : Exception
{
	public CustomException(int statusCode, string message) : base(message)
	{
		this.statusCode = statusCode;
	}

	public int statusCode { get; set; } 
}
