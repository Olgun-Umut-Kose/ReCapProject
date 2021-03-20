using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;


namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepo<User>
    {
        List<OperationClaim> GetClaims(User user);
        
    }
}