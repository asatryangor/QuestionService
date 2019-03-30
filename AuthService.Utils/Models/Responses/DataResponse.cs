using System.Collections.Generic;

namespace Utils.Models.Responses
{
    public class DataResponse<T> : BaseResponse
    {
        public object Data { get; }
        
        public int? TotalCount { get; }
        
        public DataResponse(T res)
        {
            Data = res;
        } 

        public DataResponse(IList<T> res, int totalCount)
        {
            Data = res;
            TotalCount = totalCount;
        }
    }
}