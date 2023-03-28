using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLevelArray : MonoBehaviour
{
    /*
     данный кодовый файл будет содержать три массива(может быть больше исход€ из того, сколько будет видов уровней в игре). 
     ѕока реализован только один.  аждый массив будет содержать в себе перфабф уровней, характерные дл€ конкретного вида уровней.
     Ёлементы (префабы GameObject'ов) из данных массивов будут присваиватьс€ в другие массивы, характерные дл€ их видов уровней.
     */


    public List<GameObject> PrefabLevelArrayForSimpleLevel = new List<GameObject>();

    public List<GameObject> PrefabLevelArrayForLimitedTimeLevel = new List<GameObject>();

    public List<GameObject> PrefabLevelArrayForHardLevel = new List<GameObject>();

    public static bool isActivateAssignment = false; //переменна€, котора€ говорит о том, присвоились ли префабы из массивов на главном уровне в статические массивы префабов уровней


    void Start()
    {
        
        if (!isActivateAssignment)
        {
            PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel = PrefabLevelArrayForSimpleLevel;
            PullPrefabLevelArray.instance.PullPrefabLevelForLimitedTimeLevel = PrefabLevelArrayForLimitedTimeLevel;
            PullPrefabLevelArray.instance.PullPrefabLevelForForHardLevel = PrefabLevelArrayForHardLevel;
            isActivateAssignment = true;
        }
        else
        {
            PrefabLevelArrayForSimpleLevel = PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel;
            PrefabLevelArrayForLimitedTimeLevel = PullPrefabLevelArray.instance.PullPrefabLevelForLimitedTimeLevel;
            PrefabLevelArrayForHardLevel = PullPrefabLevelArray.instance.PullPrefabLevelForForHardLevel;
        }

        Debug.Log("isActivateAssignment: " + isActivateAssignment);
        //Debug.Log("¬ режиме меню " + PullPrefabLevelArray.instance.PullPrefabLevelForSimpleLevel.Count);

    }
}
