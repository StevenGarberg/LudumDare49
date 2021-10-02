using System;
using System.ComponentModel.DataAnnotations;

namespace LudumDare49.API.Models
{
    public class BaseResource
    {
        [Key]
        public string Id { get; set; }
        
        public string OwnerId { get; set; }
    
        [ConcurrencyCheck]
        public int Version { get; set; }
    
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}