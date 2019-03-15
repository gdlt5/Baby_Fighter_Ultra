 using UnityEngine;
 using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class startScreenAudioManager: MonoBehaviour
{
     public AudioSource audioSourceIntro;
     public AudioSource audioSourceLoop;
     private bool startedLoop;
 

    void Start(){
        audioSourceIntro.Play();
        audioSourceLoop.PlayDelayed(audioSourceIntro.clip.length-1.5f);
    }
    /*
     void FixedUpdate()
     {
         if (!audioSourceIntro.isPlaying && !startedLoop)
         {
             audioSourceLoop.Play();
             Debug.Log("Done playing");
             startedLoop = true;
         }
     }
     */
 }