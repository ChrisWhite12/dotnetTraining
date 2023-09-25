using System.Text.Json.Serialization;

namespace HelloWorld.Models
{
  public class Computer
  {
    [JsonPropertyName("computer_id")]
    public int ComputerId { get; set; }
    [JsonPropertyName("motherboard")]

    public string? Motherboard { get; set; } = "";
    [JsonPropertyName("cpu_cores")]
    public int? CpuCores { get; set; } = 0;
    [JsonPropertyName("has_wifi")]
    public bool HasWiFi { get; set; }
    [JsonPropertyName("has_lte")]
    public bool HasLTE { get; set; }
    [JsonPropertyName("release_date")]
    public DateTime? Release { get; set; } = DateTime.Now;
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    [JsonPropertyName("video_card")]
    public string? VideoCard { get; set; } = "test";
    // public Computer()
    // {
    //   if (VideoCard == null)
    //   {
    //     VideoCard = "test";
    //   }
    //   if (Motherboard == null)
    //   {
    //     Motherboard = "";
    //   }
    // }
  }

}