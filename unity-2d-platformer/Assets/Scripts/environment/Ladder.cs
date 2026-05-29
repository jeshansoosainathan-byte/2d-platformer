using UnityEngine;

public class Ladder : MonoBehaviour, IInteractable
{
    public string getHoverText(GameObject interactor)
    {



        return "INTERACT to Climb";
    }

    public void interact(GameObject interactor)
    {
        throw new System.NotImplementedException();
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
