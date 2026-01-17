using UnityEngine;

public class MovingBG : MonoBehaviour
{
    private float speed = 2f;
    public float endX = -1920f;
    public float startX = 4800f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.position.x<=endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }
}
