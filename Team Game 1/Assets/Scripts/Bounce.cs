using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    Bounds spriteBounds;
    float unitsAwayFromCamera;
    float speed;
    Vector3 rightDim;
    Vector3 leftDim;
    Vector3 direction;

    public float GetRadius(){
        return spriteBounds.size.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        //this is to accurately get the size of the sprite in world
        spriteBounds = GetComponent<SpriteRenderer>().sprite.bounds;

        unitsAwayFromCamera = Mathf.Abs(Camera.main.transform.position.z) + Mathf.Abs(transform.position.z);
        rightDim = Camera.main.ViewportToWorldPoint(new Vector3(1,1,unitsAwayFromCamera));
        leftDim = Camera.main.ViewportToWorldPoint(new Vector3(0,0,unitsAwayFromCamera));

        //set a random direction & speed
        direction = new Vector3(Random.value, Random.value, transform.position.z);
        speed = Random.Range(10.0f, 15.0f);

        //place the sprite somewhere in the world randomly
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, unitsAwayFromCamera));

        Debug.Log(rightDim);
        Debug.Log(leftDim);
        Debug.Log(spriteBounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (direction * speed * Time.deltaTime);

        //collision detection
        //y
        if(transform.position.y + spriteBounds.size.y/2 >= rightDim.y){
            transform.position = new Vector3(transform.position.x, rightDim.y-spriteBounds.size.y/2, transform.position.z);
            direction = new Vector3(direction.x, -direction.y, transform.position.z);
        }
        //-y
        if(transform.position.y - spriteBounds.size.y/2 <= leftDim.y){
            transform.position = new Vector3(transform.position.x, leftDim.y+spriteBounds.size.y/2, transform.position.z);
            direction = new Vector3(direction.x, -direction.y, transform.position.z);
        }
        //x
        if(transform.position.x + spriteBounds.size.x/2 >= rightDim.x){
            transform.position = new Vector3(rightDim.x-spriteBounds.size.x/2, transform.position.y, transform.position.z);
            direction = new Vector3(-direction.x, direction.y, transform.position.z);
        }
        //-x
        if(transform.position.x - spriteBounds.size.x/2 <= leftDim.x){
            transform.position = new Vector3(leftDim.x+spriteBounds.size.x/2, transform.position.y, transform.position.z);
            direction = new Vector3(-direction.x, direction.y, transform.position.z);
        }
    }
}
