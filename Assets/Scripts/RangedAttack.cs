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

    public Camera cam;

    // Update is called once per frame
    void Update(){
        
        if (startTimeBetweenShots > 0){     

            // the current mouse position in world coordinates
            Vector3 mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
            // the direction the mouse is relative to the player
            Vector3 mouseDirection = (mouseposition - transform.position).normalized;
            // the offset to move the fire position, this moves the fire point outwards
            // can be tweaked as needed, 1f may be enough.
            Vector3 attackPosition = transform.position + mouseDirection * 2f;
            firePoint.SetPositionAndRotation(attackPosition, firePoint.rotation);

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
        InventoryItem item = player.GetEquippedWeaps()["equippedRange"];
        rangedWeapPrefab.GetComponent<SpriteRenderer>().sprite = item.GetSprite();
        GameObject ammo = Instantiate(rangedWeapPrefab, firePoint.position, firePoint.rotation);
        var projectileQualities = new Hashtable();
        projectileQualities.Add("damageAmount", player.getRangeDamage());
        if (item.type == ItemTypes.ItemType.ARROW){
            projectileQualities["bleedTicks"] = 5;
            projectileQualities["bleedTickDamage"] = 5 + player.strength/3;
        }
        else if (item.type == ItemTypes.ItemType.FIREBALL){
            projectileQualities["burnTicks"] = 8;
            projectileQualities["burnTickDamage"] = 8 + player.strength/2;
        }
        // if its peircing
        if (true){
            projectileQualities["maxPeirces"] = 2;
        }
        // if its bouncy
        if (true){
            projectileQualities["maxBounces"] = 3;
        }
        ammo.GetComponent<Projectile>().setQualities(projectileQualities);
        Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * weapForce, ForceMode2D.Impulse);

        source.PlayOneShot(rockThrow);

    }
}
