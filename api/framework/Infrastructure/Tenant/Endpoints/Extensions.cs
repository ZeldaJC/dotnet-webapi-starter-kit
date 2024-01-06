﻿using FSH.Framework.Infrastructure.Tenant.Endpoints.v1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Framework.Infrastructure.Tenant.Endpoints;
public static class Extensions
{
    public static IEndpointRouteBuilder MapTenantEndpoints(this IEndpointRouteBuilder app)
    {
        var tenantGroup = app.MapGroup("tenants").WithTags("tenants");
        tenantGroup.MapRegisterTenantEndpoint();
        tenantGroup.MapGetTenantsEndpoint();
        return app;
    }
}
