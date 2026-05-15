using UnityEngine;

public class Camera : MonoBehaviour
{
    public Rigidbody2D target;
    public SpriteRenderer targetRenderer;
    public float lookAheadOffset;
    public float lerpValue = 0.5f;

    void Update()
    {

        bool isFacingLeft = targetRenderer.flipX;
   

        Vector3 newPos = target.position;

        newPos.z = this.transform.position.z;

 



         
        this.transform.position = newPos;

        


    }



}
