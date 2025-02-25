using UnityEngine;

public class BackgroundScale :MonoBehaviour
{
  void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 scaletmp = transform.localScale;

        float scaley = spriteRenderer.bounds.size.y;
        float scalex = spriteRenderer.bounds.size.x;

        float heigtScreen = Camera.main.orthographicSize *2f;
        float weightScreen = heigtScreen * Screen.width/Screen.height;

        scaletmp.y = heigtScreen / scaley;
        scaletmp.x = weightScreen/scalex;
        transform.localScale = scaletmp;
    }   
}
