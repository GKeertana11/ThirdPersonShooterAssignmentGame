using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController character;
    public float speed;
    public float rotateSpeed;
    Animator anim;
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

        character.SimpleMove(movement * speed * Time.deltaTime);
        //anim.SetFloat("Run", movement.magnitude);
       // GunScript.instance.walk();
        /*  if (movement.magnitude > 0f)
          {
              Quaternion tempDirection = Quaternion.LookRotation(movement * Time.deltaTime);
              transform.rotation = Quaternion.Slerp(transform.rotation, tempDirection, Time.deltaTime * rotateSpeed);
          }*/
        transform.Rotate(Vector3.up, inputX * rotateSpeed * Time.deltaTime);
        if (inputZ != 0)
        {
            character.SimpleMove(transform.forward * Time.deltaTime * inputZ);
        }


    }
}

