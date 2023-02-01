using F = GOAL.Domain.Entities;

namespace GOAL.Application.Repositories
{
    public interface IFileWriteRepository : IWriteRepository<F::File>
    {
    }
}
