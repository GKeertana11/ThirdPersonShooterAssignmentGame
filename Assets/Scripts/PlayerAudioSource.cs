using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioSource : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public List<AudioClip> audioClips;
    public static PlayerAudioSource instance;
    private void Awake()//single ton
    {
        if (instance == null)
        {
            instance = this;
        }
        return;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShotFire()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }

   public void PlayerWalk()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }

   

    public void EnemyHit()
    {
        audioSource.PlayOneShot(audioClips[2]);
    }
    public void Background()
    {
        audioSource.PlayOneShot(audioClips[3]);
    }
   

}
