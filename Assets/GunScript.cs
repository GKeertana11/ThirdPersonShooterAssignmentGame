using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 1.5f)]
    float fireRate = 1.0f;
    [Range(1f, 10f)]
    float damageRate = 1.0f;
    float timer;
    public Transform spawnPoint;
    public Vector3 offset;

    public static GunScript instance;
    Animator anim;
    public ParticleSystem particle;
    public GameObject prefab;

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
      
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer>=fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                timer = 0f;
                ToFireGun();
            }
        }
    }
    private void ToFireGun()
    {
       
        anim.SetFloat("speed", 0);
        PlayerAudioSource.instance.ShotFire();
        anim.SetTrigger("Shoot");//Shoot animation is trigerred.

        GameObject effect = Instantiate(prefab, spawnPoint.transform.position , Quaternion.identity) ;//Particle effect while shooting.
        Destroy(effect,1f);

   
        Debug.DrawRay(spawnPoint.transform.position+offset, transform.forward * 100, Color.red,2f);
        Ray ray = new Ray(spawnPoint.position, transform.forward);
        RaycastHit HitInfo;
        if(Physics.Raycast(ray,out HitInfo,100f))//checking if ray hit any collider
        {
          
            
           var health= HitInfo.collider.GetComponent<EnemyScript>();//if ray hits enemy getting enemy script to decrese health of enemy.
            if(health!=null)
            {
                health.Damage(5);//calling damage method decrese health when player shoots enemy.
            }

        }

       
    }
   
}
