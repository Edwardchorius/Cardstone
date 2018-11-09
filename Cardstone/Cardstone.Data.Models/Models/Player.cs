using Cardstone.Data.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardstone.Data.Models
{
    public class Player : IdentityUser,IAuditable, IDeletable
    {
        public string AvatarImageName { get; set; }

        public int Health { get; set; }

        public int XP { get; set; }

        public int Coins { get; set; }           

        public int Level { get; set; }

        public int LeaderboardRank { get; set; }

        public ICollection<PlayersCards> PlayersCards { get; set; }

        public ICollection<Combat> WonCombats { get; set; }

        public ICollection<Combat> LostCombats { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}
