using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyZombie : ZombieMove
{
    //polymorphism and inheritance
    void Start()
    {
        speedMultiply *= 1;
        zomAnim = GetComponent<Animator>();
        zomAnim.SetFloat("speedMultiply", speedMultiply);
        zomAnim.speed *= speedMultiply;
        StartCoroutine(Rotation());

    }
}
