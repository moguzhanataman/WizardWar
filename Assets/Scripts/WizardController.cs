using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    public float speed;

    public GameObject fireball;
    public Transform fireposition;

    void Start()
    {

    }

    void Update()
    {
        UpdateWizardPosition();
        LookToMousePosition();

        if (Input.GetMouseButtonDown(0))
        {
            ShootFireball();
        }
    }

    private void ShootFireball()
    {
        GameObject fb = Instantiate(fireball);
        fb.transform.position = fireposition.position;

        Vector3 fireDirection = Input.mousePosition - ScreenPosition(fireposition);

        Projectile projectile = fb.GetComponent<Projectile>();
        projectile.ProjectileDirection(fireDirection);
    }

    // Get screen position
    Vector3 ScreenPosition(Transform t = null)
    {
        if (t == null) t = transform;
        return Camera.main.WorldToScreenPoint(t.position);
    }

    // Makes wizard look towards mouse
    private void LookToMousePosition()
    {
        Vector3 scale = transform.localScale;
        if (ScreenPosition().x < Input.mousePosition.x)
        {
            scale.x = -1;
        }
        else
        {
            scale.x = 1;
        }
        transform.localScale = scale;
    }

	// Update wizard position with keyboard input
    private void UpdateWizardPosition()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (dir.magnitude > 1.0f)
        {
            dir.Normalize();
        }
        transform.position += dir * speed * Time.deltaTime;
    }
}
