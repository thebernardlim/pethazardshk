using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHazardsHKAPI.Service
{
    public class AzureSqlAuthTokenService : IDbAuthTokenService
    {
        public async Task<string> GetToken()
        {
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            var token = await provider.GetAccessTokenAsync("https://database.windows.net/");
            var user = provider.PrincipalUsed;


            return token;
        }
    }
}
