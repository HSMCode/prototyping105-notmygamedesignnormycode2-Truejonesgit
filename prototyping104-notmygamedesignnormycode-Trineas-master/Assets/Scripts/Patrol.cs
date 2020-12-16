using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public EnemyLineOfSightRotate lineOfSightRotate;
  public float speed;
  public Transform moveSpot;
  
  private float waitTime;
  public float startWaitTime;
  public float minX;
  public float maxX;
  public float minY;
  public float maxY;
  

public float rotationSpeed;
public float distance;

  void Start(){
    waitTime = startWaitTime;
      moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
      
      
  }

  private void Update(){

     transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

    if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f){

      if(waitTime <= 0){
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        waitTime = startWaitTime;

      } else { 
        waitTime -= Time.deltaTime;
        
      }
       
      

        
    }

  }
}
