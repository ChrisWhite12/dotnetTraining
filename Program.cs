using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
// See https://aka.ms/new-console-template for more information

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
      IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true, true)
        .Build();

      DataContextDapper dapper = new DataContextDapper(config);
      // DataContextEF entityFramework = new DataContextEF();


      // string sqlCommand = "SELECT GETDATE()";

      // DateTime now = dapper.LoadDataSingle<DateTime>(sqlCommand);

      // Computer myComputer = new Computer()
      // {
      //   Motherboard = "MB1",
      //   CpuCores = 4,
      //   HasLTE = false,
      //   HasWiFi = true,
      //   Release = DateTime.Now,
      //   Price = 1123.12m,
      //   VideoCard = "RX590"
      // };

      // entityFramework.Add(myComputer);
      // entityFramework.SaveChanges();



      // File.WriteAllText("log.txt", sql + "\n");

      // using StreamWriter file = new StreamWriter("log2.txt", append: true);
      // file.WriteLine(sql);
      // file.Close();

      // Console.WriteLine(File.ReadAllText("log2.txt"));
      string computersText = File.ReadAllText("ComputersSnake.json");

      // JsonSerializerOptions options = new JsonSerializerOptions
      // {
      //   PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      // };

      IEnumerable<Computer>? computers = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersText);



      // IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersText);

      if (computers != null)
      {
        foreach (Computer computer in computers)
        {
          string sql = @"INSERT INTO TutorialAppSchema.Computer (
            Motherboard,
            HasLTE,
            HasWiFi,
            Release,
            Price,
            VideoCard,
            CpuCores
          ) VALUES ('" + EscapeSingleQuotes(computer.Motherboard)
                 + "','" + computer.HasLTE
                 + "','" + computer.HasWiFi
                 + "','" + computer.Release?.ToString("yyyy-MM-dd")
                 + "','" + computer.Price
                 + "','" + EscapeSingleQuotes(computer.VideoCard)
                 + "','" + computer.CpuCores
            + "')";

          dapper.ExecuteSql(sql);
        }
      }

      // JsonSerializerSettings settings = new JsonSerializerSettings()
      // {
      //   ContractResolver = new CamelCasePropertyNamesContractResolver()
      // };

      // string computersCopy = JsonConvert.SerializeObject(computers, settings);
      // File.WriteAllText("ComputersCopy.json", computersCopy);
    }

    static string EscapeSingleQuotes(string? input)
    {
      if (input == null)
      {
        return "";
      }
      string output = input.Replace("'", "''");
      return output;
    }
  }
}
