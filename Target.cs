using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject destroyVersion;
    
    public void TakeDamage(float damage){
        health -= damage;
        if(health < 0){
            Die();
        }
    }
    public void Destroyfromoutside(){
        Die();
    }
    void Die(){
        Instantiate(destroyVersion,transform.position,transform.rotation);
        Destroy(gameObject);

    }
}
