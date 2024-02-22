
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
namespace Task1Sunbase
{
    public class DataHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] DataModel dataModel;
        [SerializeField] ClientsDetails clientsDetails;
        void Start()
        {
            Invoke("GetDataFromServer", 2f);
            dataModel.Dropdown.onValueChanged.AddListener(PopulateLabelitem);
            Invoke("PopulateLabelitemFirstTime", 4f);


        }

        void GetDataFromServer()
        {

            string par = "";
            ApiManager.Instance.GetData<ClientsDetails>(URLManager.Instance.BaseURL, (data) => { clientsDetails = data; }, par);

        }

        public void PopulateLabelitemFirstTime()
        {

            foreach (var go in clientsDetails.clients)

            {
                GameObject item = Instantiate(dataModel.Item, dataModel.Content.transform);
                item.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = go.label;
                item.GetComponent<Button>().onClick.AddListener(delegate ()

                {
                    PopupWindow(go.id);
                });
                dataModel.ClientsGameObject.Add(item);
            }





        }

        public void PopulateLabelitem(int selected)
        {
            foreach (var go in dataModel.ClientsGameObject)

            {

                Destroy(go);

            }

            dataModel.ClientsGameObject.Clear();
            if (selected == 1)
            {

                foreach (var go in clientsDetails.clients)

                {
                    if (go.isManager)

                    {
                        GameObject item = Instantiate(dataModel.Item, dataModel.Content.transform);
                        item.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = go.label;
                        item.GetComponent<Button>().onClick.AddListener(delegate ()

                        {
                            PopupWindow(go.id);
                        });
                        dataModel.ClientsGameObject.Add(item);
                    }
                }

            }
            else if (selected == 2)
            {

                foreach (var go in clientsDetails.clients)

                {
                    if (!go.isManager)

                    {
                        GameObject item = Instantiate(dataModel.Item, dataModel.Content.transform);
                        item.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = go.label;
                        item.GetComponent<Button>().onClick.AddListener(delegate ()

                        {
                            PopupWindow(go.id);
                        });
                        dataModel.ClientsGameObject.Add(item);
                    }
                }

            }
            else
            {
                foreach (var go in clientsDetails.clients)

                {
                    GameObject item = Instantiate(dataModel.Item, dataModel.Content.transform);
                    item.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = go.label;
                    item.GetComponent<Button>().onClick.AddListener(delegate ()

                    {
                        PopupWindow(go.id);
                    });
                    dataModel.ClientsGameObject.Add(item);
                }

            }

        }

        void PopupWindow(int id)
        {
            dataModel.Data.transform.DOScale(Vector3.zero, 0f);
            dataModel.Data.transform.DOScale(Vector3.one, 2f);


            if (id == 1)
            {
                dataModel.Data.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._1.address;
                dataModel.Data.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._1.name;
                dataModel.Data.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._1.points.ToString();
            }
            else if (id == 2)
            {
                dataModel.Data.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._2.address;
                dataModel.Data.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._2.name;
                dataModel.Data.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._2.points.ToString();
            }
            else if (id == 3)
            {
                dataModel.Data.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._3.address;
                dataModel.Data.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._3.name;
                dataModel.Data.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = clientsDetails.data._3.points.ToString();
            }
            else
            {
                dataModel.Data.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
                dataModel.Data.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "";
                dataModel.Data.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }
}
