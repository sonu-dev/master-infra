namespace Master.Microservices.Common.Bases
{
    public abstract class ApiResponseBase
    {
        public bool IsSuccess { get; set; } = true;
    }
}
