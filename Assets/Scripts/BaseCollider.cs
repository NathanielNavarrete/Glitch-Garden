using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D otherCollider) {
        
        FindObjectOfType<HealthDisplay>().DepleteHealth();
        Destroy(otherCollider.gameObject);
    }
}
