using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public float health = 20f;
     bool hasexploded = false;
     public GameObject explosioneffect;
     public GameObject fire;
     public GameObject burningfire;
     public GameObject audiofile;
     public float radius = 2f;
     public float force = 200f;
    private AudioSource audio;
    private AudioSource burn;
 
    // Start is called before the first frame update
    void Start(){
         audio = audiofile.GetComponent<AudioSource>();
        burn = burningfire.GetComponent<AudioSource>();
         if (audio == null)
         {
             Debug.LogError("No AudioSource found");
         }
          if (burn == null)
         {
             Debug.LogError("No AudioSource found");
         }
    }

      public void takeDam(float damage){
        health -= damage;
       
        if(health <= 0 && !hasexploded){

            explodeDie();
            hasexploded = true;
        }
    }
      void explodeDie(){
        Debug.Log("Boom");
        //Destroy 
        audio.PlayOneShot(audio.clip);
        GameObject exp=Instantiate(explosioneffect,transform.position,transform.rotation);
        Instantiate(fire,transform.position,transform.rotation);
        burn.Play();
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius); 
        foreach ( Collider coll in colliders){
          Rigidbody rb = coll.GetComponent<Rigidbody>();
          if(rb != null){
            rb.AddExplosionForce(force,transform.position,radius+3f);
          }
          Target tar = coll.GetComponent<Target>();
          if(tar != null){
            tar.Destroyfromoutside();
          }
        }
        Destroy(exp,2f);
        Destroy(gameObject);

    }
}
