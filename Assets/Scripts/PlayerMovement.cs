using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //Player
    [Header("Player Properties")]
    public float playerSpeed;
    public float gravity;
    public float laneChangeSpeed;

    private CharacterController _controller;
    private Vector3 _velocity;

    //Lane
    [Header("Lane Properties")]
    public float laneWidth;
    private int _laneIndex = 0;
    
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        //Gathering input & changing lane index
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_laneIndex == 0 || _laneIndex == 1)
            {
                _laneIndex--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_laneIndex == 0 || _laneIndex == -1)
            {
                _laneIndex++;
            }
        }
        
        //Movement

        //Constant running
        _velocity.z = playerSpeed;

        //Vertical
        _velocity.y += gravity;
        
        Vector3 moveAmount = _velocity * Time.deltaTime;
        //Horizontal
        float targetX = _laneIndex * laneWidth;
        float dirX = Mathf.Sign(targetX - transform.position.x); //1 / -1 
        float deltaX = laneChangeSpeed * dirX * Time.deltaTime;
        
        //Fixing lane syncing bug (not my code)
        if (Mathf.Sign(targetX - (transform.position.x + deltaX)) != dirX) {
            float overshoot = targetX - (transform.position.x + deltaX);
            deltaX += overshoot;
        }
        
        moveAmount.x = deltaX;
        _controller.Move(moveAmount);
    }
}
