using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    public float speed;
    public float fireballCooldown = 5;
    private float fireballTS;


    public GameObject fireballPrefab;
    public Transform fireposition;
    public GameObject targetCursor;

    void Start()
    {
        targetCursor = Instantiate(targetCursor);
    }

    void OnDestroy()
    {
        Destroy(targetCursor);
    }

    public void ShootFireball(Vector3 target)
    {
        if (fireballTS <= Time.time)
        {
            GameObject fb = Instantiate(fireballPrefab);
            fb.transform.position = fireposition.position;

            Vector3 projectileDirection = target - fireposition.transform.position; // - ScreenPosition(fireposition)

            Projectile projectile = fb.GetComponent<Projectile>();
            projectile.ProjectileDirection(projectileDirection);

            // Put a target cursor on projectile direction
            targetCursor.transform.position = target;

            fireballTS = Time.time + fireballCooldown;
        }

    }

    // Update wizard position with keyboard input
    public void UpdateWizardPosition(Vector3 dir)
    {
        // Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (dir.magnitude > 1.0f)
        {
            dir.Normalize();
        }
        transform.position += dir * speed * Time.deltaTime;
    }


    // Get screen position
    public Vector3 ScreenPosition(Transform t = null)
    {
        if (t == null) t = transform;
        return Camera.main.WorldToScreenPoint(t.position);
    }
}
