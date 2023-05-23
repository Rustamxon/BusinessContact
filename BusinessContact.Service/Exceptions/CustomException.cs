namespace BusinessContact.Service.Exceptions;

public class CustomException : Exception
{
    public int Code { get; set; }
    public CustomException(int code, string Message) : base(Message)
    {
        this.Code = code;
    }
}
