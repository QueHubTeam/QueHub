﻿namespace QueHub.Service.Exceptions.Users;

public class UserCacheDataExpiredException : ExpiredException
{
	public UserCacheDataExpiredException()
	{
		TitleMessage = "User data has expired!";
	}
}
