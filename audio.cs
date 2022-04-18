using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
 
         if (source == null)
         {
             Debug.LogError("No AudioSource found");
         }
        
    }
    public void playaudiofromfile(){
        source.PlayOneShot(source.clip);
    }

}
