using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour, IInteractable
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



        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            

            Player player = other.gameObject.GetComponent<Player>();
            if (player.isInteracting)
            {
                Debug.Log("Interact Key!");
                player.isClimbing = true;
            }
       
        

        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    
}
