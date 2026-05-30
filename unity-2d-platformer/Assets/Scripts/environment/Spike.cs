using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
