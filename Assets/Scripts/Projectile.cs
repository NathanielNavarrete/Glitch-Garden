using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float damage = 50f;
    [SerializeField] GameObject levelController;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
       
    }

    private void OnTriggerEnter2D(Collider2D otherCollider2D) {
        var health = otherCollider2D.GetComponent<Health>();
        var attacker = otherCollider2D.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
