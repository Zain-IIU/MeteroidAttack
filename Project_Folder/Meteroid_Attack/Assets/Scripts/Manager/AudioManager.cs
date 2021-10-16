using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
   
   	public Sound[] sounds;
   
   	public Sound sound;


    public static bool isMuted = false;
    
    
   	void Awake ()
   	{
   		if (instance != null)
   		{
   			Destroy(gameObject);
   		} else
   		{
   			instance = this;
   		}

      

   		foreach (Sound s in sounds)
   		{
   			s.source = gameObject.AddComponent<AudioSource>();
            s.source.playOnAwake = false;
   			s.source.clip = s.clip;
   			s.source.volume = s.volume;
   			s.source.pitch = s.pitch;
   			s.source.loop = s.loop;
   		}
        

        Sound s1 = Array.Find(sounds, item => item.name == "Space");
        s1.source.playOnAwake = true;

        DisableAudio();
    }

    public void Play (string sound)
   	{	
   		
            Sound s = Array.Find(sounds, item => item.name == sound);

            s.source.Play();
      
   	}


    public void DisableAudio()
    {
        if (PlayerPrefs.GetInt("PlayAudio") == 0)
        {
  
            foreach (Sound s in sounds)
            {
                s.source.enabled = true;
            }
        }
        else
        {
           
            foreach (Sound s in sounds)
            {
                s.source.enabled = false;
            }
        }
    }
    public void Mute_UnMute()
    {
        if (PlayerPrefs.GetInt("PlayAudio")==0)    
        {
            Debug.Log("UnMute");
            PlayerPrefs.SetInt("PlayAudio", 1);          
            foreach (Sound s in sounds)
            {
                s.source.enabled = false;
            }
        }
        else
        {
            Debug.Log("Muted");
            PlayerPrefs.SetInt("PlayAudio", 0);              
            foreach (Sound s in sounds)
            {
                s.source.enabled = true;
            }
        }
    }

   }
