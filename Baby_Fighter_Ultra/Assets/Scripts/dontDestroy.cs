 using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public class dontDestroy : MonoBehaviour {
 
     void Awake ()
     {
         GameObject[] objs = GameObject.FindGameObjectsWithTag("mainTheme");
         DontDestroyOnLoad(this.gameObject);
 
     }
 
     void Update()
     {
         if (SceneManager.GetActiveScene().name == "Fight")
         {
             Destroy(this.gameObject);
         }
     }
 }