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
        //Setup the qualities of the projectile(s)
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
        Dictionary<string, int> skills = player.GetSkillLevels();
        // if its Piercing
        if (skills["Piercing"] > 0){
            projectileQualities["maxPeirces"] = skills["Piercing"];
        }
        // is AoE
        // bool isAoE = true;
        // if (isAoE){
        //     projectileQualities["AoEDamage"] = 5;
        // }
        // fire in the the character wanted to at least once
        rangedWeapPrefab.GetComponent<SpriteRenderer>().sprite = item.GetSprite();
        GameObject ammo = Instantiate(rangedWeapPrefab, firePoint.position, firePoint.rotation);
        
        ammo.GetComponent<Projectile>().setQualities(projectileQualities);
        Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * weapForce, ForceMode2D.Impulse);
        source.PlayOneShot(rockThrow);

        // fire extra projectiles
        int howManyProjectiles = skills["Multiply"];
        if (howManyProjectiles > 0){
            StartCoroutine(multiFire(howManyProjectiles, item, projectileQualities));
        }
    }

    IEnumerator multiFire(int howManyProjectiles, InventoryItem item, 
        Hashtable projectileQualities) {

        for (int i = 0; i < howManyProjectiles; i++){
            yield return new WaitForSeconds(.1f); // wait to fire the 2+ projectile
            rangedWeapPrefab.GetComponent<SpriteRenderer>().sprite = item.GetSprite();
            
            GameObject ammo2 = Instantiate(rangedWeapPrefab, firePoint.position, firePoint.rotation);
            ammo2.GetComponent<Projectile>().setQualities(projectileQualities);
            Rigidbody2D rb2 = ammo2.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint.up * weapForce, ForceMode2D.Impulse);
            source.PlayOneShot(rockThrow);
        }
    }
}
