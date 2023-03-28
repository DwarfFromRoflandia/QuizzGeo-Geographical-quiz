using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class BackToLevelSelected : MonoBehaviour
{
    public int levelToUnlock;//переменная, которая будет использоваться для того, чтобы разблокировать следующий уровень
    public bool isRemoveArrayElement = false;


    private void Update()
    {
        TransferValueLevelToUnlock.valueLevelToUnlock = levelToUnlock;
    }

    private void Start()
    {
        EventManager.RemovePrefabSimpleLevelEvent.AddListener(RemoveAnElementFromPullPrefabLevelForSimpleLevel);
        EventManager.RemovePrefabLimitedTimeLevelEvent.AddListener(RemoveAnElementFromPullPrefabLevelForLimitedTimeLevel);
        EventManager.RemovePrefabHardLevelEvent.AddListener(RemoveAnElementFromPullPrefabLevelForForHardLevel);
    }
    public void BackToMenu()
    {
        isRemoveArrayElement = true;

        SceneManager.LoadScene(0);
        PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel.Remove(SpawnerPrefabLevel.prefabLevel);
        //Debug.Log("В режиме игры " + PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel.Count);
        Debug.Log("Количесвто звёзд в меню выбора уровней: " + TransferStars.transferStras);
        levelToUnlock++;//делаем инкремент данной переменной для того, чтобы когда игрок зайдёт в меню выбора уровня, ему был доступен следующий уровень
    }

    public void RemoveAnElementFromPullPrefabLevelForSimpleLevel(List<GameObject> PullPrefabLevel)                                                              
    {
        if (isRemoveArrayElement)
        {
            PullPrefabLevel.Remove(SpawnerPrefabLevel.prefabLevel);
        }
    }

    public void RemoveAnElementFromPullPrefabLevelForLimitedTimeLevel(List<GameObject> PullPrefabLevel)
    {
        if (isRemoveArrayElement)
        {
            PullPrefabLevel.Remove(SpawnerPrefabLevel.prefabLevel);
        }
    }

    public void RemoveAnElementFromPullPrefabLevelForForHardLevel(List<GameObject> PullPrefabLevel)
    {
        if (isRemoveArrayElement)
        {
            PullPrefabLevel.Remove(SpawnerPrefabLevel.prefabLevel);
        }
    }

    private void OnEnable()
    {
        if (TransferValueLevelToUnlock.valueLevelToUnlock != 0)
        {
            levelToUnlock = TransferValueLevelToUnlock.valueLevelToUnlock;
        }
    }
    private void OnDestroy()
    {
        TransferValueLevelToUnlock.valueLevelToUnlock = levelToUnlock;
    }
}
