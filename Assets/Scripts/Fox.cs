using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        
        if (otherObject.GetComponent<Defender>() && otherObject.name != "Gravestone(Clone)")
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
        else if (otherObject.name == "Gravestone(Clone)")
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
    }
}
