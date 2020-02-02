using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    PlayerHealth health;
    Bounds spriteBounds;
    Vector3 extents;
    float speed;
    float unitsAwayFromCamera;
    Vector3 direction;
    Vector3 rightDim;
    Vector3 leftDim;

    // Start is called before the first frame update
    public virtual void Start()
    {
        health = new PlayerHealth();

        //get sprite bounds
        spriteBounds = GetComponent<SpriteRenderer>().sprite.bounds;
        //get sprite extents
        extents = GetComponent<SpriteRenderer>().sprite.bounds.extents;
        //get camera bounds
        rightDim = Camera.main.ViewportToWorldPoint(new Vector3(1,1,unitsAwayFromCamera));
        leftDim = Camera.main.ViewportToWorldPoint(new Vector3(0,0,unitsAwayFromCamera));
        //set the speed and direction
        speed = 15.0f;
        direction = Vector3.zero;
        unitsAwayFromCamera = Mathf.Abs(Camera.main.transform.position.z) + Mathf.Abs(transform.position.z);
        //set the position to the center of the screen
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, unitsAwayFromCamera));
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            direction = Vector3.up;
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            direction = Vector3.down;
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
            direction = Vector3.left;
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            direction = Vector3.right;
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }

        //are we touching the wall?
        //collision detection
        //y
        if(transform.position.y + spriteBounds.size.y/2 >= rightDim.y){
            transform.position = new Vector3(transform.position.x, rightDim.y-spriteBounds.size.y/2, transform.position.z);
        }
        //-y
        if(transform.position.y - spriteBounds.size.y/2 <= leftDim.y){
            transform.position = new Vector3(transform.position.x, leftDim.y+spriteBounds.size.y/2, transform.position.z);
        }
        //x
        if(transform.position.x + spriteBounds.size.x/2 >= rightDim.x){
            transform.position = new Vector3(rightDim.x-spriteBounds.size.x/2, transform.position.y, transform.position.z);
        }
        //-x
        if(transform.position.x - spriteBounds.size.x/2 <= leftDim.x){
            transform.position = new Vector3(leftDim.x+spriteBounds.size.x/2, transform.position.y, transform.position.z);
        }

        Debug.Log("Health: " + health.health());


        //collision detection for balls
        
        //for each death circle
        GameObject[] threats = GameObject.FindGameObjectsWithTag("DeathBall");
        Debug.Log(threats.Length);
        foreach(GameObject threat in threats){
            //check if distance < combined radii
            float r = threat.GetComponent<Bounce>().GetRadius();
            float min_dist = extents.x + r;

            Vector3 distv = transform.position - threat.transform.position;
            float dist = distv.magnitude;

            Debug.Log(dist);

            if(dist < min_dist){
                //if hit lose a life (check if invincibility is enabled)
                if(GetComponent<Invincibility>().enabled == false){
                    health.loseLife();
                    Camera.main.GetComponent<CameraShake>().enabled = true;
                }
                //invincibility frames
                GetComponent<Invincibility>().enabled = true;
                Debug.Log("Health: " + health.health());
                //if life is at zero, then end game
                if(health.health() <= 0){
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    #else
                        Application.Quit();
                    #endif
                }
            }

        }
        direction = Vector3.zero;
    }
}
