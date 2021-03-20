using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;


namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepoBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from oc in context.OperationClaims
                    join uoc in context.UserOperationClaims
                        on oc.Id equals uoc.OperationClaimsId
                    where uoc.UserId == user.Id
                    select new OperationClaim {Id = oc.Id, Name = oc.Name};

                return result.ToList();

            }
        }

        
    }
}