using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isMoving;
    [SerializeField] private Vector2 input;
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask DoorLayer;
    [SerializeField] LayerMask NPCLayer;
    [SerializeField] private GameObject doorLocation;
    [SerializeField] private bool doorWasTouched;
    [SerializeField] static bool npcWasTouched;
    [SerializeField] static bool limitedMovment;
    public static bool movedAfterStore;


    private Animator animatorController;
    [SerializeField] private Animator[] clothesAnimatorController;

    private void Awake()
    {
        animatorController = GetComponent<Animator>();
        //clothesAnimatorController = GameObject.Find("Clothes").GetComponent<Animator>();
        doorWasTouched = false;
        npcWasTouched = false;
        limitedMovment = false;
        movedAfterStore = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                
                animatorController.SetFloat("moveX", input.x);
                animatorController.SetFloat("moveY", input.y);
                for (int i = 0; i < clothesAnimatorController.Length; i++)
                {
                    clothesAnimatorController[i].SetFloat("moveX", input.x);
                    clothesAnimatorController[i].SetFloat("moveY", input.y);
                }
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

            if(!limitedMovment)
                if (isDoor(targetPos))
                    if (isWalkable(targetPos))
                        StartCoroutine(Move(targetPos));
            }
        }
        animatorController.SetBool("isMoving", isMoving);
        for (int i = 0; i < clothesAnimatorController.Length; i++)
        {
            clothesAnimatorController[i].SetBool("isMoving", isMoving);
        }


        if (doorWasTouched)
            transform.position = Vector3.MoveTowards(transform.position, doorLocation.transform.position, 1f * Time.deltaTime);

        isNPC();
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        movedAfterStore = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos,0.3f,solidObjectsLayer)!= null)
        {
            return false;
        }
        return true;
    }
    private bool isDoor(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.001f, DoorLayer) != null)
        {
            doorWasTouched = true;
            isMoving = true;
            StartCoroutine(FadeTo(0f, 2f));
            return false;
        }
        return true;
    }
   private void isNPC()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.001f, NPCLayer) != null)
        {
            npcWasTouched = true;          
        }
        else
        {
            npcWasTouched = false;
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Store");
    }

    public static bool GetNpcWasTouched()
    {
        return npcWasTouched;
    }
    public static void changeLimitMovmentStatus(bool state)
    {
        limitedMovment = state;
    }
}
