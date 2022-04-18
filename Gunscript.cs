
using UnityEngine;

public class Gunscript : MonoBehaviour
{
    public float damage=10f;
    public float range=100f;
    public float impactForce = 500f;
    public float firerate = 15f;
    private float nexttimetofire =0f;
    public ParticleSystem smoke;
    


    public GameObject bullets;
    public Camera fpsCam;
    public Transform attackPoint;
     private AudioSource m_AudioSource; //The thing to play the audio
 
    private void Start()
     {
         m_AudioSource = GetComponent<AudioSource>();
 
         if (m_AudioSource == null)
         {
             Debug.LogError("No AudioSource found");
         }
    }

    void Update()
    {
      if(Input.GetButtonDown("Fire1") && Time.time >= nexttimetofire){
          nexttimetofire = Time.time + 1f/firerate;
          BeginShoot();
      }  
    }
    void BeginShoot(){
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));

        RaycastHit hit;
        Vector3 targetPoint;

    

        

        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward,out hit,range)){
            Debug.Log(hit.transform.name);
            targetPoint = hit.point; 
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactForce );
            }
            Target tar = hit.transform.GetComponent<Target>();
            boom tar1 = hit.transform.GetComponent<boom>();
            if(tar1 != null){
                tar1.takeDam(damage);
            }
            if(tar != null){
                tar.TakeDamage(damage);
            }
            Vector3 directionwithoutSpread = targetPoint - attackPoint.position;
            GameObject bullet = Instantiate(bullets,attackPoint.position, Quaternion.identity); 
            bullet.transform.forward = directionwithoutSpread.normalized;
            bullet.GetComponent<Rigidbody>().AddForce(directionwithoutSpread.normalized*10f,ForceMode.Impulse);
            Destroy(bullet,0.25f);
            ParticleSystem smoky = Instantiate(smoke,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(smoky,0.5f);
            

        }
        else {
            targetPoint = ray.GetPoint(100f);
        }
       
    
    }
}
