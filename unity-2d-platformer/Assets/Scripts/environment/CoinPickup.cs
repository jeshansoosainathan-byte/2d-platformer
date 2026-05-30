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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Player player = collision.gameObject.GetComponent<Player>();


            player.score += 1;
            Debug.Log("Score: " + player.score);
            Destroy(this.gameObject);
     

        }



    }
}
