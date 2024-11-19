using System.Security.Claims;

namespace Authentication
{
	public class User
	{
		public string Username { get; set; } = "";
		public string Password { get; set; } = "";
		public List<string> Roles { get; set; } = new();

		public string AvatarPath { get; set; } = "";

		public ClaimsPrincipal ToClaimsPrincipal() => new(new ClaimsIdentity(new Claim[]
			{
				new(ClaimTypes.Name, Username),
				new(ClaimTypes.Hash, Password),
			}.Concat(Roles.Select(r => new Claim(ClaimTypes.Role, r)).ToArray()),
			"aboba"));

		public static User FromClaimsPrincipal(ClaimsPrincipal principal)
		{
			return new()
			{
				Username = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
				Password = principal.FindFirst(ClaimTypes.Hash)?.Value ?? "",
				Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList()
			};
		}
	}
}