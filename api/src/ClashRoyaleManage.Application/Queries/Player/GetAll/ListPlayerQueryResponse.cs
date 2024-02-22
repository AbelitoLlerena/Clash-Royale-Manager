using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Players;

public record ListPlayerQueryResponse
{ 
    public IEnumerator<Player> Players { get; set; } = null!;
}