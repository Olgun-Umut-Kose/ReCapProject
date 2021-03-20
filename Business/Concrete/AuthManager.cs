using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        
        public IDataResult<User> Register(UserforRegisterDTO registerDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassHash(registerDto.Pass, out passwordHash, out passwordSalt);
            User user = new User
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PassHash = passwordHash,
                PassSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(Messages.Success, user);
            
        }

        public IDataResult<User> Login(UserforLoginDTO loginDto)
        {
            User userToCheck = _userService.GetByMail(loginDto.Email).Data;
            IResult result = UserExists(loginDto.Email);
            if (result.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotExist,null);
            }

            if (!HashingHelper.VerifyPassHash(loginDto.Pass,userToCheck.PassHash,userToCheck.PassSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongPassword,null);
            }

            return new SuccessDataResult<User>(Messages.Success ,userToCheck);
            
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data ==null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.UserExist); 
            
            
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            return new SuccessDataResult<AccessToken>(Messages.TokenCreated,_tokenHelper.CreateToken(user, _userService.GetClaims(user).Data));
            
            
        }
    }
}