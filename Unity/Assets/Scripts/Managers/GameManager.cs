using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public bool Turn;
    
    private void OnServerInitialized()
    {
        if (!isServer) return;
    }
}
