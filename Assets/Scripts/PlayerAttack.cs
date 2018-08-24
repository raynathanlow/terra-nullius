using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject playerModel;
    private GameObject fireAttack;
    private GameObject waterAttack;

    // Use this for initialization
    void Start()
    {
        fireAttack = this.transform.Find("Fire Attack").gameObject;
        waterAttack = this.transform.Find("Water Attack").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FireAttack();

        }
        else if (Input.GetMouseButton(1))
        {
            WaterAttack();

        }
        else
        {
            NoAttack();
        }
    }

    private void FireAttack()
    {
        playerModel.transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        fireAttack.transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        fireAttack.SetActive(true);
        waterAttack.SetActive(false);
    }

    private void WaterAttack()
    {
        playerModel.transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        waterAttack.transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        fireAttack.SetActive(false);
        waterAttack.SetActive(true);
    }

    private void NoAttack()
    {
        fireAttack.SetActive(false);
        waterAttack.SetActive(false);
    }
}
