using OCMS.Areas.Users.Models;
using OCMS.Common.CommonClasses;
using System;

namespace OCMS.Mappers
{
    public class UserCreaditionalMappers
    {

        public static UserCreadentials MapToAddUserCredentials(string password, Guid Id)
        {
            PaswordServices.GenerateHashAndSalt(password, out byte[] Hash, out byte[] Salt);
            var UserCredentialDomain = new UserCreadentials()
            {
                CreadId = Guid.NewGuid(),
                UserId = Id,
                PasswordHash = Hash,
                PasswordSalt = Salt,
                Otp = null
            };
            return UserCredentialDomain;
        }
        public static void MapToUpdatePassword(UserCreadentials userCreadentials, string password)
        {
            PaswordServices.GenerateHashAndSalt(password, out byte[] Hash, out byte[] Salt);

            userCreadentials.PasswordHash = Hash;
            userCreadentials.PasswordSalt = Salt;
            userCreadentials.Otp = null;
        }


    }
}