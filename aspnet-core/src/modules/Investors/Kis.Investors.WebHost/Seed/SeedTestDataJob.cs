using System;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Hangfire;
using JetBrains.Annotations;
using Kis.Investors.WebHost.Seed;

/// <summary>
/// Тестовая фоновая работа для планировщика
/// </summary>
public class SeedTestDataJob : BackgroundJob<int>, ITransientDependency
{
    private readonly SeedHelper _seedHelper;

    public SeedTestDataJob([NotNull] SeedHelper seedHelper)
    {
        _seedHelper = seedHelper ?? throw new ArgumentNullException(nameof(seedHelper));
    }

    public override void Execute(int id)
    {
        _seedHelper.SeedDb();
    }
}