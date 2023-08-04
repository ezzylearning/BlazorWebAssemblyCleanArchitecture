using AutoMapper;
using AutoMapper.QueryableExtensions; 

using BlazorWebAssemblyCleanArchitecture.Application.Interfaces.Repositories;
using BlazorWebAssemblyCleanArchitecture.Domain.Entities;

using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace BlazorWebAssemblyCleanArchitecture.Application.Features.Stadiums.Queries.GetAllStadiums
{
    public record GetAllStadiumsQuery : IRequest<List<GetAllStadiumsDto>>;

    internal class GetAllPlayersQueryHandler : IRequestHandler<GetAllStadiumsQuery, List<GetAllStadiumsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPlayersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllStadiumsDto>> Handle(GetAllStadiumsQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Stadium>().Entities
                   .ProjectTo<GetAllStadiumsDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken); 
        }
    }
}
