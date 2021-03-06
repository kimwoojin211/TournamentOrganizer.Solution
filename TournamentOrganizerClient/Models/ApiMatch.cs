
using System.Threading.Tasks;
using RestSharp;

namespace TournamentOrganizerClient.Models
{
  class ApiMatch
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"matches", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"matches/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newShop)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"matches", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newShop);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newMatch)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"matches/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMatch);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"matches/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> GetMatchUsers(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"users/?matchId={id}", Method.GET);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}

