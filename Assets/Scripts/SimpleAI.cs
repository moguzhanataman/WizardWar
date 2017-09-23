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
        if (wizardController.transform.position.x < player.transform.position.x)
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
        wizardController.ShootFireball(player.transform.position);
    }

    private Vector3 BotToPlayerDirection()
    {
        return player.transform.position - transform.position;
    }
}
