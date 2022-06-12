using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities;
using Serilog;

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
        private readonly PizzaParadiseContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ListUserAction> _logger;

        public ListUserAction(PizzaParadiseContext context, IMapper mapper, ILogger<ListUserAction> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async ValueTask<IReadOnlyList<UserModelList>> ExecuteAsync()
        {
            _logger.LogInformation("Action started {Action}", nameof(ListUserAction));
            //Log.Logger.Information("Action started {Action} SeriLogger", nameof(ListUserAction));

            var result = await _context.Users
                .ProjectToType<UserModelList>()
                .ToListAsync();

            return result;
        }
    }
}
