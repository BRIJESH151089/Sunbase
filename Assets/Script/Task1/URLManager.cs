using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Task1Sunbase
{
    public class URLManager : MonoBehaviour
    {
        private static URLManager urlManager;
        [SerializeField] private string baseUrel;

        public string BaseURL
        {
            get { return baseUrel; }
        }


        public static URLManager Instance
        {
            get { return urlManager; }
        }
        private void Awake()
        {
            if (urlManager != null && urlManager == this)
            {
                Destroy(urlManager);
            }
            else
            {
                urlManager = this;
            }
        }
    }
}
