using UnityEngine;

public class Entity : MonoBehaviour
{

    public FiniteStateMachine stateMachine;

    public D_Entity entityData;

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }

    public int facingDirection { get; private set; }

    private Vector2 velocityWorkspace;

    [SerializeField] private Transform wallCheck;

    [SerializeField] private Transform ledgeCheck;

    [SerializeField] private Transform playerCheck;

    public virtual void Start()
    {
        facingDirection = 1;

        //print(aliveGO);
        aliveGO = transform.Find("Alive").gameObject;
        //print(aliveGO);

        rb = aliveGO.GetComponent<Rigidbody2D>();
        //print(rb);
        anim = aliveGO.GetComponent<Animator>();
        //print(anim);

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        //print(aliveGO);
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    } 

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
<<<<<<< HEAD
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(entityData.wallCheckDistance * facingDirection * Vector2.right));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
=======
        if (gameObject != null)
        {
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(entityData.wallCheckDistance * facingDirection * Vector2.right));
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
        }
>>>>>>> parent of d27fbe0 (sdfghjkl)
    }
}
