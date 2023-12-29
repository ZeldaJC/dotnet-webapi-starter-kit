﻿using Finbuckle.MultiTenant;
using FSH.Framework.Infrastructure.Persistence;
using FSH.WebApi.Todo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FSH.WebApi.Todo.Persistence;
public sealed class TodoDbContext : FshDbContext
{
    public TodoDbContext(ITenantInfo currentTenant, DbContextOptions options, IPublisher publisher)
        : base(currentTenant, options, publisher)
    {
    }

    public DbSet<TodoItem> Todos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);
        modelBuilder.HasDefaultSchema(SchemaNames.Todo);
    }
}
