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
   
    


    public List<GameObject> Enemypool = new List<GameObject>();//creating a list of enemies for object pooling.

    private void Awake()//Single ton
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
    public void AddToPool()//This method is to add all the enemies into enemiespool list.
    {

         for (int i = 0; i < 20; i++)
         {

            
        GameObject temp = Instantiate(prefab);//Instantiating enemy prefabs
               temp.SetActive(false);//making enemy prefabs false in the heirarchy.
                Enemypool.Add(temp);//adding instantiated prefab into the enemy pool list.


        }

        
    }
    



    public GameObject GetObjectsFromPool()//This method is to return enemyprefabs.
    {
        for (int i = 0; i < Enemypool.Count; i++)
        {
            if ( !Enemypool[i].gameObject.activeInHierarchy)// if  enemy prefab[i] is inactive in hierarchy 
            {
                return Enemypool[i].gameObject;//then return this enemy prefab to reuse it.
            }
        }
        return null;//else return null

    }
}








