using System.Threading.Tasks;
using HellowWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HellowWorld.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            ServiceResponse<string> response=new ServiceResponse<string>();
            User user= await _context.Users.SingleOrDefaultAsync(u=>u.UserName.ToLower().Equals(username.ToLower()));
            if(user==null)
            {
                response.Success=false;
                response.Message="User not exists";
            }
            else if(!verifyPassword(password,user.PasswordHash,user.PasswordSalt))
            {
                response.Success=false;
                response.Message="Wrong Password";
            }
            else
            {
                response.data=user.Id.ToString();
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> serviceResponse= new ServiceResponse<int>();
            if(await userExists(user.UserName))
            {
                serviceResponse.Success=false;
                serviceResponse.Message="User already exists";
                return serviceResponse;
            }

            createPassword(password,out byte[] passwordHash,out byte[] passwordSalt);

            user.PasswordHash=passwordHash;
            user.PasswordSalt=passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            serviceResponse.data=user.Id;

            return serviceResponse;
        }

        public async Task<bool> userExists(string username)
        { 
            if(await _context.Users.AnyAsync(x => x.UserName.ToLower()==username.ToLower())){
                return true;
            }
            return false;
        }

        public void createPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hms = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hms.Key;
                passwordHash = hms.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

         public bool verifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hms = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            { 
                var computedHash = hms.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(int i=0;i<computedHash.Length;i++)
                {
                    if(computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                
                return true;
            }
        }
    }
}