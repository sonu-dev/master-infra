using Master.Core.Logging;
using Master.Microservices.Catalog.ViewModels;
using Master.Microservices.Common.Bases.Cqrs;
using System.Threading.Tasks;

namespace Master.Microservices.Catalog.Handlers.Commands
{
    public class AddCategoryCommandResponse
    {
        public ProductCategoryViewModel productCategoryVm { get; set; }
    }

    public class AddCategoryCommandRequest : RequestBase<AddCategoryCommandResponse>
    {
        public ProductCategoryViewModel productCategoryVm { get; set; }
    }

    public class AddCategoryCommand: AddCategoryCommandRequest
    {
        public class AddCategoryCommandHandler : RequestHandlerBase<AddCategoryCommand, AddCategoryCommandRequest, AddCategoryCommandResponse>
        {
            public AddCategoryCommandHandler(ILog<AddCategoryCommand> log) : base(log)
            {

            }
            public override Task<AddCategoryCommandResponse> ProcessAsync(AddCategoryCommandRequest request)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
