using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHitAction : MonoBehaviour 
{
    private AudioSource audioSource;
    private Animator animator;

    private static float PAUSE_SPEED = 0.0f;
    private static float DEFAULT_MOVE_SPEED = 3.0f;

    public float moveSpeed = 3f;
    public bool leftToRightDirection = true;

    private float borderOffset = 2f;
    private Rect border;

    private Vector3 pos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        pos = transform.position;
    }

    void Update()
    {
        if (transform.position.x + borderOffset <= border.x)
        {
            changeDirection();
        }

        if (transform.position.x + borderOffset >= border.width)
        {
            changeDirection();
        }

        pos += transform.right * Time.deltaTime * moveSpeed * (leftToRightDirection ? 1f : -1f);
        transform.position = pos;
    }

    public void changeDirection()
    {
        // flip sprite
        leftToRightDirection = !leftToRightDirection;

        Vector3 curLocalScale = transform.localScale;

        transform.localScale = new Vector3(
            leftToRightDirection ? Mathf.Abs(curLocalScale.x) : Mathf.Abs(curLocalScale.x) * -1, 
            curLocalScale.y, 
            curLocalScale.z
        );
    }

    public void hit()
    {
        bool isRunning = !animator.GetBool("Running");
        animator.SetBool("Running", isRunning);

        if (isRunning)
        {
            moveSpeed = DEFAULT_MOVE_SPEED;
        }
        else
        {
            transform.gameObject.SendMessage("changeDirection");
            moveSpeed = PAUSE_SPEED;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void setBorder(Rect rect)
    {
        border = rect;
    }
}
