using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private GameObject fireAttack;

	// Use this for initialization
	void Start () {
        fireAttack = this.transform.Find("Fire Attack").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleFire();
        }
	}

    private void ToggleFire()
    {
        if (fireAttack.activeSelf)
        {
            fireAttack.SetActive(false);
        } else
        {
            fireAttack.SetActive(true);
        }
    }
}
