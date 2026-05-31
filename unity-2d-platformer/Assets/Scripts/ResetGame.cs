//Jeshan Soosainathan - 000924893
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    public InputActionAsset inputActions;
    private InputAction resetAction;

    // Resets game when reset key is pressed
    void Update()
    {
        if (resetAction.IsPressed())
        {

            SceneManager.LoadScene("Level1");


        }
  
    
    }

    private void Awake()
    {   
        if (resetAction==null)
        {


            resetAction = InputSystem.actions.FindAction("Reset");

        }
    }

}
