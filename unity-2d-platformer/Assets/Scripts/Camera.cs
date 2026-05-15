using UnityEngine;

public class Camera : MonoBehaviour
{
    public Rigidbody2D target;
    public SpriteRenderer targetRenderer;
    public float lookAheadOffset;

    [Range(0f,1f)]
    public float lookAheadSpeed = 0.5f;

    void Update()
    {

        bool isFacingLeft = targetRenderer.flipX;
   

        Vector3 newPos = target.position;

        newPos.z = this.transform.position.z;

    float offsetX = isFacingLeft ? -lookAheadOffset : lookAheadOffset;

        newPos.z = this.transform.position.z;

        newPos.x += offsetX;


        Vector3 newpos2 = Vector3.Lerp(this.transform.position, newPos, lookAheadSpeed * Time.deltaTime);
        this.transform.position = newpos2;

        


    }



}
