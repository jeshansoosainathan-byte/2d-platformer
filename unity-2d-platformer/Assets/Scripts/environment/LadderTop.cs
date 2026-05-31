//Jeshan Soosainathan - 000924893
using UnityEngine;

public class LadderTop : MonoBehaviour
{

    public Transform teleportBlock;

    //Once player reaches boxcollider, teleport to given position and stop climbing.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.isClimbing)
            {

                collision.gameObject.transform.SetPositionAndRotation(teleportBlock.position, teleportBlock.rotation);
                player.StopClimbing();
            }

        }
        


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
