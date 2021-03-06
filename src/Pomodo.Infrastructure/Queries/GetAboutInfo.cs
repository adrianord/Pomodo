using JetBrains.Annotations;
using MediatR;
using Pomodo.Infrastructure.Helpers;

namespace Pomodo.Infrastructure.Queries;

public static class GetAboutInfo
{
    public record Query : IRequest<AboutInfo>;


    [UsedImplicitly]
    public class Handler : IRequestHandler<Query, AboutInfo>
    {
        private readonly IAboutInfoHelper _aboutInfoHelper;

        public Handler(IAboutInfoHelper aboutInfoHelper)
        {
            _aboutInfoHelper = aboutInfoHelper;
        }

        public Task<AboutInfo> Handle(Query request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_aboutInfoHelper.GetAboutInfo());
        }
    }
}