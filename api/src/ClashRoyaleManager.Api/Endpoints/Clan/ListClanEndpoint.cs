using ClashRoyaleManager.Application.Query.Clans;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints.Clan;

public class GetAllEndpoint : EndpointWithoutRequest<ListClanQueryResponse>
{
    public override void Configure()
    {
        Get("/api/clans");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        ListClanQuery req = new ListClanQuery();
        ListClanQueryResponse list = await req.ExecuteAsync(ct);

        await SendAsync(list);
    }
}