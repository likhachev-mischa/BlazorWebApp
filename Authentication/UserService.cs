namespace Authentication
{
	public class UserService
	{
		public async Task<User?> FindUserFromDatabaseAsync(string username, string password)
		{
			var userListFromDatabase = new List<User>()
			{
				new()
				{
					Username = "admin",
					Password = "admin",
					Roles = new()
					{
						"admin"
					},
				},
				new()
				{
					Username = "user",
					Password = "user",
					Roles = new()
					{
						"user"
					},
				},
			};

			var userInDatabase =
				userListFromDatabase.FirstOrDefault(u => u.Username == username && u.Password == password);

			return userInDatabase;
		}
	}
}