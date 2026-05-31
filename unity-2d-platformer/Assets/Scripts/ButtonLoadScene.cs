//Jeshan Soosainathan - 000924893
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scenetoLoad)
    {

        SceneManager.LoadScene(scenetoLoad);

    }
}
