using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    public InputActionAsset inputActions;
    private InputAction resetAction;

    // Update is called once per frame
    void Update()
    {
        if (resetAction.IsPressed())
        {

            SceneManager.LoadScene("Level1");


        }
        //If r is pressed this frame
    
    }

    private void Awake()
    {   
        if (resetAction==null)
        {


            resetAction = InputSystem.actions.FindAction("Reset");

        }
    }

}
