
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpawnScript : MonoBehaviour
{
    Vector3 spawnPosition;
    public SphereCollider spawnTrigger;
    bool istrigger=false;
    // Start is called before the first frame update
    void Start()
    {
        spawnTrigger = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = GameManager.instance.GetObjectsFromPool("Enemy");
        if (temp != null&&istrigger==true)
        {
            Debug.Log("true");
            if (Random.Range(0, 100) < 1f)
            {
                spawnPosition = new Vector3(Random.insideUnitSphere.x * spawnTrigger.radius,
                1, Random.insideUnitSphere.z * spawnTrigger.radius);

                // temp.transform.position = temp.transform.position + new Vector3(Random.Range(99f, 179f), 1f, Random.Range(-f, -4f));
                temp.transform.position = temp.transform.position+new Vector3((Random.value * 2 - 1) * spawnTrigger.radius,
             1,
             (Random.value * 2 - 1) * spawnTrigger.radius);
                temp.SetActive(true);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            istrigger = true;
        }
    }

}

 
    
