using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public float speed = 1;

    public GameObject player;
    public GameObject fireball;
    public Transform fireposition;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
		InvokeRepeating("ShootToPlayer", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        LookToMouse();
    }

    private void ShootToPlayer()
    {
        Vector3 playerDirection = new Vector3(
                    player.transform.position.x - transform.position.x,
                    player.transform.position.y - transform.position.y,
                    0);

        GameObject fb = Instantiate(fireball);
        fb.transform.position = fireposition.position;

        Vector3 fireDirection = playerDirection - ScreenPosition(fireposition);

        // Debug.Log(Input.mousePosition);

        Projectile projectile = fb.GetComponent<Projectile>();
        projectile.ProjectileDirection(fireDirection);

        Destroy(fb, 3.0f);
    }

    private void MoveToPlayer()
    {
        Vector3 direction = new Vector3(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y,
            0);

        if (direction.magnitude > 1.0f)
        {
            direction.Normalize();
        }

        transform.position += direction * speed * Time.deltaTime;
    }

    // Get screen position
    Vector3 ScreenPosition(Transform t = null)
    {
        if (t == null) t = transform;
        return Camera.main.WorldToScreenPoint(t.position);
    }

    // Makes wizard look towards mouse
    private void LookToMouse()
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
}
