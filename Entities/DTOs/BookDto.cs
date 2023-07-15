﻿namespace Entities.DTOs
{
    //[Serializable]//serileştirilebilir nesnedir. buna gerek kalmadı property olduğundan
    public record BookDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public decimal? Price { get; init; }
    }

}
