﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    public override void Init()
    {
        base.Init();
        type = Type.ENEMY;
    }
}
