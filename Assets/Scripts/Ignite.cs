using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : MonoBehaviour {

    private GameObject flame;

    private void Start()
    {
        flame = this.transform.Find("Flame").gameObject;
        //flame.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fire Attack")
        {
            flame.SetActive(true);
        }
        if (collision.gameObject.name == "Water Attack")
        {
            if (flame.activeSelf)
            {
                flame.SetActive(false);
            }
        }
    }
}
