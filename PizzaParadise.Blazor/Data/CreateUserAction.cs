using MapsterMapper;
using PizzaParadise.Entities;
using PizzaParadise.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzaParadise.Blazor.Data
{
    public class UserModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
    }

    public class CreateUserAction
    {
        private readonly PizzaParadiseContext _context;
        private readonly IMapper _mapper;

        public CreateUserAction(PizzaParadiseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async ValueTask ExecuteAsync(UserModel model)
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
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
