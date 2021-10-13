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
   			s.source.clip = s.clip;
   			s.source.volume = s.volume;
   			s.source.pitch = s.pitch;
   			s.source.loop = s.loop;
   		}
   	}


    public bool wasMuted()
    {
        return isMuted;
    }

    public void setAudio(bool value)
    {
        isMuted = value;
    }


    public void Play (string sound)
   	{	
   		
            Sound s = Array.Find(sounds, item => item.name == sound);

            s.source.Play();
      
   	}

 
   	
}
