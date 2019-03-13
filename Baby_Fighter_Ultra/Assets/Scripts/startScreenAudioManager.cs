 using UnityEngine;
 using System.Collections;
 
public class startScreenAudioManager: MonoBehaviour
{
     public AudioSource audioSourceIntro;
     public AudioSource audioSourceLoop;
     private bool startedLoop;
 
     void FixedUpdate()
     {
         if (!audioSourceIntro.isPlaying && !startedLoop)
         {
             audioSourceLoop.Play();
             Debug.Log("Done playing");
             startedLoop = true;
         }
     }
 }