using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Animator animator;
    public GameObject target;
    public float stoppingDistance;
    public enum STATE { IDLE, CHASE, ATTACK, DEATH }
    public STATE state = STATE.IDLE;

    public float currentTime;
    public float attackTime;
    bool isGameOver = false;
    public PlayerMovement player;
    public Slider healthBar;
    int count = 0;
  
    AudioClip audioClip;
    public float time;
    public GameObject ragdoll;
    public Text gameover;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = target.GetComponent<PlayerMovement>();
      


        audioClip = GetComponent<AudioClip>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null&&isGameOver==false)
        {
            switch (state)
            {
                case STATE.IDLE:
                    TurnOffAllAnim();
                    agent.isStopped = true;
                    if (NearPlayer())
                    {
                        state = STATE.CHASE;
                    }
                    break;
                case STATE.CHASE:
                    TurnOffAllAnim();
                    animator.SetBool("RUN", true);
                    
                    transform.LookAt(target.transform.position);

                    agent.SetDestination(target.transform.position);
                    agent.stoppingDistance = 5f;
                    print("running");
                    if (DistanceToPlayer() <= 5f)
                    {
                        state = STATE.ATTACK;
                    }




                    if (DistanceToPlayer() > 20f)
                    {
                        state = STATE.IDLE;
                        agent.isStopped = true;
                    }
                    break;

                case STATE.ATTACK:
                    TurnOffAllAnim();
                    transform.LookAt(target.transform.position);
                    animator.SetBool("ATTACK", true);
                    time = time + Time.deltaTime;
                    if (player != null)
                    {
                        if (time >= 3f)
                        {
                            player.health--;
                            player.health--;
                            healthBar.value = (float)player.health / 100;

                            Debug.Log(player.health);
                            time = 0f;

                        }

                        if (player.health <= 0)
                        {
                                isGameOver = true;

                            //Ragdoll();

                            //target.SetActive(false);
                            gameover.GetComponent<Text>().enabled = true;
                           
                             TurnOffAllAnim();

                        }
                    }


                    if (DistanceToPlayer() > 20f)
                    {
                        state = STATE.IDLE;

                    }
                    
                    if (DistanceToPlayer() >= 10f )
                    {
                        state = STATE.CHASE;
                        agent.isStopped = false;
                    }
                    break;

                case STATE.DEATH:
                    TurnOffAllAnim();
                    
                    break;
                default:
                    break;
            }

        }
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(target.transform.position, agent.transform.position);
    }

    public bool NearPlayer()
    {
        if (DistanceToPlayer() < 10f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void EnemyDead()
    {

        state = STATE.DEATH;
    }
    public void TurnOffAllAnim()
    {
      
        animator.SetBool("RUN", false);
        animator.SetBool("ATTACK", false);
    }
    public void Ragdoll()
    {
        if (isGameOver == true)
        {
            Instantiate(ragdoll, target.transform.position, Quaternion.identity);
        }
    }

  

    
}

