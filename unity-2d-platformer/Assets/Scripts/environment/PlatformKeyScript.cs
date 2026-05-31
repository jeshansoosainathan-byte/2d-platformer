//Jeshan Soosainathan - 000924893
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

    //On trigger, increase key count and destroy object
    private void OnTriggerEnter2D(Collider2D collision)
    {
 
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
