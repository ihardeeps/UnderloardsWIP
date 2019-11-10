using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public override void Init()
    {
        base.Init();
        type = Type.PLAYER;
    }
}
