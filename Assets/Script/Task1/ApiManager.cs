using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
namespace Task1Sunbase
{
    public class ApiManager : MonoBehaviour
    {
        private static ApiManager apiManager;
       // string contentType = "application/json";

        public static ApiManager Instance
        {
            get { return apiManager; }
        }
        private void Start()
        {

            if (apiManager != null && apiManager == this)
            {
                Destroy(apiManager);
            }
            else
            {
                apiManager = this;
            }

        }
        public void GetData<T>(string Url, Action<T> callback, string parm = " ")
        {
            StartCoroutine(GetDataDownload(Url, callback, parm));
        }
        private IEnumerator GetDataDownload<T>(string url, Action<T> callback, string parm = " ")
        {
            Debug.Log("1" + parm);
            url = url + parm;
            var www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(www.result);
                Debug.Log("Success " + www.downloadHandler.text);
                T data = JsonConvert.DeserializeObject<T>(www.downloadHandler.text);
                www.Dispose();
                callback(data);
            }
            else
            {
                Debug.Log(www.error);
                Debug.Log("Failed " + www.downloadHandler.text);
            }
        }
    }
}



