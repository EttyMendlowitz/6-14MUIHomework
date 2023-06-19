using System.Text.Json.Serialization;

namespace _6_14MUIHomework.Data
{
    public class Income
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int SourceId { get; set; }

        [JsonIgnore]
        public Source Source { get; set; }
    }
}