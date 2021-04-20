using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance; //Is there an audio manager? Used to ensure only one instance

	[SerializeField]
	bool isTutorial = false;

	public AudioMixerGroup mixerGroup; //For audio source mixing

	public Sound[] sounds; //List of sounds managed by the manager

    /*[SerializeField]
    List<string> soundList;*/

	void Awake()
	{
		if (!isTutorial)
		{
			if (instance != null && instance != null)
			{
				Destroy(gameObject); //Is there a manager? If yes then I'm gone
			}
			else
			{
				instance = this;  //There isnt a manager? I'm it
				DontDestroyOnLoad(gameObject);
			}
		}

        foreach (Sound s in sounds) //Init each sound - give it a source and init that source to make it playable
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;

            //soundList.Add(s.name);
        }
	}

	public void Play(string sound, bool isRandom) 
	{
		Sound s = Array.Find(sounds, item => item.name == sound); //Find the sound we want to play, ensure it's not null
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}


		if (!s.source.isPlaying) //Check if the sound is playing - if not, have at it.s
		{
            if (!isRandom)
            {
                s.source.volume = s.volume; //Set the volume and pitch to the one contained by the sound

                s.source.pitch = s.pitch;
            }

            else if (isRandom)
            {
                s.source.volume = Random.Range(s.volume - 0.1f, s.volume + 0.1f); //Random Volume

                s.source.pitch = Random.Range(0.8f, 1.2f); // Random Pitch
            }

            s.source.Play();

		}
	}

	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound); //Find the sound we want to play, ensure it's not null
        if(s.source == null)
        {
            Debug.Log(sound + " does not have its source assigned anymore");
            s.source = gameObject.AddComponent<AudioSource>(); //attempt to add a new one
        }
        if (s != null & s.source.isPlaying)
        {
            s.source.Stop();
        }
    }



    public void StartFade(string sound, float ttq)
    {

        Sound s = Array.Find(sounds, item => item.name == sound);

        s.setStartTIme(Time.time);

        s.setFading(true);

        s.setFadeTime(ttq);

    }

    public void recreateSounds()
    {
        //First, run through and destory each instance of audio source
        Component[] sources = this.gameObject.GetComponents<AudioSource>() as Component[];
        foreach(Component source in sources)
        {
            Destroy(source as AudioSource);
        }

        foreach (Sound s in sounds) //Then recreate it
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;

            //soundList.Add(s.name);
        }
    }

 /*   public void PlaySFX(string sound) // Same as play, but the volume and pitch are random

    {

        Sound s = Array.Find(sounds, item => item.name == sound); 

        if (s == null)

        {

            Debug.LogWarning("Sound: " + name + " not found!");

            return;

        }



        s.source.volume = Random.Range(s.volume - 0.1f, s.volume + 0.1f); //Random Volume

        s.source.pitch = Random.Range(0.8f, 1.2f); // Random Pitch



        if (!s.source.isPlaying) //Check if the sound is playing - if not, have at it.s

        {

            s.source.Play();

        }

    }*/

        

        /*

    public static IEnumerator AudioFadeOut(string sound, float fadingTime, Func<float, float, float, float> Interpolate)

    {

        Sound s = Array.Find(sounds, item => item.name == sound);

        float startVolume = s.source.volume;

        float frameCount = fadingTime / Time.deltaTime;

        float framesPassed = 0;



        while (framesPassed <= frameCount)

        {

            var t = framesPassed++ / frameCount;

            s.source.volume = Interpolate(startVolume, 0, t);

            yield return null;

        }



        s.source.volume = 0;

        s.source.Pause();

    }

    public void StartFade(string sound, float ttq)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.setStartTIme(Time.time);
        s.setFading(true);
        s.setFadeTime(ttq);
    }

    public void PlaySFX(string sound) // Same as play, but the volume and pitch are random
    {
        Sound s = Array.Find(sounds, item => item.name == sound); 
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = Random.Range(s.volume - 0.1f, s.volume + 0.1f); //Random Volume
        s.source.pitch = Random.Range(0.8f, 1.2f); // Random Pitch

        if (!s.source.isPlaying) //Check if the sound is playing - if not, have at it.s
        {
            s.source.Play();
        }
    }
        
        /*
    public static IEnumerator AudioFadeOut(string sound, float fadingTime, Func<float, float, float, float> Interpolate)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        float startVolume = s.source.volume;
        float frameCount = fadingTime / Time.deltaTime;
        float framesPassed = 0;

        while (framesPassed <= frameCount)
        {
            var t = framesPassed++ / frameCount;
            s.source.volume = Interpolate(startVolume, 0, t);
            yield return null;
        }

        s.source.volume = 0;
        s.source.Pause();
    }
    */
}
