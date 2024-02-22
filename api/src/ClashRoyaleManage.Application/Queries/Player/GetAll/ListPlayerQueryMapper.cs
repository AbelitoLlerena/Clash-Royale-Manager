using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Players;

public class ListPlayerQueryMapper : AbstractMapper<IQueryable<Player>, ListPlayerQuery, ListPlayerQueryResponse>
{
    public override ListPlayerQueryResponse ToResponse(IQueryable<Player> entities)
    {
        return new ListPlayerQueryResponse {
            Players = entities.GetEnumerator()
        };
    }
}