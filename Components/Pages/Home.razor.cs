using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Components.Pages
{
	public partial class Home : ComponentBase
	{
		private class UserData
		{
			public string Login= "";
			public string Password = "";
		}

		private string m_message = "";
		EditContext? m_dataContext;
		private UserData m_userData = new();

		private List<string> m_images = new();
		private string m_selectedImage = "";

		protected override void OnInitialized()
		{
			m_dataContext = new(m_userData);
			m_images = Directory.GetFiles(@"./wwwroot/", "*.png", SearchOption.AllDirectories).Select(path=>path.Replace(@"./wwwroot/","")).ToList();
		}

		private async void LoginAsync()
		{
			await UserAuthenticationStateProvider.LoginAsync(m_userData.Login, m_userData.Password);
			if (UserAuthenticationStateProvider.CurrentUser == null)
			{
				m_message = "Invalid login or password!";
				return;
			}

			m_message = "";
		}

		private void Logout()
		{
			UserAuthenticationStateProvider.Logout();
		}

		private void ApplyAvatar()
		{
			UserAuthenticationStateProvider.CurrentUser.AvatarPath = m_selectedImage;
			m_selectedImage = "";
			StateHasChanged();
		}
	}
}