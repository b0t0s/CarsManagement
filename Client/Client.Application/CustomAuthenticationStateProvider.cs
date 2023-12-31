﻿using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace CarsManagement.Client.Application;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public ClaimsPrincipal User { get; set; } = new(new ClaimsIdentity());

    public override Task<AuthenticationState?> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(User));
    }

    public void NotifyUserAuthentication(string username)
    {
        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "apiauth_type");

        User = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}