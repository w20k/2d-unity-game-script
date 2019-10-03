using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdfly : MonoBehaviour
{   
    public float pvelocity, startDashTime;
    private Rigidbody2D rb;
    private Collider2D birdcollider;
    public float force = 5f;
    public float dashSpeed, startCooldown, topY;
    private float dashtime;
    public GameObject dasheffect, BloodStain, dustparticle, trailEffect, zenPulse;
    Animator anim;
    Renderer ren;
    private float Cooldown;
    private camShake CamShake;
    private RipplePostprocesser camRipple;
    bool dashing, jumping;
    public Material material1;
    Material originalmat;

    private AudioSource source;
    public AudioClip dashSound, deathSound, jumpSound;
    void Awake() {
        CamShake = GameObject.FindGameObjectWithTag("screenshake").GetComponent<camShake>();
        camRipple = Camera.main.GetComponent<RipplePostprocesser>();
        rb = GetComponent<Rigidbody2D>();
        birdcollider =  GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        ren = GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
        originalmat = ren.material;
    }
    public void Start()
    {    
        rb.velocity = Vector2.right * pvelocity;
        rb.AddForce(Vector2.up * 300);
        dashtime = startDashTime;
        Cooldown = 0; 
        ren.material = material1;
    }
    // Update is called once per frame
    void Update()
    {   Cooldown -= Time.deltaTime;
        if(transform.position.y > topY){ 
            transform.position = new Vector3(transform.position.x,topY,transform.position.z);
            rb.AddForce(Vector2.down * 40);
            }

        if (Cooldown <= 0){
            ren.material = material1;
        }
        if(dashtime <= 0)
            {
                dashing = false;
                zenPulse.SetActive(false);
                dashtime = startDashTime;
                ren.material = originalmat;
                rb.velocity = Vector2.right * pvelocity;
                birdcollider.enabled = true;
            }
        if (dashing)
            {   
                source.clip = dashSound;
                source.Play();
                birdcollider.enabled = false;
                zenPulse.SetActive(true);
                CamShake.camShaking();
                Instantiate(dasheffect, transform.position, Quaternion.identity);
                rb.velocity = Vector2.right * dashSpeed;
                dashtime -= Time.deltaTime;    
                if (dashtime <= 0) {
                     Cooldown = startCooldown;
                }
            }
        
    }
    public void birdJump()
    {       
        
           rb.velocity = new Vector2 (rb.velocity.x, force);
            rb.AddForce(Vector2.right * 17);
            source.clip = jumpSound;
        source.Play();
            CamShake.camJump();
            Instantiate(trailEffect, transform.position, Quaternion.identity);
    
    }
     void OnCollisionEnter2D(Collision2D  collision){
         if (collision.gameObject.CompareTag("traps")){
            gameOverEffect();
        }
    }
     void OnTriggerEnter2D(Collider2D  collision){
         if (collision.gameObject.CompareTag("traps")){
            gameOverEffect();
         }
    }
     void OnParticleCollision(GameObject other) {
         if (other.CompareTag("traps"){
           gameOverEffect();
         }
     }    
    public void DashButton(){
         if (Cooldown <= 0){
            dashing = true;
         }
    }
    void gameOverEffect(){
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position, 1f);
            Instantiate(dustparticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            camRipple.RippleEffect();
            Instantiate(BloodStain, transform.position, Quaternion.identity);
            GameControl.instance.BirdDied();   
    }  
}
