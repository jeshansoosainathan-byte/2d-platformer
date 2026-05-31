//Jeshan Soosainathan - 000924893
using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour, IInteractable, IClimable
{

  

    //Unused - returns hover text for interactable
    public string getHoverText(GameObject interactor)
    {



        return "INTERACT to Climb";
    }

     

    //Player starts climbing when interacted with
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
