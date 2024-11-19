using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Authentication
{
	public class UserAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
	{
		private readonly UserService m_userService;

		public User? CurrentUser { get; set; } = null;

		public UserAuthenticationStateProvider(UserService userService)
		{
			AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
			m_userService = userService;
		}

		private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
		{
			var authenticationState = await task;

			if (authenticationState is not null)
			{
				CurrentUser = User.FromClaimsPrincipal(authenticationState.User);
			}
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var principal = new ClaimsPrincipal();
			if (CurrentUser is not null)
			{
				principal = CurrentUser.ToClaimsPrincipal();
			}

			return new(principal);
		}

		public async Task LoginAsync(string username, string password)
		{
			var principal = new ClaimsPrincipal();
			var user = await m_userService.FindUserFromDatabaseAsync(username, password);
			CurrentUser = user;

			if (user is not null)
			{
				principal = user.ToClaimsPrincipal();
				NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
			}
		}

		public void Logout()
		{
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new())));
			CurrentUser = null;
		}

		public void Dispose()
		{
			AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;
		}
	}
}