using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    //10.5 small gap
    public GameObject PipeElement;
    private bool activated;
    private Vector2 origin;
    private Vector2 upBoundry;
    private Vector2 downBoundry;
    private bool moveUp = true;
    private float time;
    //-3.5 <> 1

    private void Start()
    {
        if (Random.Range(1, 101) > 70)
        {
            ActivateMove();
        }
    }

    private void Update()
    {
        if (activated)
        {
            time += Time.deltaTime;
            if (moveUp)//Up
            {
                transform.localPosition = Vector2.Lerp(transform.localPosition, origin + new Vector2(0, 2), time * 0.01f);
            }
            else//Down
            {
                transform.localPosition = Vector2.Lerp(transform.localPosition, origin - new Vector2(0, 2), time * 0.01f);
            }
            if (transform.localPosition.y > upBoundry.y - 0.2f)
            {
                moveUp = false;
                time = 0;
            }
            else if (transform.localPosition.y < downBoundry.y + 0.2f)
            {
                moveUp = true;
                time = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ScoreController>().AddScore();
        }
    }

    public void ActivateMove()
    {
        origin = transform.localPosition;
        upBoundry = origin + new Vector2(0, 2);
        downBoundry = origin + new Vector2(0, -2);
        activated = true;
    }
}
