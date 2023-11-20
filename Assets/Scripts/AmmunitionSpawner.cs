using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionSpawner : MonoBehaviour
{
    public Transform spawnAmmunition;
    public GameObject ammunitionPrefab;
    public float ammunitionSpeed;
    public float ammunitionFireRate;
    private float baseFireRate;
    void Start()
    {
        baseFireRate = ammunitionFireRate;
    }
    void Update()
    {
        ammunitionFireRate -= Time.deltaTime;
        if (ammunitionFireRate <= 0)
        {
            Fire();
        }
        //if (Input.GetButtonDown("Fire1"))
        //{
            //ammunitionFireRate -= Time.deltaTime;
            //Fire();
        //}
    }

    void Fire()
    {
        GameObject ammunition = Instantiate(ammunitionPrefab, spawnAmmunition.position, spawnAmmunition.rotation);
        Rigidbody ammunitionRB = ammunition.GetComponent<Rigidbody>();
        ammunitionRB.AddForce(spawnAmmunition.forward * ammunitionSpeed, ForceMode.Impulse);
        ammunitionFireRate = baseFireRate;
    }
}
