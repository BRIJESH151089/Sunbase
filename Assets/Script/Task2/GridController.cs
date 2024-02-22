
using UnityEngine;
public class GridController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject prefab;
    public float gridX = 4f;
    public float gridY = 4f;
    public float spacing = 2f;
    void Start()
    {
       
        for (int y = 0; y < gridY; y++)
        {
            
            for (int x = 0; x < gridX; x++)
            {
                Vector3 pos = new Vector3(x, y, 0) * spacing;

               GameObject go= Instantiate(prefab, pos, Quaternion.identity);
             
            }
        }

    }

   
    
    }

