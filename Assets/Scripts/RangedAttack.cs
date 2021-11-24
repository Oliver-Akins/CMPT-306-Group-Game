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
    public Player player;
    public AudioSource source;

	public AudioClip rockThrow;

    // Update is called once per frame
    void Update(){
        if (startTimeBetweenShots > 0){     
            float agiMod = startTimeBetweenShots * (( (float)player.agility /2) / 10);
            if (timeBetweenShots <= 0){
                if(Input.GetButtonDown("Fire2")){
                    RangeAttack();
                    timeBetweenShots = startTimeBetweenShots - agiMod;
                    if (agiMod > startTimeBetweenShots){
                        startTimeBetweenShots = 0;
                    }
                }
            } else {
                timeBetweenShots -= Time.deltaTime;
            }
        } else if (Input.GetButtonDown("Fire2") && startTimeBetweenShots <= 0 ){
            RangeAttack();
        }
    }

    void RangeAttack(){
       GameObject ammo = Instantiate(rangedWeapPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * weapForce, ForceMode2D.Impulse);

        source.PlayOneShot(rockThrow);

    }
}
