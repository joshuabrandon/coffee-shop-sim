using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt; // returns _prompt, like get _prompt
    
    protected override void OnCollided(GameObject collidedObject)
    {
        // base.OnCollided(collidedObject); //used to call the parent (CollidableObject)
        if(Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }

        if (!z_Interacted)
        {
            _interactionPromptUI.SetUp(_prompt);
        }
    }

    protected virtual void OnInteract()
    {
        if (!z_Interacted)
        {
            z_Interacted = true;
            _interactionPromptUI.Close();
            Debug.Log("Interact with " + name);
        }
    }
}
