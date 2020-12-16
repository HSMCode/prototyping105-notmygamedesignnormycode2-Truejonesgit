using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject Food;
    
    
    
    
    
     
   
    void Update(){ 
        
        for(int i = 0; i < popUps.Length; i++)
        if( i == popUpIndex){
            popUps[i].SetActive(true);
        } else {
            popUps[i].SetActive(false);
        }
{
    
}
        if(popUpIndex == 0){
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
                popUpIndex++;
                Food.SetActive(true);
                
               
            }
                
            } 

        }
    }
    


