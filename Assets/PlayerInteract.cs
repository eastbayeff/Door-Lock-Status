using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactableIndicator;
    private IInteractable currentInteractable;

    public void SetCurrentInteractable(IInteractable interactable)
    {
        currentInteractable = interactable;
        interactableIndicator.SetActive(interactable != null);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            currentInteractable?.Interact();  
    }
}
