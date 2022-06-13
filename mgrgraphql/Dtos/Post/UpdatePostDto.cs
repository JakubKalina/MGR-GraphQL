using System;

namespace mgrapi.Dtos.Post
{
    public class UpdatePostDto
    {
        public DateTime CreationDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}