using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineManager : MonoBehaviour
{
    [SerializeField] private bool fix = false;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private MonoBehaviour PlayerInput;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject up;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private Rigidbody2D rb;

    public void Start()
    {
        Vector3 newPosition = new Vector3(0.86f, 0.5f, 0f);
        PlayerInput.enabled = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if(director.state != PlayState.Playing && !fix)
        {
            fix = true;
            PlayerInput.enabled = true;
            Vector3 newPosition = new Vector3(0.86f, 0.5f, 0f);

            up.SetActive(false);
            down.SetActive(false);
            scoreText.SetActive(true);
            player.position = newPosition;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
