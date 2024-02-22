using ClashRoyaleManager.Application.Query.Players;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints.Player;

public class GetAllEndpoint : EndpointWithoutRequest<ListPlayerQueryResponse>
{
    public override void Configure()
    {
        Get("/api/players");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        ListPlayerQuery req = new ListPlayerQuery();
        ListPlayerQueryResponse list = await req.ExecuteAsync(ct);

        await SendAsync(list);
    }
}