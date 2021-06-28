using System.Collections.Generic;

namespace Master.Web.Api.ViewModels.Requests
{
    public class GetTodosRequest
    {
        public List<int> TodoIds { get; set; }
    }
}
