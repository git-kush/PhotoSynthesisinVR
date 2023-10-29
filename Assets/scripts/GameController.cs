using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public GameObject TopicsUI;
    public GameObject theoryUI;
    public GameObject plantUI;
    public GameObject rootUI;
    public GameObject leafUI;
    public GameObject rxnPageUI;
    public GameObject plant;
    public GameObject learningUI;
    public GameObject leafWithStomata;
    public GameObject[] drops=new GameObject[10];
    public GameObject[] targets = new GameObject[11];
    bool flag = false;
    public float t3;
    public float speed;
    public float speed2;


    // Start is called before the first frame update
    void Start()
    {
       //  dropToRoots();
      //  InvokeRepeating("roottToCamera", 0.1f, 0.1f);
        // InvokeRepeating("dropToRoots",t3, 0.1f);
       // InvokeRepeating("roottToCamera", 10f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void dropToRoots()
    {
        StartCoroutine(vanishBubbles());
        for(int i =0; i<10;i++) 
        { 

                drops[i].transform.position = Vector3.MoveTowards(drops[i].transform.position, targets[i].transform.position, speed);
            //  }
            if (Vector3.Distance(drops[i].transform.position, targets[i].transform.position) == 0)
            {
              // plant.gameObject.transform.GetChild(i).gameObject.SetActive(false);
               // Debug.Log(plant.gameObject)
            }


        }
        
        IEnumerator vanishBubbles()
        {
            yield return new WaitForSeconds(2);
            for (int i = 0; i < 10; i++)
            {
                drops[i].SetActive(false);

            }


        }

    }

    void rootToCamera()
    {
        plant.transform.position = Vector3.MoveTowards(plant.transform.position, targets[10].transform.position, speed2);
    }

    void leafToCamera()
    {
        plant.transform.position = Vector3.MoveTowards(plant.transform.position, targets[11].transform.position, speed2);
    }
    public void photosynthesis()
    {
        TopicsUI.gameObject.SetActive(false);
        theoryUI.gameObject.SetActive(true);
       
    }

    public void STARTtoPlantUI()
    {
        theoryUI.gameObject.SetActive(false);
        plantUI.gameObject.SetActive(true);
        plant.gameObject.SetActive(true);

        //adding main stuffs displaying it
    }

    public void nextToRootUI()
    {  
        plantUI.gameObject.SetActive(false);
        rootUI.gameObject.SetActive(true);
          InvokeRepeating("rootToCamera", 0.1f, 0.1f);
          InvokeRepeating("dropToRoots", t3, 0.1f);
        //displaying roots ,,zoom,,,water mov,,,audio
    }

    public void nextToLeafUI()
    {
        CancelInvoke("rootToCamera");
        InvokeRepeating("leafToCamera", 0.1f, 0.1f);
        rootUI.gameObject.SetActive(false);
        leafUI.gameObject.SetActive(true);  
        leafWithStomata.gameObject.SetActive(true);
        //displaying..leaf..stomata
    }
    public void seeRxn()
    {
        plant.gameObject.SetActive(false);
        leafUI.gameObject.SetActive(false);
        rxnPageUI.gameObject.SetActive(true);
        leafWithStomata.gameObject.SetActive(false);
    }
    public void nextToLastUI()
    {
        rxnPageUI.gameObject.SetActive(false);
        learningUI.gameObject.SetActive(true);
    }

    public void finish()
    { 
        Application.Quit();
    }

    

}
