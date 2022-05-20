using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    CharacterController character;
    public float speed;
    public float rotateSpeed;
    Animator anim;
    public int health;
    public int maxhealth;
    public Slider healthBar;
    public GameObject ragdoll;

    public GameObject gameover;


    // Start is called before the first frame update
    void Start()
    {
      
        character = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        //enemy = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX, 0f, inputZ);

       
        anim.SetFloat("speed", movement.magnitude);

      
        transform.Rotate(Vector3.up, inputX * rotateSpeed * Time.deltaTime);  //Rotation of player in left and right direction.
        if (inputZ != 0)
        {
            character.SimpleMove(transform.forward * Time.deltaTime * inputZ*speed);//Movement of player in forward and backward direction.
            PlayerAudioSource.instance.PlayerWalk();
        }


    }
    public void Ragdoll()
    {

        if (health <=0)
        {
           GameObject temp= Instantiate(ragdoll, this.transform.position, Quaternion.identity);
           
            Destroy(gameObject);
            Destroy(temp, 1f);
            gameover.SetActive(true);

        }
    }

  



}

