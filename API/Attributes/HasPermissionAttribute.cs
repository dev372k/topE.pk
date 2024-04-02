using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using API.Controllers;

public class HasPermissionAttribute : Attribute, IActionFilter
{
    private string _permission;

    public HasPermissionAttribute(string permission)
    {
        _permission = permission;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        string jwtToken = context.HttpContext.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(jwtToken))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            return;
        }

        if (jwtToken.StartsWith("Bearer ") || jwtToken.StartsWith("bearer "))
        {
            jwtToken = jwtToken.Substring(7);
        }
        else
        {
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            return;
        }

        UserData userData = ValidateJwtAndGetUserData(jwtToken);

        if (userData != null && UserHasPermission(userData, _permission))
        {
            return;
        }

        context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
    }

    public void OnActionExecuted(ActionExecutedContext context) { }

    private UserData ValidateJwtAndGetUserData(string jwtToken)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var userDataJson = token.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata")?.Value;
            if (!string.IsNullOrEmpty(userDataJson))
                return JsonConvert.DeserializeObject<UserData>(userDataJson);
        }
        catch (Exception) { }

        return null;
    }

    private bool UserHasPermission(UserData userData, string permission)
    {
        var role = userData.Role.FirstOrDefault(r => r.Permission == permission);
        return role != null && role.IsAllowed;
    }
}

