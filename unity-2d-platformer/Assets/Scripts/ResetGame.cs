using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {

        //If r is pressed this frame
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Get Current Scene

           Scene scene = SceneManager.GetActiveScene();


            //reset scene

            SceneManager.LoadScene(scene.buildIndex);




        }
    }
}
