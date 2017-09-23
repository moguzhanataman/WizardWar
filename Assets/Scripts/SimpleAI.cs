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
		wizardController.UpdateWizardPosition(new Vector3(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y,
            0));
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
}
