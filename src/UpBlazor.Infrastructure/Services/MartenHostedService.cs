﻿using System.Threading;
using System.Threading.Tasks;
using Marten;
using Microsoft.Extensions.Hosting;

namespace UpBlazor.Infrastructure.Services;

public class MartenHostedService : IHostedService
{
    private readonly IDocumentStore _store;

    public MartenHostedService(IDocumentStore store)
    {
        _store = store;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _store.Schema.ApplyAllConfiguredChangesToDatabaseAsync();
        await _store.Schema.AssertDatabaseMatchesConfigurationAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}