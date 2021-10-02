using System;
using System.ComponentModel.DataAnnotations;

namespace LudumDare49.API.Models
{
    public class Player : BaseResource
    {
        public string DeviceId { get; set; }
        public string DisplayName { get; set; }
    }
}