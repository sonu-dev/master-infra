using Master.Microservices.Common.Bases;
using System.Collections.Generic;

namespace Master.Microservices.Catalog.ViewModels.Response
{
    public class GetProductCategoriesResponseViewModel : ApiResponseBase
    {
        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}
