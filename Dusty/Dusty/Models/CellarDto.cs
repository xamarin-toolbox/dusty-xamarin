using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusty.Models
{
    [JsonObject]
    public class CellarDto
    {
        [JsonProperty("id")]            public string Id { get; set; }
        [JsonProperty("beerId")]        public string BeerId { get; set; }
        [JsonProperty("userId")]        public string UserId { get; set; }
        [JsonProperty("dateProduced")]  public DateTime? DateProduced { get; set; }
        [JsonProperty("dateExpires")]   public DateTime? DateExpires { get; set; }
        [JsonProperty("dateAdded")]     public DateTime? DateAdded { get; set; }
        [JsonProperty("dateRemoved")]   public DateTime? DateRemoved { get; set; }
        [JsonProperty("removalReason")] public string RemovalReason { get; set; }
        [JsonProperty("containerType")] public string ContainerType { get; set; }
        [JsonProperty("containerSize")] public string ContainerSize { get; set; }
        [JsonProperty("vintage")]       public string Vintage { get; set; }
        [JsonProperty("notes")]         public string Notes { get; set; }
        [JsonProperty("location")]      public string Location { get; set; }
        [JsonProperty("beer")]          public BeerDto Beer { get; set; }

        public class BeerDto
        {
            [JsonProperty("id")]          public string Id { get; set; }
            [JsonProperty("name")]        public string Name { get; set; }
            [JsonProperty("breweryName")] public string BreweryName { get; set; }
            [JsonProperty("styleName")]   public string StyleName { get; set; }
            [JsonProperty("description")] public string Description { get; set; }
            [JsonProperty("abv")]         public float? Abv { get; set; }
            [JsonProperty("ratebeer")]    public RateBeerDto RateBeer { get; set; }
        }

        public class RateBeerDto
        {
            [JsonProperty("id")]                public int? Id { get; set; }
            [JsonProperty("aliasOfId")]         public int? AliasOfId { get; set; }
            [JsonProperty("name")]              public string Name { get; set; }
            [JsonProperty("breweryName")]       public string BreweryName { get; set; }
            [JsonProperty("breweryId")]         public int? BreweryId { get; set; }
            [JsonProperty("styleName")]         public string StyleName { get; set; }
            [JsonProperty("styleId")]           public int? StyleId { get; set; }
            [JsonProperty("description")]       public string Description { get; set; }
            [JsonProperty("abv")]               public float? Abv { get; set; }
            [JsonProperty("numRatings")]        public int? NumRatings { get; set; }
            [JsonProperty("score")]             public int? Score { get; set; }
            [JsonProperty("scoreStyle")]        public int? ScoreStyle { get; set; }
            [JsonProperty("calories")]          public int? Calories { get; set; }
            [JsonProperty("ratingMean")]        public float? RatingMean { get; set; }
            [JsonProperty("ratingWeightedAvg")] public float? RatingWeightedAvg { get; set; }
        }
    }
}
