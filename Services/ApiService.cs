﻿using My_movie_manager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace My_movie_manager.Services
{
    public class ApiService
    {
        private static string Baseurl = "http://www.omdbapi.com/?apikey=f8fabbc";

        public static async Task<movieDetails> GetMovieAsync(string action, string actionInput)
        {
            movieDetails singleMovie = new movieDetails();

            Baseurl += "&"+action+"=" + actionInput;

            //Baseurl = _configuration.GetConnectionString("movieApiUrl") + urlUseId + imdbId;

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(Baseurl);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var MovieResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    singleMovie = JsonConvert.DeserializeObject<movieDetails>(MovieResponse);

                }

                return singleMovie;
            }
        }


        public List<string> ListOfMovies()
        {
            var MovieList = new List<string>();
            MovieList.Add("tt0114709");
            MovieList.Add("tt0101414");
            MovieList.Add("");
            MovieList.Add("");
            MovieList.Add("");
            MovieList.Add("");
            MovieList.Add("");
            MovieList.Add("");
            MovieList.Add("");
            MovieList.Add("");

            return MovieList;
        }

    }
}