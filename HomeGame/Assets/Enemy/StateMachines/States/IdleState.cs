using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    protected D_IdleState statedata;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    protected float idleTime;
    public IdleState(FiniteStateMachine statemachine, Entity entity, string animBoolName, D_IdleState statedata) : base(statemachine, entity, animBoolName)
    {
        this.statedata = statedata;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void setFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime()
    { 
        idleTime = Random.Range(statedata.minIdleTime, statedata.maxIdleTime);
    }
}
