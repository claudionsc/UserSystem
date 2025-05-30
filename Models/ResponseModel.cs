using Microsoft.AspNetCore.Http.HttpResults;

namespace UsersSystem.Models
{
    public class ResponseModel<T>
    {
        public T? Dado { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool HttpStatusCode { get; set; } = true;
    }
}
