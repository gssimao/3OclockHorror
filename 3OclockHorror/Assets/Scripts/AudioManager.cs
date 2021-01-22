using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance; //Is there an audio manager? Used to ensure only one instance

	public AudioMixerGroup mixerGroup; //For audio source mixing

	public Sound[] sounds; //List of sounds managed by the manager

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject); //Is there a manager? If yes then I'm gone
		}
		else
		{
			instance = this;  //There isnt a manager? I'm it
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds) //Init each sound - give it a source and init that source to make it playable
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void Play(string sound) 
	{
		Sound s = Array.Find(sounds, item => item.name == sound); //Find the sound we want to play, ensure it's not null
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume; //Set the volume and pitch to the one contained by the sound
		s.source.pitch = s.pitch;

		if (!s.source.isPlaying) //Check if the sound is playing - if not, have at it.s
		{
			s.source.Play();
		}
	}

	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound); //Find the sound we want to play, ensure it's not null
        if (s != null & s.source.isPlaying)
        {
            s.source.Stop();
        }
    }

}
