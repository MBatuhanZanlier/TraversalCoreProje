﻿namespace TraversalCoreProje.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int Id { get; set; }
        public string city { get; set; }
        public double price { get; set; }
        public int capacity { get; set; } 
        public string daynight { get; set; } 

    }
}
