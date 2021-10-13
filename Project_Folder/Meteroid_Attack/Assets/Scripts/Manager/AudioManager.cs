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
    }

    public void Play (string sound)
   	{	
   		
            Sound s = Array.Find(sounds, item => item.name == sound);

            s.source.Play();
      
   	}

    public void Mute_UnMute()
    {
        if (isMuted)
        {
            isMuted = false;

            foreach (Sound s in sounds)
            {
                s.source.enabled =!isMuted;
            }
        }
        else
        {
            isMuted = true;
            foreach (Sound s in sounds)
            {
                s.source.enabled = !isMuted;
            }
        }

    }

   }
