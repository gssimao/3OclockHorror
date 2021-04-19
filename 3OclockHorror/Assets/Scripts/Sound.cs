using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

	public string name; //name of the sound, used to find it for scripts attempting to play

	public AudioClip clip; //Actual clip

	[Range(0f, 1f)] //Volume, sets it in a range with a handy scrollbar in the editor
	public float volume = 1f;

	[Range(1f, 3f)] //Same as volume but for pitch
	public float pitch = 1f;

	public bool loop = false; //Do I loop?
	 
	public AudioMixerGroup mixerGroup; //Is there a mixer?

	//[HideInInspector]
	public AudioSource source; //Source associated with this sound - not in editor, controlled behind the scene
    [HideInInspector]
    float fadeStartTime;
    bool isFading = false;
    float timeToFade;

    #region get/set
    public float getStartTime()
    {
        return fadeStartTime;
    }
    public void setStartTIme(float newStartTime)
    {
        fadeStartTime = newStartTime;
    }
    public bool getFading()
    {
        return isFading;
    }
    public void setFading(bool fading)
    {
        isFading = fading;
    }
    public void setFadeTime(float nF)
    {
        timeToFade = nF;
    }
    #endregion

    void Update()
    {
        if (isFading)
        {
            AudioFadeOut();
        }
    }

    public void AudioFadeOut()
    { 
        float startVolume = this.source.volume;

        if (this.source.isPlaying && isFading)
        {
            /*
            while (s.source.volume > 0)
            {
                s.source.volume -= startVolume * (Time.deltaTime / FadeTime);
            }
            */

            if (this.source.volume < 0)
            {
                this.source.Stop();
                this.source.volume = startVolume;
                isFading = false;
            }
            else
            {
                float dTime = Time.deltaTime - fadeStartTime;
                this.source.volume -= startVolume * (dTime / timeToFade);
            }
        }

    }
}
