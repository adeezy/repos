using ArtistService.Domain;
using ArtistService.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArtistService.ApiRepository
{
    public class SpotifyApi
    {
        private readonly Client _client;
        public SpotifyApi(Client client)
        {
            _client = client;
        }

        // get access token from spotifyApi
        public string GetAccessToken()
        {

            SpotifyToken token = new SpotifyToken();
            string url5 = "https://accounts.spotify.com/api/token";
            var clientId = _client.ClientId;
            var clientSecret =_client.ClientSecret;

            //request to get the access token
            var encode_clientId_clientSecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientId, clientSecret)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientId_clientSecret);

            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    //turn string into json and parse for accesstoken
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
                token = JsonConvert.DeserializeObject<SpotifyToken>(json);
            }
            return token.access_token;
        }

        //get artist from SpotifyApi
        public Task<Artist> GetArtist(Artist request, string uri)
        {
            var token = GetAccessToken();
            var artist = new Artist();
            

            using (WebClient webClient = new WebClient())
            {

                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                webClient.Headers[HttpRequestHeader.Accept] = "application/json";
                webClient.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
                webClient.Encoding = Encoding.UTF8;


                string response = webClient.DownloadString(uri);
                var artists = JObject.Parse(response)["artists"];
                var items = artists["items"];
                var artistArray = DeserializeJToken(items);
                artist.ArtistID = artistArray[0].Id;
                artist.ArtistName = artistArray[0].name;

            }

            return Task.FromResult<Artist>(artist);
        }

        //Dezerialize JObject into Array 
        public Items[] DeserializeJToken(JToken jToken)
        {
            var artistArray = jToken.ToObject<Items[]>();

            return artistArray;
        }
        public class Items
        {
            public string name;
            public string Id;
        }

     



    }
}
