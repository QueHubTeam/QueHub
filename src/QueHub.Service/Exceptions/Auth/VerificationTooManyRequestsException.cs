﻿namespace QueHub.Service.Exceptions.Auth;

public class VerificationTooManyRequestsException : TooManyRequestException
{
	public VerificationTooManyRequestsException()
	{
		TitleMessage = "You tried more than limits!";
	}
}
