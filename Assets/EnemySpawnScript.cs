
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
        //IfPlayer();
       // spawnTrigger = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = GameManager.instance.GetObjectsFromPool();
       // Debug.Log(Vector3.Distance(target.transform.position, this.transform.position));
        if (temp != null)
        {
            Debug.Log("true");
            if (Random.Range(0, 100) < 60f)
            {
               

                    
                    temp.SetActive(true);


                }
                   

                    
            }
        }

    }
   /* private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            //istrigger = true;
            GameManager.instance.AddToPool();
        }
    }*/

  /*  public void IfPlayer()
    {
        
      if(Vector3.Distance(target.transform.position, this.transform.position)<=5f)
        {
            Debug.Log("True");
            GameManager.instance.AddToPool();
        }
    }*/
   


 
    
