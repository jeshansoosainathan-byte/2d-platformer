using UnityEngine;

public class WateringCan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static int numberCollected = 0;

    public bool isCollected = false;
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

            numberCollected++;
            isCollected = true;
            Debug.Log($"Watering cans collected: {numberCollected}");
               this.gameObject.SetActive(false);

        }

    }
}
