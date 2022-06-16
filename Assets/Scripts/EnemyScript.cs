using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    public AudioSource[] audios;
    PlayerMovement playerMoment;

   
    Animator anim;
    AudioSource Audio;
   

    private void Awake()//single ton
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
        playerMoment = GetComponent<PlayerMovement>();
        Audio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Agent.SetDestination(player.transform.position);//setting player as goal point for enemy (or) To make enemy follow player.
                                                            // Agent.stoppingDistance = 5f;//enemy should stop this distance.
        }
    }
    public void Damage(int damageAmount)//This method is to decrease enemy health as player shoots enemy.
    {

        
       GameObject effect= Instantiate(particle, this.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);//particle effects when enemy gets damaged.
        Destroy(effect, 1f);
        PlayerAudioSource.instance.EnemyHit();
      
        currentHealth -= damageAmount;
        Debug.Log("currenthealth" + currentHealth);
        if (currentHealth<=0)
        {
            
          GameObject effect_= Instantiate(deathEffect, this.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);//particle effect when enemy dies.

            Destroy(effect_,1f);
            anim.SetBool("Loose", true);
           // GameObject temp = this.gameObject;
            currentHealth = startingHealth;
            


         this.gameObject.SetActive(false);//As enemy dies sending enemy back to pool and making them false.
            //GameManager.instance.Enemypool.Add(temp);
           
           
        }
    }
  

 

  
}
