using System.Collections.Generic;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{

[SerializeField] List<AudioSource> music = new List<AudioSource>();

[SerializeField] AudioSource audioSource;

public float volume;
AudioSource currentMusic;
AudioSource nextMusic;

bool transMusic;
bool transDangerMusic;

bool isDangerMusicOn;

[SerializeField]AudioClip stalkerAttack;
[SerializeField]AudioClip stalkerReagress;

[SerializeField] AudioClip creeperExplosion;
[SerializeField] AudioClip turretShoot;
[SerializeField] AudioClip creeperWindup;



[SerializeField] List<AudioClip> ambience = new List<AudioClip>();

float timer, timerMax, maxVolume;


public void SetVolume(float sliderValue)
{
  sliderValue = volume;
  audioSource.volume = volume;
}
 
void Start()
{
  currentMusic = music[0];
  nextMusic = music[1];

}

void Update()
{

timer += Time.deltaTime;

if (timer > timerMax)
{
  PlayAmbience();
  timer = 0;
}

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

public void GetSliderMax(float value)
{
  maxVolume = value;
}

void TransitionMusic(AudioSource startMusic, AudioSource endMusic)
{

  if (music[2].volume == 0f)
  {
startMusic.volume -= 0.0005f;
endMusic.volume += 0.0005f;

if ( currentMusic.volume == 0f && endMusic.volume > maxVolume)
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

if ( currentMusic.volume == 0f && music[2].volume == maxVolume)
{
transDangerMusic = false;
isDangerMusicOn = true;

}
  }
else 
{ 

currentMusic.volume += 0.0005f;
music[2].volume -= 0.0005f;
if ( currentMusic.volume == maxVolume && music[2].volume == 0f)
{
transDangerMusic = false;
isDangerMusicOn = false;
}
}
}


public void PlayStalkerAttack()
{
  audioSource.PlayOneShot(stalkerAttack, volume);
}


public void PlayStalkerReagress()
{
  audioSource.PlayOneShot(stalkerReagress, volume);

}
public void PlayCreeperExplosion()
{
  audioSource.PlayOneShot(creeperExplosion);
}
public void PlayTurretShoot()
{
  audioSource.PlayOneShot(turretShoot, volume);
}

public void PlayCreeperWindup()
{
  audioSource.PlayOneShot(creeperWindup);
}
public void PlayAmbience()
{
int ranAmbience = Random.Range(0, ambience.Count);

 audioSource.PlayOneShot(ambience[ranAmbience], volume);
}

}
