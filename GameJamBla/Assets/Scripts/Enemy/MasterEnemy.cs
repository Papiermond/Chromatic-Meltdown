using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEnemy : EnemyBase
{
    public enum BehaviourTypes
    {
        SimpleMove,
        VerticalMove,
        Gravity,
        Jumps,
        Patrol,
        VerticalSinusWobble,
        HorizontalSinusWobble,
        StickToGround
    }

    public List<BehaviourTypes> myBehaviours = new List<BehaviourTypes>();

    private void Awake()
    {
        foreach (var behave in myBehaviours)
        {
            switch (behave)
            {
                case BehaviourTypes.SimpleMove:
                    Behaviour += SimpleMove;
                    break;
                case BehaviourTypes.VerticalMove:
                    Behaviour += VerticalMovement;
                    break;
                case BehaviourTypes.Gravity:
                    Behaviour += FallToGravity;
                    break;
                case BehaviourTypes.Jumps:
                    Behaviour += Jump;
                    break;
                case BehaviourTypes.Patrol:
                    Behaviour += ChangeMoveDir;
                    break;
                case BehaviourTypes.VerticalSinusWobble:
                    Behaviour += SinusVerticalWobble;
                    break;
                case BehaviourTypes.HorizontalSinusWobble:
                    Behaviour += SinusHorizontalWobble;
                    break;
                case BehaviourTypes.StickToGround:
                    Behaviour += StickToGround;
                    break;
                default:
                    break; 
            }
        }
    }
}
