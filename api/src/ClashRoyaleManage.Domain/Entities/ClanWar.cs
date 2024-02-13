using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace  ClashRoyaleManager.Domain.Entities;

public class ClanWar
{
    //TODO - Keys [IdWar, IdClan]
    public Guid IdWar { get; set; }
    public Guid IdClan { get; set; }
    public int NumberOfPrizes { get; set; }

    public virtual War war { get; set; }
    public virtual Clan clan { get; set; }  
}