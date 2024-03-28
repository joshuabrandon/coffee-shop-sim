using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectv2 : MonoBehaviour
{
    [SerializeField] private Collider2D z_Collider;
    [SerializeField] private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1);

    private bool z_Interacted = false;
    private bool displayPromptUI = false;

    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    [SerializeField] private string _prompt;

    private void Start()
    {
        z_Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);
        foreach (var o in z_CollidedObjects)
        {
            OnCollided(o.gameObject);
        }
        DisplayPromptUI();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            displayPromptUI = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ResetInteract();
            displayPromptUI = false;
        }
    }

    private void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }

    private void OnInteract()
    {
        if (!z_Interacted)
        {
            z_Interacted = true;
            displayPromptUI = false;
            Debug.Log("Interact with " + name);
        }
        // Once the interaction is done, make displayPromptUI = true
    }

    private void ResetInteract()
    {
        if (z_Interacted)
        {
            z_Interacted = false;
            Debug.Log("Finished with " + name);
        }
    }

    private void DisplayPromptUI()
    {
        if (displayPromptUI)
        {
            _interactionPromptUI.SetUp(_prompt);
        }
        if (!displayPromptUI)
        {
            _interactionPromptUI.Close();
        }
    }
}
