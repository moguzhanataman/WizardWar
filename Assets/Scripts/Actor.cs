using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	public int maxHP;
	int hp;

	void Start () {
		hp= maxHP;
	}
	
	public void TakeDamage(int dmg) {
		hp -= dmg;

		if(hp <= 0){
			Destroy(gameObject);
		}
	}
}
