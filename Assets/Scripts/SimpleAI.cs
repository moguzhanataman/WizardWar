using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    private WizardController wizardController;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        wizardController = GetComponent<WizardController>();
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("ShootToPlayer", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        LookToPlayer();
        MoveToPlayer();
    }

    void LookToPlayer()
    {
        Vector3 scale = transform.localScale;
        // TODO: not sure
        if (wizardController.ScreenPosition().x < player.transform.position.x)
        {
            scale.x = -1;
        }
        else
        {
            scale.x = 1;
        }

        transform.localScale = scale;
    }

    private void MoveToPlayer()
    {
        Vector3 direction = BotToPlayerDirection();
        wizardController.UpdateWizardPosition(direction);
    }

    private void ShootToPlayer()
    {
        Vector3 direction = BotToPlayerDirection();
        wizardController.ShootFireball(direction);
    }

    private Vector3 BotToPlayerDirection()
    {
        return new Vector3(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y,
            0);
    }
}
