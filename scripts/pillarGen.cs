using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarGen : MonoBehaviour  
{   
    public GameObject thePillar, secondPillar, Chars, Chars1, Chars2, Chars3, buttterfly, newobst, revolveObs;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;
    //public float height;
    [SerializeField] private int whatToSpawn;
    private int ButterflySpawn;
   
    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePillar.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (transform.position.x < generationPoint.position.x)
        {   
            whatToSpawn = Random.Range(1,9);
            ButterflySpawn = Random.Range(1,3);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y , transform.position.z);
            
            switch (whatToSpawn)
            {
                case 1:
                    GameObject newOne = Instantiate (thePillar, transform.position, transform.rotation);
                    newOne.SetActive(true);
                    break;
                case 2:
                    GameObject new1 = Instantiate (secondPillar, transform.position, transform.rotation);
                    new1.SetActive(true);
                    break;
                case 3:
                    GameObject new2 = Instantiate (Chars, transform.position, transform.rotation);
                    new2.SetActive(true);
                    transform.position = new Vector3(transform.position.x + platformWidth-2, transform.position.y , transform.position.z);
                    break;
                case 4:
                    GameObject new3 = Instantiate (Chars1, transform.position, transform.rotation);
                    new3.SetActive(true);
                    transform.position = new Vector3(transform.position.x + platformWidth-4, transform.position.y , transform.position.z);
                    break;
                case 5:
                    GameObject new4 = Instantiate (Chars2, transform.position, transform.rotation);
                    new4.SetActive(true);
                    transform.position = new Vector3(transform.position.x + platformWidth-1, transform.position.y , transform.position.z);
                    break;
                 case 6:
                    GameObject new5 = Instantiate (Chars3, transform.position, transform.rotation);
                    new5.SetActive(true);
                    transform.position = new Vector3(transform.position.x + platformWidth-1, transform.position.y , transform.position.z);
                    break;
                case 7:
                    GameObject new6 = Instantiate (newobst, transform.position, transform.rotation);
                    new6.SetActive(true);
                    transform.position = new Vector3(transform.position.x + platformWidth+2, transform.position.y , transform.position.z);
                    break;
                case 8:
                    GameObject new7 = Instantiate (revolveObs, transform.position, transform.rotation);
                    new7.SetActive(true);
                    transform.position = new Vector3(transform.position.x + platformWidth+1, transform.position.y , transform.position.z);
                    break;
            }
            switch (ButterflySpawn){
            case 2:
                GameObject Btterfly = Instantiate (buttterfly, transform.position, transform.rotation);
                Btterfly.SetActive(true);
                break;
            }
        }   
    }
}
