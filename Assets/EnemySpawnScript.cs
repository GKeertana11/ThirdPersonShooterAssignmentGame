
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpawnScript : MonoBehaviour
{
    Vector3 spawnPosition;
   // public SphereCollider spawnTrigger;
    bool istrigger=false;
  //  public TargetJoint2D player;
    public GameObject target;
    public GameObject spawnpoint;
    public float spawnRadius;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = GameManager.instance.GetObjectsFromPool();//getting enemy from the enemy pool.
      
        if (temp != null)
        {
            Debug.Log("true");
            if (Random.Range(0, 100) < 2f)
            {
                temp.SetActive(true);//making enemy prefabs active in the game window.
             }
             }
        }

    }
  
   


 
    
