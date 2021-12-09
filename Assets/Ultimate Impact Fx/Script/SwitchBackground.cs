using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBackground : MonoBehaviour
{
    public Texture2D dark;
    public Texture2D bright;
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_MainTex", dark);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dark_bg()
    {
        meshRenderer.material.SetTexture("_MainTex", dark);
    }

    public void bright_bg()
    {
        meshRenderer.material.SetTexture("_MainTex", bright);
    }
}
