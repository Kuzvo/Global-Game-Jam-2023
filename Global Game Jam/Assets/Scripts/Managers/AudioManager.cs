using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

[SerializeField] List<AudioSource> music = new List<AudioSource>();

[SerializeField] AudioSource audioSource;


AudioSource currentMusic;
AudioSource nextMusic;

bool transMusic;
bool transDangerMusic;

bool isDangerMusicOn;

AudioClip stalkerAttackNoise;
AudioClip creeperExplosion;

void Start()
{
  currentMusic = music[0];
  nextMusic = music[1];
}

void Update()
{

if(Input.GetMouseButtonDown(0))
{  
  transMusic = true;
}

if(Input.GetMouseButtonDown(1))
{  
  transDangerMusic = true;
}

if (transMusic)
{
  TransitionMusic(currentMusic, nextMusic);
}

if (transDangerMusic)
{
TransitionDangerMusic();
}

}

void TransitionMusic(AudioSource startMusic, AudioSource endMusic)
{

  if (music[2].volume == 0f)
  {
startMusic.volume -= 0.0005f;
endMusic.volume += 0.0005f;

if ( currentMusic.volume == 0f && endMusic.volume == 1f)
{
transMusic = false;

nextMusic = startMusic;
currentMusic = endMusic;

}
  }

}
void TransitionDangerMusic()
{
  if (isDangerMusicOn == false)
  {
currentMusic.volume -= 0.0005f;
music[2].volume += 0.0005f;

if ( currentMusic.volume == 0f && music[2].volume == 1f)
{
transDangerMusic = false;
isDangerMusicOn = true;

}
  }
else 
{ 

currentMusic.volume += 0.0005f;
music[2].volume -= 0.0005f;
if ( currentMusic.volume == 1f && music[2].volume == 0f)
{
transDangerMusic = false;
isDangerMusicOn = false;
}
}
}


public void PlayStalkerAttack()
{
  audioSource.PlayOneShot(stalkerAttackNoise);
}

public void PlayCreeperExplosion()
{
  audioSource.PlayOneShot(creeperExplosion);
}

}
