using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject rangedWeapPrefab;
    public float weapForce = 20f;
    // Update is called once per frame
    void Update(){
        if(Input.GetButtonDown("Fire2")){
            RangeAttack();
        }
    }

    void RangeAttack(){
       GameObject ammo = Instantiate(rangedWeapPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * weapForce, ForceMode2D.Impulse);
    }
}
