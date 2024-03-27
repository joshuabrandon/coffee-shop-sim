using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
    
    protected override void OnCollided(GameObject collidedObject)
    {
        // base.OnCollided(collidedObject); //used to call the parent (CollidableObject)
        if(Input.GetKey(KeyCode.E))
        {
            OnInteract();
        } 
    }

    protected virtual void OnInteract()
    {
        if (!z_Interacted)
        {
            z_Interacted = true;
            Debug.Log("Interact with " + name);
        }
    }
}
