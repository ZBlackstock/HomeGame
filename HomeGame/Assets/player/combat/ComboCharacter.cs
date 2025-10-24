using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComboCharacter : MonoBehaviour
{

    private StateMachine meleeStateMachine;
    public Animator animator;
    [SerializeField] public Collider2D hitbox;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            meleeStateMachine.SetNextState(new GroundEntryState());
        }
    }
}
