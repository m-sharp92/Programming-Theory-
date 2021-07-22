using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* throw in some extra prefabs for inheritance from this class
 * random spawn and speed and look and such
 * */
public class ZombieMove : MonoBehaviour
{
    GameObject look;
    int Health = 10;
    int bulletDamage;
    Rigidbody zombieRb;
    [SerializeField] float shotForce = 300f;
    protected Animator zomAnim;
    protected float speedMultiply = 1f;
    readonly float lookSpeed = 0.3f;
    float turnTime = 0f;
    ZombieMove instance;


    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        look = GameObject.Find("BulletSpawn");
        zomAnim = GetComponent<Animator>();
        zomAnim.SetFloat("speedMultiply", speedMultiply);
        zomAnim.speed *= speedMultiply;
        Debug.Log("new speed" + zomAnim.speed);

        EventManager.OnHit += EventManager_OnHit;
        
        zombieRb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(Rotation());
    }

    private void EventManager_OnHit(int damage)
    {
        bulletDamage = damage;
        if (Health >= 1)
        {
            zombieRb.AddForce(new Vector3(shotForce, 0, shotForce), ForceMode.Impulse);
            Health -= bulletDamage;
            Death();
        }
      
    }

    virtual protected void Death()
    {

        if (Health <= 0)
        {
            gameObject.SetActive(false);
            EventManager.DeathCall("ZombieDead");
        }

    }

   protected IEnumerator Rotation()
    {
        //overly complicated
        // stops animation whilsts rotating else anim based movement stops;
        while(look != null)
        {
            
            if (turnTime >= 1)
            {
                zomAnim.speed = 1;
                turnTime = 0f;
            }
            yield return new WaitForSeconds(3f);
            
            zomAnim.speed = 0;
            while (turnTime < 1000)
            {
                var lookPos = look.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * lookSpeed);
                turnTime++;
            }
        }
    }
}        
   
