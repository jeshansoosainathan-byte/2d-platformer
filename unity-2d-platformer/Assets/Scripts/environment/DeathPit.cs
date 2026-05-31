//Jeshan Soosainathan - 000924893
using UnityEngine;

public class DeathPit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //On triggered, kill player
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            Player player = collision.gameObject.GetComponent<Player>();


            player.kill();




        }



    }
}
