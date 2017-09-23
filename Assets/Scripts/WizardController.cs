﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    public float speed;

    public GameObject fireball;
    public Transform fireposition;

    public void ShootFireball(Vector3 target)
    {
        GameObject fb = Instantiate(fireball);
        fb.transform.position = fireposition.position;

        Vector3 fireDirection = target - ScreenPosition(fireposition);

        Projectile projectile = fb.GetComponent<Projectile>();
        projectile.ProjectileDirection(fireDirection);

        Destroy(fb, 3.0f);
    }

    // Update wizard position with keyboard input
    public void UpdateWizardPosition(Vector3 target)
    {
        // Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (target.magnitude > 1.0f)
        {
            target.Normalize();
        }
        transform.position += target * speed * Time.deltaTime;
    }

    
    // Get screen position
    public Vector3 ScreenPosition(Transform t = null)
    {
        if (t == null) t = transform;
        return Camera.main.WorldToScreenPoint(t.position);
    }
}
