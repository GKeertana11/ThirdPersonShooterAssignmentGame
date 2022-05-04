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
    public Slider healthBar;
    public int maxhealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
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
   

}

