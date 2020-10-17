using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    private float _speed = 4.0f;
    private Rigidbody2D _rigid;
    private PlayerAnimations _anim;
    private float _JumpForce = 5f;

    public bool resetJumpNeeded = true;
    [SerializeField]
    public bool _resetJump;
    [SerializeField]
    private LayerMask _groundLayer;
    private SpriteRenderer _sprite;
 


    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimations>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
    }
 
    void Movement()
    {
        float upDown = Input.GetAxisRaw("Vertical");
        float move = Input.GetAxisRaw("Horizontal");
        if(move > 0)
        {
            _sprite.flipX = false;
        }else if(move < 0)
        {
            _sprite.flipX = true;
        }



        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
        {


            Debug.Log("jump");
            _rigid.velocity = new Vector2(move * _speed, _JumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _anim.Move(move);
    }
    bool isGrounded()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer);

        if (hitInfo.collider != null)
        {
            Debug.Log(hitInfo.collider.name + "hitinfo.collider is not null should return true and fire jump");
            return true;
        }
        Debug.Log("false");
        return false;
    }
    IEnumerator ResetJumpRoutine()
    {

        _resetJump = true;
        yield return new WaitForSeconds(3f);
        _resetJump = false;
    }
   

}