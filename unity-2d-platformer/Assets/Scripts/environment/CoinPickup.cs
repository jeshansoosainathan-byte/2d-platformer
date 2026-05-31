//Jeshan Soosainathan - 000924893
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Grants player +1 point on trigger and destroys coin
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Player player = collision.gameObject.GetComponent<Player>();


            player.score += 1;
             
            Destroy(this.gameObject);
     

        }



    }
}
