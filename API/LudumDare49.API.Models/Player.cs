using System;
using System.ComponentModel.DataAnnotations;

namespace LudumDare49.API.Models
{
    public class Player
    {
        [Key]
        public string Id { get; set; }
    
        [ConcurrencyCheck]
        public int Version { get; set; }
    
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        
        public Profile Profile { get; set; }
    }
}