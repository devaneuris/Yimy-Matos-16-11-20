using BertoniLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BertoniLibrary.Contracts
{
    public class ServiceTypeImpl : IServiceType {

        private HttpClient Request { get; }

        public ServiceTypeImpl(HttpClient httpClient) 
        {
            httpClient.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
            Request = httpClient;
        }

        public async Task<IList<Album>> Albums()
        {
            HttpResponseMessage response = await RequestAsync("/albums");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            IList<Album> albums = JsonConvert.DeserializeObject<List<Album>>(jsonResponse);

            return albums;
        }

        public async Task<IList<Photo>> Photos(int id) {

            HttpResponseMessage response = await RequestAsync("/photos");
           
            var jsonResponse = await response.Content.ReadAsStringAsync();
            
            IList<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(jsonResponse)
                .Where(photo => photo.AlbumId == id)
                .ToList();

            return photos;
        }

        public async Task<IList<Comment>> Comments(int id) {

            HttpResponseMessage response = await RequestAsync("/comments");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            IList<Comment> comments = JsonConvert.DeserializeObject<List<Comment>>(jsonResponse)
                .Where(comment => comment.PostId == id)
                .ToList();

            return comments;
        }

        private async Task<HttpResponseMessage> RequestAsync(string path)
        {
            return await Request.GetAsync(path);
        }
    }
}