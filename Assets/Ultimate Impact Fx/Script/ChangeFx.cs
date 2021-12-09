using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFx : MonoBehaviour
{
    public Text effect_name;
    public GameObject[] effect;
    public float _TimeDel = 2.0f;
    public Camera cam;
    Animator camAnim;
    float minY = -2.5f;
    private static int numSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        camAnim = cam.GetComponent<Animator>();
        effect = Resources.LoadAll<GameObject>("Prefabs");
        effect_name.text = effect[0].name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 6.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            if(objectPos.y < minY)
            {
                objectPos.y = minY;
            }
            GameObject fx = Instantiate(effect[numSpawned], objectPos, Quaternion.identity);
            Destroy(fx, _TimeDel);
        }
    }

    void changeTextLabel(int numSpawned)
    {
        effect_name.text = effect[numSpawned].name;
        if(effect[numSpawned].name.StartsWith("G"))
        {
            camAnim.SetBool("isCamChange", true);
        }
        else
        {
            camAnim.SetBool("isCamChange", false);
        }
    }

    public void nextEf()
    {
        if (numSpawned < effect.Length - 1)
        {
            numSpawned++;
            //effect_name.text = effect[numSpawned].name;
            changeTextLabel(numSpawned);
        }
        else if(numSpawned >= effect.Length - 1)
        {
            numSpawned = 0;
            changeTextLabel(numSpawned);
        }
    }

    public void prevEf()
    {
        if (numSpawned > 0)
        {
            numSpawned--;
            //effect_name.text = effect[numSpawned].name;
            changeTextLabel(numSpawned);
        }
        else if(numSpawned == 0)
        {
            numSpawned = effect.Length - 1;
            changeTextLabel(numSpawned);
        }
    }
}
