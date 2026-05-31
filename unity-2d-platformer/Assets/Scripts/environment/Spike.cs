//Jeshan Soosainathan - 000924893
using UnityEngine;

public class Spike : MonoBehaviour
{
    // On collide, kill player, destroy object
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {

        //See if collider object is tagged as Player
        if (collision.gameObject.CompareTag("Player"))
        {

            Player player = collision.gameObject.GetComponent<Player>();

            player.kill();
            Destroy(this.gameObject);

        }

    }
}
