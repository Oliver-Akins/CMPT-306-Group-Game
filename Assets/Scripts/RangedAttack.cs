using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject rangedWeapPrefab;
    public float weapForce = 20f;
    // limit the fire rate for the player
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    // Update is called once per frame
    void Update(){

        if (timeBetweenShots <= 0){
            if(Input.GetButtonDown("Fire2")){
                RangeAttack();
                timeBetweenShots = startTimeBetweenShots;
            }
        } else {
            timeBetweenShots -= Time.deltaTime;
        }
   
    }

    void RangeAttack(){
       GameObject ammo = Instantiate(rangedWeapPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * weapForce, ForceMode2D.Impulse);
    }
}
