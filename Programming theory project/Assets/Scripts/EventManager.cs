using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void bulletHit(int damage);
    public static event bulletHit OnHit;
    public static event bulletHit OnDeath;

  

    public static void HitCall(string message)
    {
        //polymorphism ?? 
        if(OnHit != null)
        {
            if (message == "Zombie")
            {
                OnHit(2);
                Debug.Log("message" + message);
            }
            if(message == "HeadShot")
            {
                OnHit(10);
                Debug.Log("message" + message);
            }
        }
    }

    public static void DeathCall(string message)
    {
        //abstraction
        if(OnDeath != null)
        {
            if(message == "ZombieDead")
            {
                OnDeath(1);
            }
        }
    }
}
