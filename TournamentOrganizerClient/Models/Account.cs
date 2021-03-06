using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace TournamentOrganizerClient.Models
{
  public class Account
  {
    public Account()
    {
      this.Tournaments = new List<Tournament>();
      this.Matches = new List<Match>();
    }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Region { get; set; }
    public string Token { get; set; }

    // maybe make list of ints to store joinId #'s?
    public List<Tournament> Tournaments { get; set; }
    public List<Match> Matches { get; set; }

    public static List<Account> GetAccounts()
    {
      var apiCalltask = ApiAccount.GetAll();
      var result = apiCalltask.Result;
      List<Account> accountList = new List<Account>();

      if(result!=null && result.Length != 0)
      {
        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        accountList = JsonConvert.DeserializeObject<List<Account>>(jsonResponse.ToString());
      }
      return accountList;
    }

    public static Account GetDetails(int id)
    {
      var apiCallTask = ApiAccount.Get(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Account account = JsonConvert.DeserializeObject<Account>(jsonResponse.ToString());
      return account;
    }

    public static bool Register(string username, string password, string email)
    {
      var apiCallTask = ApiAccount.Register(username, password, email);
      var result = apiCallTask.Result;
      return result.Contains("userId");

    }
    public static Account Login(string username, string password)
    {
      var apiCallTask = ApiAccount.Login(username, password);
      var result = apiCallTask.Result;
      if(result.Contains("userId"))
      {
        System.Console.WriteLine("Result! " + result);
        JObject jsonResponse = JsonConvert
          .DeserializeObject<JObject>(result);
        Account account = JsonConvert.DeserializeObject<Account>(jsonResponse.ToString());
        return account;
      }
      else
      {
        return null;
      }
    }
    public static void Put(int id,Account account)
    {
      string jsonAccount = JsonConvert.SerializeObject(account);
      var apiCallTask = ApiAccount.Put(id, jsonAccount);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiAccount.Delete(id);
    }

    public static List<Tournament> GetUserTournaments(int userId)
    {
      var apiCalltask = ApiAccount.GetUserTournaments(userId);
      var result = apiCalltask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Tournament> tournamentList = JsonConvert.DeserializeObject<List<Tournament>>(jsonResponse.ToString());

      return tournamentList;
    }
        
    public static List<Match> GetUserMatches(int userId)
    {
      var apiCalltask = ApiAccount.GetUserMatches(userId);
      var result = apiCalltask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Match> matchList = JsonConvert.DeserializeObject<List<Match>>(jsonResponse.ToString());

      return matchList;
    }

  }
}