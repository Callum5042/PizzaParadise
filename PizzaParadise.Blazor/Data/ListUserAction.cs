using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities;

namespace PizzaParadise.Blazor.Data
{
    public class UserModelList
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }

    public record UserRecordList(string? FirstName, string? LastName);

    public class ListUserAction 
    {
        private readonly IDbContextFactory<PizzaParadiseContext> _contextFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<ListUserAction> _logger;

        public ListUserAction(IDbContextFactory<PizzaParadiseContext> contextFactory, IMapper mapper, ILogger<ListUserAction> logger)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
            _logger = logger;
        }

        public async ValueTask<IReadOnlyList<UserModelList>> ExecuteAsync()
        {
            _logger.LogInformation("Action started {Action}", nameof(ListUserAction));

            using var context = _contextFactory.CreateDbContext();
            var result = await context.Users
                .ProjectToType<UserModelList>()
                .ToListAsync();

            return result;
        }
    }
}
