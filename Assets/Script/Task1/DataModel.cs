using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
namespace Task1Sunbase
{
    [Serializable]
    public class DataModel
    {
        // Start is called before the first frame update
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private GameObject item;
        [SerializeField] private GameObject content;
        [SerializeField] private List<GameObject> clientsGameObject;
        [SerializeField] private GameObject data;

        public TMP_Dropdown Dropdown
        {
            get { return dropdown; }
        }
        public GameObject Item
        {
            get { return item; }
        }
        public GameObject Content
        {
            get { return content; }
        }

        public List<GameObject> ClientsGameObject
        {
            get { return clientsGameObject; }
        }
        public GameObject Data
        {
            get { return data; }
        }

    }
}
