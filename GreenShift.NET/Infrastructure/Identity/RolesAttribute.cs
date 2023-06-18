﻿using Microsoft.AspNetCore.Authorization;

public class RolesAttribute : AuthorizeAttribute
{
    public RolesAttribute(params string[] roles)
    {
        Roles = string.Join(",", roles);
    }
}