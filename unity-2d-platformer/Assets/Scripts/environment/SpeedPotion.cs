using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Player player = collision.gameObject.GetComponent<Player>();

            player.powerUp();
 
            Debug.Log("Power Up!");
            Destroy(this.gameObject);


        }



    }
}
