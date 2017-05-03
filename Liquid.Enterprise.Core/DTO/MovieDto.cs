using System;

namespace Liquid.Enterprise.DTO
{
    public class MovieDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
    }
}