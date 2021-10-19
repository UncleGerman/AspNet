using System;
using System.Collections.Generic;

namespace Task.Models
{
    public class Location
    {
        public int location_code { get; set; }
        public string location_name { get; set; }
        public int location_code_parent { get; set; }
        public string country_iso_code { get; set; }
        public string location_type { get; set; }
        public string geo_name { get; set; }
        public string geo_id { get; set; }
    }

    public class TasksLocationGoogle
    {
        public string id { get; set; }
        public int status_code { get; set; }
        public string status_message { get; set; }
        public DateTimeOffset time { get; set; }
        public int cost { get; set; }
        public int result_count { get; set; }
        public IList<string> path { get; set; }
        public IList<string> data { get; set; }
        public Dictionary<string, Location> result { get; set; }
    }
}
