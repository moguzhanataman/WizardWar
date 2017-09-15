using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int dmg = 1;

    Vector3 velocity = Vector3.right * 10;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    public void ProjectileDirection(Vector3 dir)
    {
        dir.z = 0;
        velocity = dir.normalized * speed;

        transform.LookAt(transform.position + dir);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Actor a = coll.rigidbody.GetComponent<Actor>();

        if (a != null)
        {
            a.TakeDamage(dmg);
            Destroy(gameObject);
        }

    }
}
