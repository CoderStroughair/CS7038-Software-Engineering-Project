using UnityEngine;
using System.Collections;

public sealed class Free : State<Agent>
{

    static readonly Free instance = new Free();

    public static Free Instance
    {
        get
        {
            return instance;
        }
    }

    static Free() { }
    private Free() { }

    public override void Enter(Agent agent)
    {
        Debug.Log("wooo hoo !!! freedom...");
    }

    public override void Execute(Agent agent)
    {
        Debug.Log("having a beer...");
        //drunk state?

        //agent.ChangeState(Free.Instance);
    }

    public override void Exit(Agent agent)
    {
        Debug.Log("...");
    }
}
