using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueZombie : ZombieMove
{
   
   //polymorphism and inheritance
    void Start()
    {
        speedMultiply *= 2; 
        zomAnim = GetComponent<Animator>();
        zomAnim.SetFloat("speedMultiply", speedMultiply);
        zomAnim.speed *= speedMultiply;
        StartCoroutine(Rotation());
        
    }


}
