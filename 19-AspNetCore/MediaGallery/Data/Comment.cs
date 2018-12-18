using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MediaGallery.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public MediaItem Mediaitem { get; set; }
        public IdentityUser User { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}
