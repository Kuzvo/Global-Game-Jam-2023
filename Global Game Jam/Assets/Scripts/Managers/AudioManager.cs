using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

[SerializeField]public List<AudioSource> music = new List<AudioSource>();

[SerializeField] AudioSource audioSource;

public float volume;
AudioSource currentMusic;
AudioSource nextMusic;

public bool transMusic;
public bool transDangerMusic;

bool isDangerMusicOn;

[SerializeField]AudioClip stalkerAttack;
[SerializeField]AudioClip stalkerReagress;

[SerializeField] AudioClip creeperExplosion;
[SerializeField] AudioClip turretShoot;
[SerializeField] AudioClip creeperWindup;

[SerializeField] List<AudioClip> ambience = new List<AudioClip>();

public float timer, timerMax;


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

MusicManager();

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

if ( currentMusic.volume == 0f && endMusic.volume > 1)
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

if ( currentMusic.volume == 0f && music[2].volume == 1)
{
transDangerMusic = false;
isDangerMusicOn = true;

}
  }
else 
{ 

currentMusic.volume += 0.0005f;
music[2].volume -= 0.0005f;
if ( currentMusic.volume == 1 && music[2].volume == 0f)
{
transDangerMusic = false;
isDangerMusicOn = false;
}
}
}


void MusicManager()
{

  if (GameManager.Instance.respawn == true)
  {
music[0].Play();
music[2].Stop();
  }
if (GameManager.Instance.timeRemaining > GameManager.Instance.initTimer / 2)
{
transMusic = true;
}
else  if (GameManager.Instance.timeRemaining < GameManager.Instance.initTimer / 2)
{
  transDangerMusic = true;
}
}


void DeathMusic()
{
  
if (GameManager.Instance.timeRemaining < 5f)
{
  currentMusic.volume -= 0.0005f;
  music[2].volume -= 0.0005f;
  music[3].Play();

  music[3].volume += 0.0005f;

  if (GameManager.Instance.timeRemaining <= 0)
  {
    
  music[3].volume -= 0.0005f;
  currentMusic = music[0];
  music[0].volume += 0.0005f;
  if (GameManager.Instance.respawn == false)
  {
     music[3].Stop();
  }
}
}
}

public void PlayStalkerAttack()
{
  audioSource.PlayOneShot(stalkerAttack);
}


public void PlayStalkerReagress()
{
  audioSource.PlayOneShot(stalkerReagress);

}
public void PlayCreeperExplosion()
{
  audioSource.PlayOneShot(creeperExplosion);
}
public void PlayTurretShoot()
{
  audioSource.PlayOneShot(turretShoot);
}

public void PlayCreeperWindup()
{
  audioSource.PlayOneShot(creeperWindup);
}
public void PlayAmbience()
{
int ranAmbience = Random.Range(0, ambience.Count);

 audioSource.PlayOneShot(ambience[ranAmbience]);
}

}
