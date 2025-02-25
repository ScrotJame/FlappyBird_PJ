using System.Collections;
using UnityEngine;

public class SwapnControll : MonoBehaviour
{
    [SerializeField] private GameObject NomarlPipe;
    [SerializeField] private GameObject SpecialPipe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawner());  
    }
    

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); 
            Vector3 _instant = NomarlPipe.transform.position;
            _instant.y = Random.Range(-0.21f, 1.25f);
            Instantiate(NomarlPipe, _instant, Quaternion.identity);

            //Random ngau nghien Special Pipe trong khoang 6 don vi
            if (Random.Range(5,11)==6) 
            {
                yield return new WaitForSeconds((float)0.5); 
                Vector3 _instant2 = SpecialPipe.transform.position;
                _instant2.y = Random.Range(-0.21f, 1.25f);
                Instantiate(SpecialPipe, _instant2, Quaternion.identity);

                 
                yield return new WaitForSeconds((float)0.25);
            }
            
        }
    }
}
