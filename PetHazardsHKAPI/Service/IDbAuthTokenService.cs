using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHazardsHKAPI.Service
{
	public interface IDbAuthTokenService
	{
		Task<string> GetToken();
	}
}
