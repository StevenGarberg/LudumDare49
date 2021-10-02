using System.ComponentModel.DataAnnotations;

namespace LudumDare49.API.Models.Requests
{
    public class PlayerCreateRequest
    {
        [Required]
        public string DeviceId { get; set; }
        public string DisplayName { get; set; }
    }
}