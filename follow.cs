using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follow : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    float range = 2f;
    float maxdistance = 4f;
    // GameObject agen1;
    Animator anim;
    
    void Start()
    {
        // agen1=  GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        if(anim == null){
            Debug.Log("No animation for player");
        }
        // if(agen1 != null){
        //     Debug.Log(agen1);
        // }
        //  if(agen1 == null){
        //     Debug.Log(agen1);
        // }

    }

    // Update is called once per frame
    void Update()
    {
         
        float distance = Vector3.Distance(this.transform.position,player.transform.position);
        if(distance < range){
            Debug.Log("Attack Mode");
        } 
        if(distance > range && distance < maxdistance){
            Debug.Log("Patrol Mode");
        }
        agent.destination = player.transform.position;

    
    }
    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Player"){
            Debug.Log("Collided with Player");
        }
    }

}   
