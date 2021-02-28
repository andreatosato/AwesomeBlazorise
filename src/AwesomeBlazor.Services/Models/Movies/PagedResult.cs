using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AwesomeBlazor.Services.Models.Movies
{
    public class PagedResult<T>
    {
        [JsonPropertyName("page")]
        public int? Page { get; set; } = null;
        [JsonPropertyName("results")]
        public List<T> Results { get; set; } = new List<T>();
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
        
        //public void FromSearch<K>(SearchContainer<K> search) where K : class
        //{
        //    Page = search.Page;
        //    TotalPages = search.TotalPages;
        //    TotalResults = search.TotalResults;
        //}
    }
}
