using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{

    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class AmmoChange : UnityEvent { }
    [System.Serializable] public class PlayerObjectileWasDestroyed : UnityEvent { }
    [System.Serializable] public class HealthChange : UnityEvent { }
    [System.Serializable] public class Overheal : UnityEvent { }
    [System.Serializable] public class BossSpawm : UnityEvent { }

}
