using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities;
using PizzaParadise.Entities.Models;

namespace PizzaParadise.Blazor.Data
{
    public class UserHandler
    {
        private readonly PizzaParadiseContext _context;
        private readonly IMapper _mapper;

        public UserHandler(PizzaParadiseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async ValueTask Test()
        {
            //var result = await _mapper.From(_context.Users).ProjectToType<UserDto>().FirstOrDefaultAsync();

            //var query = _context.Users.Where(x => x.FirstName == "Boom");
            //var mapping = _mapper.From(query).ProjectToType<UserDto>();
            //var dto = mapping.FirstAsync();

            //var result = await _context.Users
            //    .ProjectToType<UserDto>()
            //    .SingleAsync(x => x.FirstName == "Boom");


            var user = new User()
            {
                FirstName = "Callum",
                LastName = "Anning"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }

    public class UserDto
    {
        public UserDto()
        {

        }

        public string? FirstName { get; set; }
    }
}
