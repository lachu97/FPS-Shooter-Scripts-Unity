using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float health = 60f;
    bool hasexploded = false;
    public GameObject explosioneffect;
   //The thing to play the audio
    // Start is called before the first frame update

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
        Instantiate(explosioneffect,transform.position,transform.rotation);
        Destroy(gameObject);
        
    }

}
