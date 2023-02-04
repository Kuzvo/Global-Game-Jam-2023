using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

public AudioSource audioSource;
  public List<AudioClip> music = new List<AudioClip>();

bool transMusic;

public float volume;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transMusic == true)
        {
          TransitionMusic(music[0], music[1]);
        }
    }

   void PlayMusic(AudioClip music)
   {
    audioSource.PlayOneShot(music, volume);
   }

//https://www.youtube.com/watch?v=1VXeyeLthdQ
      void TransitionMusic(AudioClip startMusic, AudioClip endMusic)
      {

      }

}
