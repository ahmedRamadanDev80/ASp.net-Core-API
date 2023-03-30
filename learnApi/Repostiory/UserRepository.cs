using AutoMapper;
using learnApi.Data;
using learnApi.Models;
using learnApi.Models.Dto;
using learnApi.Repostiory.IRepostiory;

namespace learnApi.Repostiory
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public bool IsUniqueUser(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x=>x.UserName== username);
            if(user==null) { return true; }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            LocalUser user = _mapper.Map<LocalUser>(registerationRequestDTO);
            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
