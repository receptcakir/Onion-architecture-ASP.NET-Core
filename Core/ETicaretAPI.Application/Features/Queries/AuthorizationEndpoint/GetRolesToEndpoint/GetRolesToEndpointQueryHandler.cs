using GOAL.Application.Abstractions.Services;
using GOAL.Application.DTOs;
using GOAL.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOAL.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints
{
    public class GetRolesToEndpointQueryHandler : IRequestHandler<GetRolesToEndpointQueryRequest, CustomResponse<GetRolesToEndpointQueryResponse>>
    {
        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public GetRolesToEndpointQueryHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<CustomResponse<GetRolesToEndpointQueryResponse>> Handle(GetRolesToEndpointQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = await _authorizationEndpointService.GetRolesToEndpointAsync(request.Code, request.Menu);
            var response = new GetRolesToEndpointQueryResponse()
            {
                Roles = datas
            };
            return CustomResponse<GetRolesToEndpointQueryResponse>.Success(response,200);
        }
    }
}
