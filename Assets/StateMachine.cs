using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    //  public AudioSource audioSources;
    AudioClip audioClip;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = target.GetComponent<PlayerMovement>();
        //  audioSources = GetComponent<AudioSource>();


        audioClip = GetComponent<AudioClip>();

    }

    // Update is called once per frame
    void Update()
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
                // audioSources.Play();
                transform.LookAt(target.transform.position);

                agent.SetDestination(target.transform.position);
                agent.stoppingDistance = 5f;
                print("running");
                if (DistanceToPlayer() <= 5f)
                {
                    state = STATE.ATTACK;
                }




                if (DistanceToPlayer() > 30f)
                {
                    state = STATE.IDLE;
                    agent.isStopped = true;
                }
                break;
            case STATE.ATTACK:
                TurnOffAllAnim();
                transform.LookAt(target.transform.position);
                animator.SetBool("ATTACK", true);
                if (DistanceToPlayer() > 30f)
                {
                    state = STATE.IDLE;

                }
                // Attack();
                if (DistanceToPlayer() > 16f && DistanceToPlayer() < 30f)
                {
                    state = STATE.CHASE;
                    agent.isStopped = false;
                }
                break;

            case STATE.DEATH:
                TurnOffAllAnim();
                // animator.SetBool("Death", true);
                break;
            default:
                break;
        }

    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(target.transform.position, agent.transform.position);
    }

    public bool NearPlayer()
    {
        if (DistanceToPlayer() < 20f)
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
        // animator.SetBool("Death", false);
        animator.SetBool("RUN", false);
        animator.SetBool("ATTACK", false);
    }

    public void Attack()
    {
        currentTime = currentTime - Time.deltaTime;
        if (player != null)
        {
            if (currentTime <= 0f)
            {
                player.health--;
                player.health--;
                Debug.Log(player.health);
                currentTime = attackTime;

            }

            if (player.health == 0)
            {
                Destroy(target);
                isGameOver = true;
                TurnOffAllAnim();
                // PlayerController.GameOver();
            }
            //  }


        }
    }
}
