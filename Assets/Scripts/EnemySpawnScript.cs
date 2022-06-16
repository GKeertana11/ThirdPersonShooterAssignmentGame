
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpawnScript : MonoBehaviour
{
    Vector3 spawnPosition;
    // public SphereCollider spawnTrigger;
    bool istrigger = false;
    //  public TargetJoint2D player;
    public GameObject target;
    public GameObject spawnpoint;
    public float spawnRadius;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        

        for (int i = 0; i < 10; i++)
        {
       
            GameObject temp = GameManager.instance.GetObjectsFromPool();//getting enemy from the enemy pool.
            Debug.Log("true");
            if (temp != null)
            {

                if (Random.Range(0, 100) < 1f)
                {

                    Vector3 randompoint = spawnpoint.transform.position + Random.insideUnitSphere * spawnRadius;//spawn position of enemies inside given sphere radius.
                                                                                                                // randompoint.y = 1f;
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randompoint, out hit, 10f, NavMesh.AllAreas))
                    {
                        Debug.Log(randompoint);

                        temp.transform.position = randompoint;
                        temp.SetActive(true);


                    }

                }
                else
                {
                    i--;
                }
            }
            // temp.SetActive(true);//making enemy prefabs active in the game window.
        }
    }


    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.S))
        {
            SpawnEnemies();
        }
    }
}

    
  
   


 
    
