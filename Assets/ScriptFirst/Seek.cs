using UnityEngine;
using System.Collections;

public class Seek : AgentBehaviour {

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        steering.linear = target.transform.position - transform.position;
        steering.linear.Normalize();
        steering.linear = steering.linear * agent.maxAccel;
        return steering;
    }

}
/*
using System.Collections;
using UnityEngine;

    //public enum TargetEnum { ORE = 0, KEY = 1, HEALTH = 2 };

public class Seek : AgentBehaviour
{
    /*
    public TargetEnum curentEnum;
    GameObject[] _target;
    bool _switch;
    
    private void Start()
    {
        curentEnum = TargetEnum.ORE;
        _target = new GameObject[3];
        _target[0] = GameObject.FindGameObjectWithTag("Ore");
        _target[1] = GameObject.FindGameObjectWithTag("Key");
        _target[2] = GameObject.FindGameObjectWithTag("Health");
    }
    *//*
    public override Steering GetSteering()
    {
        
        TargetSwitch();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _switch = !_switch;
            if (_switch)
            {
                curentEnum = TargetEnum.HEALTH;
            }
            else
            {
                curentEnum = TargetEnum.KEY;
            }
            
        }
        
        Steering steering = new Steering();
        steering.linear = target.transform.position - transform.position;
        steering.linear.Normalize();
        steering.linear = steering.linear * agent.maxAccel;
        return steering;
    }

    
    void TargetSwitch()
    {
        switch(curentEnum)
        {
            case TargetEnum.ORE:
                target = _target[0];
                break;
            case TargetEnum.KEY:
                target = _target[1];
                break;
            case TargetEnum.HEALTH:
                target = _target[2];
                break;
        }
    }
    
}

*/