using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private GameObject fireAttack;
    private GameObject waterAttack;

	// Use this for initialization
	void Start () {
        fireAttack = this.transform.Find("Fire Attack").gameObject;
        waterAttack = this.transform.Find("Water Attack").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleFire();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ToggleWater();
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
            waterAttack.SetActive(false);
        }
    }

    private void ToggleWater()
    {
        if (waterAttack.activeSelf)
        {
            waterAttack.SetActive(false);
        }
        else
        {
            waterAttack.SetActive(true);
            fireAttack.SetActive(false);
        }
    }
}
