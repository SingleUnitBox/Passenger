using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache memoryCache, Guid tokenId, JwtDto jwtDto)
            => memoryCache.Set(GetJwtKey(tokenId), jwtDto, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache memoryCache, Guid tokenId)
            => memoryCache.Get<JwtDto>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}
