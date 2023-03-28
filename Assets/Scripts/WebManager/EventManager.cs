using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
   public static UnityEvent<List<GameObject>> RemovePrefabSimpleLevelEvent = new UnityEvent<List<GameObject>>();
   public static UnityEvent<List<GameObject>> RemovePrefabHardLevelEvent = new UnityEvent<List<GameObject>>();
   public static UnityEvent<List<GameObject>> RemovePrefabLimitedTimeLevelEvent = new UnityEvent<List<GameObject>>();
   public static UnityEvent SaveDataForDataBaseEvent = new UnityEvent();
   public static UnityEvent<int> ChangeQuantityScoreEvent = new UnityEvent<int>();
}
