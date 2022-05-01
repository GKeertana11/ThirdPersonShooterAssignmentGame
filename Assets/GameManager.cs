using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // private static ObjectPoolScript instance;
    public static GameManager instance;
    public GameObject prefab;


    public List<GameObject> Enemypool = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        return;
    }


    // Start is called before the first frame update
    void Start()
    {

        AddToPool();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddToPool()
    {

        for (int i = 0; i < 10; i++)
        {

            GameObject temp = Instantiate(prefab);
            temp.SetActive(false);
            Enemypool.Add(temp);

        }
    }



    public GameObject GetObjectsFromPool(string tagname)
    {
        for (int i = 0; i < Enemypool.Count; i++)
        {
            if ( !Enemypool[i].gameObject.activeInHierarchy)
            {
                return Enemypool[i].gameObject;
            }
        }
        return null;

    }
}








