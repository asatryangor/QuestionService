using ProfileService.Enums;
using System.Collections.Generic;

namespace ProfileService.Models.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public ResponseStatus? Status { get; set; }

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(string error, ResponseStatus status = ResponseStatus.None)
        {
            Success = false;
            Errors = new List<string> { error };
            Status = status;
        }

        public BaseResponse(List<string> errors, ResponseStatus status = ResponseStatus.None)
        {
            Success = false;
            Errors = errors;
            Status = status;
        }
    }
}