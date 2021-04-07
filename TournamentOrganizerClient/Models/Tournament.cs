using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TournamentOrganizer.Models
{
  public class Tournament
  {
    public Tournament()
    {
      this.Matches = new HashSet<Match>();
      this.TournamentUsers = new HashSet<TournamentUser>();
      // this.Moderators = new HashSet<User>();
    }
    public int TournamentId { get; set; }
    public string Name { get; set; }
    public string OrganizedBy { get; set; }
    public string Location { get; set; }
    public DateTime Time { get; set; }

    public string Category { get; set; }
    public ICollection<Match> Matches { get; set; }
    public virtual ICollection<TournamentUser> TournamentUsers { get; set; }
    // public virtual ICollection<User> Moderators { get; set; }
    // public virtual Bracket Bracket { get; set; }
    // public string Standings { get; set; }

    public static List<Tournament> GetTournaments()
    {
      var apiCalltask = ApiHelper.GetAllTournaments();
      var result = apiCalltask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Tournament> tournamentList = JsonConvert.DeserializeObject<List<Tournament>>(jsonResponse.ToString());

      return tournamentList;
    }

    public static Tournament GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetTournament(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Tournament tournament = JsonConvert.DeserializeObject<Tournament>(jsonResponse.ToString());

      return tournament;
    }

     public static void Post(Tournament tournament)
    {
      string jsonTournament = JsonConvert.SerializeObject(place);
      var apiCallTask = ApiHelper.PostPlace(jsonTournament);
    }

    public static void Put(Tournament tournament)
    {
      string jsonTournament = JsonConvert.SerializeObject(place);
      var appiCallTask = ApiHelper.PutTournament(tournament.TournamentId, jsonTournament);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteTournament(id);
    }

  }
}


