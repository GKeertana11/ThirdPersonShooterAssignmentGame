using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    // private static ObjectPoolScript instance;
    public static GameManager instance;
    public GameObject prefab;
   // public GameObject[] zombieePrefabs;
   // public int number;
    public float spawnRadius;
    bool spawnOnStart = true;


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

       // AddToPool();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddToPool()
    {

        /*for (int i = 0; i < 10; i++)
        {

            GameObject temp = Instantiate(prefab);
            temp.SetActive(false);
            Enemypool.Add(temp);

        }*/
        for (int i = 0; i < 10; i++)
        {

            Vector3 randompoint = transform.position + Random.insideUnitSphere * spawnRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randompoint, out hit, 10f, NavMesh.AllAreas))
            {
                //int k = Random.Range(0, zombieePrefabs.Length);
                GameObject temp = Instantiate(prefab, randompoint, Quaternion.identity);
                temp.SetActive(false);
                Enemypool.Add(temp);
                //Instantiate(zombieePrefabs[1], randompoint, Quaternion.identity);

            }
            else
            {
                i--;
            }

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








