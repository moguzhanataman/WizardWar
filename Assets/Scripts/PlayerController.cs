using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    WizardController wizardController;

    // Use this for initialization
    void Start()
    {
        wizardController = GetComponent<WizardController>();
    }

    // Update is called once per frame
    void Update()
    {
        LookToMouse();
		wizardController.UpdateWizardPosition(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));
		
        if (Input.GetMouseButtonDown(0))
        {
            wizardController.ShootFireball(Input.mousePosition - wizardController.ScreenPosition(wizardController.fireposition));
        }
    }

	// Makes wizard look towards mouse
    private void LookToMouse()
    {
        Vector3 scale = transform.localScale;
        if (wizardController.ScreenPosition().x < Input.mousePosition.x)
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
