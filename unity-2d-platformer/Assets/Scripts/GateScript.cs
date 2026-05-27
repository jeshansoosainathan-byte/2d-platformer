using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Collided!");
        //See if collider object is tagged as Player
        if (collision.gameObject.CompareTag("Player"))
        {

       Player player = collision.gameObject.GetComponent<Player>();



            if (player.hasKey)
            {
              ;
                SceneManager.LoadScene("Level2");


            } else
            {
              
            }

        }

    }



}
