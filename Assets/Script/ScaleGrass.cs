using UnityEngine;

public class ScaleGrass :MonoBehaviour
{
  void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 scaletmp = transform.localScale;

        float scaley = spriteRenderer.bounds.size.y;
        float scalex = spriteRenderer.bounds.size.x;

        float heigtScreen = Camera.main.orthographicSize *2f;
        float weightScreen = heigtScreen * Screen.width/Screen.height;

        scaletmp.x = weightScreen/scalex;
        transform.localScale = scaletmp;

        Vector3 position = transform.position;
        position.y = Camera.main.transform.position.y - (heigtScreen / 2) + (spriteRenderer.bounds.size.y / 2);
        transform.position = position;
    }   
}
