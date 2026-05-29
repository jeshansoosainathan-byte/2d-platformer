using UnityEngine;

public class PlatformKeyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //See if collider object is tagged as Player
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.platformKeys >= 3) return;

            player.platformKeys++;
            player.UpdateUI();
            Destroy(this.gameObject);
            

        }

    }
}
