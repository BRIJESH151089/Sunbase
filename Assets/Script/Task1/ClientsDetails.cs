
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Task1Sunbase
{
    [System.Serializable]
    public class _1
    {
        public string address;
        public string name;
        public int points;
    }
    [System.Serializable]
    public class _2
    {
        public string address;
        public string name;
        public int points;
    }
    [System.Serializable]
    public class _3
    {
        public string address;
        public string name;
        public int points;
    }
    [System.Serializable]
    public class Client
    {
        public bool isManager;
        public int id;
        public string label;
    }
    [System.Serializable]
    public class Data
    {
        [JsonProperty("1")]
        public _1 _1;

        [JsonProperty("2")]
        public _2 _2;

        [JsonProperty("3")]
        public _3 _3;
    }
    [System.Serializable]
    public class ClientsDetails
    {
        public List<Client> clients;
        public Data data;
        public string label;
    }




}
