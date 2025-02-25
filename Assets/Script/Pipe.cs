using UnityEngine;
using UnityEngine.EventSystems;

public class Pipe : MonoBehaviour
{

    [SerializeField] private int speed;
     

    void Update()
    {
        if (Bird.BirdInstance == null) {  return; }
        else
        
           if (Bird.BirdInstance.flag == 1)
        {
            Destroy(GetComponent<Pipe>());
        }
        
        _pipeMove();
    }
    public void _pipeMove()
    {
        Vector3 pipePoint = transform.position;
        pipePoint.x -= speed * Time.deltaTime;
        transform.position = pipePoint;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}
