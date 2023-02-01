using ETicaretAPI.Application.Repositories;
using GOAL.Application.DTOs;
using MediatR;
using P = ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct
{
    internal class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, CustomResponse<GetByIdProductQueryResponse>>
    {

        readonly IProductReadRepository _productReadRepository;
        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<CustomResponse<GetByIdProductQueryResponse>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await _productReadRepository.GetByIdAsync(request.Id, false);
            var response = new GetByIdProductQueryResponse()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };

            return CustomResponse<GetByIdProductQueryResponse>.Success(response, 201);
        }
    }
}
