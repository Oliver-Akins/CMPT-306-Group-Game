using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSSizeControl : MonoBehaviour
{
    public float scaleNumber = 1.0f;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(scaleNumber, scaleNumber, scaleNumber);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = scale;
        for (int i=0; i< gameObject.transform.childCount; i++) {
            Transform c = gameObject.transform.GetChild(i);
            c.transform.localScale = scale;
        }
            
    }
}
