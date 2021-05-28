using Ark;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solar : Generator
{
    public float dirt = 0;
    public float dirting_speed = 0.01f;

    private void FixedUpdate()
    {
        if (dirt < 1)
            dirt += Time.fixedDeltaTime * dirting_speed;
        else
            dirt = 1;
    }

    public override int Generate()
    {
        if (_working)
        {
            return Mathf.RoundToInt(_power * (1 - dirt));
        }
        return 0;
    }
}
