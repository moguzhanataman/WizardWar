using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour {

	public float speed;

	public GameObject fireball;
	public Transform fireposition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir= new Vector3( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0 );
		if(dir.magnitude > 1.0f) {
			dir.Normalize();
		}

		transform.position += dir * speed * Time.deltaTime;


		Vector3 scale= transform.localScale;
		if( ScreenPosition().x < Input.mousePosition.x ) {
			scale.x = -1;
		}
		else{
			scale.x= 1;
		}
		transform.localScale= scale;


		if(Input.GetMouseButtonDown(0)){
			ShootFireball();
		}
	}

	public void ShootFireball(){
		GameObject fb= Instantiate(fireball);
		fb.transform.position= fireposition.position;

		Vector3 fireDirection= Input.mousePosition - ScreenPosition(fireposition);

		Projectile projectile= fb.GetComponent<Projectile>();
		projectile.ProjectileDirection(fireDirection);
	}

	Vector3 ScreenPosition(Transform t=null){
		if(t == null) t=transform;
		return Camera.main.WorldToScreenPoint(t.position);
	}
}
