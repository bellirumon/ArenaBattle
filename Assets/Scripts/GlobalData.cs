using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static Bounds ArenaBounds { get; private set; }

    public static Bounds NoSpawnRegion { get; private set; }

    public static void SetArenaBounds(Bounds bounds)
    {
        ArenaBounds = bounds;
    }

    public static void SetNoSpawnRegion(Bounds bounds)
    {
        NoSpawnRegion = bounds;
    }


}
