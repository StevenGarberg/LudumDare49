using System;

namespace DefaultNamespace.Models
{
    public class MatchResults
    {
        public int Id { get; set; }
        public string WinnerId { get; set; }
        public string LoserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}