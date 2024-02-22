using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class PlayerRepository : IPlayerRepository
{
    private readonly DefaultDbContext _dbContext;

    public PlayerRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Player entity)
    {
        Player? Player = await Get(entity.IdPlayer);

        if (Player != null) 
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Clan)}> and Id <{entity.IdPlayer}> already exists");
        }

        _dbContext.Players.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Player?> Get(Guid Id)
    {
        Player? Player = await _dbContext.Players.Where(player => player.IdPlayer == Id).FirstOrDefaultAsync();
        return Player;
    }

    public Task<IQueryable<Player>> GetAll()
    {
        return Task.FromResult(_dbContext.Players.AsQueryable());
    }

    public Task Update(Player entity)
    {
        throw new NotImplementedException();
    }
}