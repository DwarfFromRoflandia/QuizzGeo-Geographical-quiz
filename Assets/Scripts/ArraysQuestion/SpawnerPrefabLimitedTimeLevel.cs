using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPrefabLimitedTimeLevel : SpawnerPrefabLevel
{
    /*Данный скрипт наследуется от скрипта SpawnerPrefabLevel для того, 
     * чтобы иметь доступ к методу Spawn, который и был создан для этого метода. 
     * Содержит в себе массив с префабом уровня, который в последствии будет создан на сцене. 
     * Этот массив передаётся в параметр метода Spawn, вместе с ссылкой на массив с префабами из главного меню.
     */

    public List<GameObject> PrefabQuestionList = new List<GameObject>();

    private void Awake()
    {
        Spawn(PrefabQuestionList, PullPrefabLevelArray.instance.PullPrefabLevelForLimitedTimeLevel);
    }

    private void Update()
    {
        if (EventManager.RemovePrefabLimitedTimeLevelEvent != null)
        {
            EventManager.RemovePrefabLimitedTimeLevelEvent.Invoke(PullPrefabLevelArray.instance.PullPrefabLevelForLimitedTimeLevel);
        }
    }
}
