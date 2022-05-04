using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    int startingHealth;
    
    public int currentHealth;
    NavMeshAgent Agent;
    public GameObject player;
    public GameObject particle;
    public GameObject deathEffect;
    public static EnemyScript instance;
   
    Animator anim;
    AudioSource Audio;

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
        Audio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

        Agent.SetDestination(player.transform.position);
        Agent.stoppingDistance = 5f;
    }
    public void Damage(int damageAmount)
    {

        //Audio.Play();
        // particle.Play();
       GameObject effect= Instantiate(particle, this.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
        Destroy(effect, 1f);
        
        currentHealth -= damageAmount;
        Debug.Log("currenthealth" + currentHealth);
        if (currentHealth<=0)
        {
            // deathEffect.Play();
          GameObject effect_= Instantiate(deathEffect, this.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);

            Destroy(effect_,1f);
            anim.SetBool("Loose", true);
            // Death();
            this.gameObject.SetActive(false);
           
        }
    }
    public void Death()
    {
       // StartCoroutine("DeathAfterSeconds");
       // this.gameObject.SetActive(false);
      }

    IEnumerator DeathAfterSeconds()
    {
        Debug.Log("couroutine called");
        yield return new WaitForSeconds(8f);
    }

  
}
