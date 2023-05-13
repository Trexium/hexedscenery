using HexedSceneryCommon.User;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace HexedSceneryWebsite.Services
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfo();
            
    }

    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<UserInfo> GetUserInfo()
        {
            var ip = _httpContextAccessor.HttpContext.Connection?.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            }
            var userInfo = new UserInfo();
            userInfo.IpAddress = ip;

            return userInfo;
        }
    }
}
