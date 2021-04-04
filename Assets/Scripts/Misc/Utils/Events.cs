using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{

    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class MaxAmmoIncrease : UnityEvent<int> { }
    [System.Serializable] public class PlayerHasShot : UnityEvent { }
    [System.Serializable] public class PlayerObjectileWasDestroyed : UnityEvent { }

}
