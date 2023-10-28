using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
// Class that makes the clothes follow the player 
/// </summary>
public class FollowGameObject : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject _objectToFollow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followMethod(this.gameObject, _objectToFollow);
    }

    void followMethod(GameObject follower, GameObject followed)
    {
        if(follower.gameObject.tag == "tops")
        {
           follower.transform.position = new Vector2(followed.transform.position.x + 0.015f, followed.transform.position.y - 0.082f);
        }
        else if(follower.gameObject.tag == "legs")
        {
            follower.transform.position = new Vector2(followed.transform.position.x - 0.0267f, followed.transform.position.y - 0.288f);
        }
        else
        follower.transform.position = new Vector2 (followed.transform.position.x, followed.transform.position.y - 0.211f);
    }
}
