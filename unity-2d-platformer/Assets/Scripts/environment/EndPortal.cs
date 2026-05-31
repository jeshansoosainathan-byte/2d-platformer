//Jeshan Soosainathan - 000924893
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortal : MonoBehaviour
{
    public string scene;



    //Teleport to given scene
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene(scene);


        }


    }


}
