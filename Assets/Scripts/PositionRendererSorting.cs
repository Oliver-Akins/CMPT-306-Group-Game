using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Can be used to sort prefabs in the scene once and then update the player's sorting
order in the scene relative to the other objects. Note we can have a background,
midground, foreground and UI layers if we want. I would recommend putting the
player into the midground with interactive scene objects
Also objects need a pivot sort point for this to function correctly
*/
public class PositionRendererSorting : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 0;

    // For static sprites in the scene this only needs to be run once to give 
    // them a sort order value
    [SerializeField]
    private bool onlyRunOnce = false;
    private Renderer myRenderer;
    
    // awake grabs it at the start of the game!
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // we want to figure out the sorting after the movement of the player is done
    private void LateUpdate()
    {
        // calculate the players sort order as it is moving around
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y * 100);
        if (onlyRunOnce){
            // destory the script on the prefab static sprites once this has run once
            Destroy(this);
        }
    }
}
