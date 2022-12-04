using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject player;


    private void Update() {

        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRange = 2f;
            Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray) {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable)) 
                {
                    npcInteractable.Interact();
                    playerCamera.transform.position = new Vector3(0.25557524f, 0.405990332f, 0.466765314f);
                    player.transform.position = new Vector3(-19.8999996f, 3.44000006f, -36.6500015f);
                }
            }
        }
    }

    public NPCInteractable GetInteractableObject() {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray) {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return npcInteractable;
            }
        }
        return null;
    }
}
        
       
   
    
      