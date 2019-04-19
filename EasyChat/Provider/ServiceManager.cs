using EasyChat.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EasyChat.Provider
{
    public class ServiceManager
    {
        private string Url = "http://192.168.43.118/WebApiMsg/";
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public async Task<IEnumerable<User>> GetAdd(string username, string text,string targetusername)
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "AddMsg/" + username + "/" + text+"/"+ targetusername+"/");
            return JsonConvert.DeserializeObject<IEnumerable<User>>(result.ToString());
        }
        public async  Task<IEnumerable<User>> GetList(string username,string targetname)
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "AddRead/" + username + "/" + targetname + "/");
            return JsonConvert.DeserializeObject<IEnumerable<User>>(result.ToString());
        }
        public async Task<IEnumerable<User>> UserList()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "UserList");
            return JsonConvert.DeserializeObject<IEnumerable<User>>(result.ToString());
        }
    }
}
