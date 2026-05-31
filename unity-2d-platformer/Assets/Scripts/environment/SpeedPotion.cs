//Jeshan Soosainathan - 000924893
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{

    //On triggered, powerup player, increasing speed.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Player player = collision.gameObject.GetComponent<Player>();

            player.powerUp();
 
     
            Destroy(this.gameObject);


        }



    }
}
