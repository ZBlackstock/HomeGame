using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected FiniteStateMachine statemachine;
    protected Entity entity;

    protected float startTime;

    protected string animBoolName;

    public EnemyState(FiniteStateMachine statemachine, Entity entity, string animBoolName)
    {
        this.statemachine = statemachine;
        this.entity = entity;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit() 
    {

        entity.anim.SetBool(animBoolName, false);
    
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
