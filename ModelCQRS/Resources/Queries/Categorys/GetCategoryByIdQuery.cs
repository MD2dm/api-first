using MediatR;
namespace ModelCQRS.Resources.Queries.Categorys
{
    public class GetCategoryByIdQuery : IRequest<Models.Category>
    {
        public int Id { get; set; }
    }
}

