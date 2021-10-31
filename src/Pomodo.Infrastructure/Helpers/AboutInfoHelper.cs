using Pomodo.Common.Constants;

namespace Pomodo.Infrastructure.Helpers;

public record AboutInfo
{
    public string Application { get; init; }

    public DateTime UpSince { get; init; }

    public string UpFor { get; init; }

    public string? ReleaseCommit { get; init; } = null;

    public string? ReleaseTag { get; init; } = null;
}

public interface IAboutInfoHelper
{
    AboutInfo GetAboutInfo();
}

public class AboutInfoHelper : IAboutInfoHelper
{
    private readonly DateTime _startDateTimeUtc;

    public AboutInfoHelper()
    {
        _startDateTimeUtc = DateTime.UtcNow;
    }

    public AboutInfo GetAboutInfo() => new()
    {
        Application = ApplicationInfo.FullName,
        UpSince = _startDateTimeUtc,
        UpFor = GetUpForDetails()
    };

    private string GetUpForDetails()
    {
        var upSpan = DateTime.UtcNow - _startDateTimeUtc;
        return $"{upSpan.Days} days, {upSpan.Hours} Hours, {upSpan.Minutes} minutes, {upSpan.Seconds} seconds, {upSpan.Milliseconds} milliseconds";
    }
}