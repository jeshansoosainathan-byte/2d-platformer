using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour, IInteractable, IClimable
{

    public InputActionAsset inputActions;
    private InputAction InteractAction;

    public string getHoverText(GameObject interactor)
    {



        return "INTERACT to Climb";
    }

    public void OnEnable()
    {



        InteractAction = InputSystem.actions.FindAction("Interact");
   



    }

    public void interact(GameObject interactor)
    {
       if (interactor.CompareTag("Player"))
        {


            Player player = interactor.GetComponent<Player>();

            player.isClimbing = true;
            player.spriteRenderer.sprite = player.climbSprite;
            Debug.Log("Interacted!");


        }
    }

 
    


  
    
}
