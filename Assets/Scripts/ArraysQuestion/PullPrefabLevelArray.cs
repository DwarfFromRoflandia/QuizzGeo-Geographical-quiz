using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPrefabLevelArray
{
    /*
     данный кодовый файл будет содержать три массива(может быть больше исход€ из того, сколько будет видов уровней в игре). 
     ѕока реализован только один.  аждый массив будет содержать в себе префабы уровней, характерные дл€ конкретного вида уровней.
     Ёлементы из кажого массива будут присваиватьс€ в массивы, которые содержатьс€ в уровн€х. “ем самым, благодар€ этому, в уровн€х
     будут по€вл€тьс€ в рандомном пор€дке префабы уровней в которых содержатс€ вопросы, характерные дл€ конкретного префаба.
     */


    public List<GameObject> PullPrefabLevelForSimpleLevel = new List<GameObject>();
    public List<GameObject> PullPrefabLevelForLimitedTimeLevel = new List<GameObject>();
    public List<GameObject> PullPrefabLevelForForHardLevel = new List<GameObject>();

    //используем паттерн —инглтон, который позволит передавать ссылку массивов в другие сцены (сцены с уровн€ми).
    public static PullPrefabLevelArray instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PullPrefabLevelArray();
            }
            return _instance;
        }
    }

    private static PullPrefabLevelArray _instance;
}
