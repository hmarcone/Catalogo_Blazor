﻿using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blazor_Catalogo.Client.Auth
{
    public class DemoAuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState>
            GetAuthenticationStateAsync()
        {
            await Task.Delay(2000);
            //indicamos se o usuário esta autenticado e 
            //também os seus claims

            var usuario = new ClaimsIdentity(new List<Claim>() {
              new Claim("Chave", "Valor"),
              new Claim(ClaimTypes.Name, "Humberto Marcone"),
              new Claim(ClaimTypes.Role, "Admin")
            }, "demo");

            //var usuario = new ClaimsIdentity();

            return await Task.FromResult(new AuthenticationState(
                new ClaimsPrincipal(usuario)));
        }
    }
}
