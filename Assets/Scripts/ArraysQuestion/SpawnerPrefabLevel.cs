using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnerPrefabLevel : MonoBehaviour
{
    /*
    Данный скрипт не закреплён ни к какому объекту. Он содержит метод, который вызывается у класса наследника Spawner. 
    Данный метод содержит в себе два параметра. Первый параметр – динамический список который отвечает за добавление на сцену префаба уровня. 
    Второй параметр – динамический список, который является ссылкой между массивом префабов в главном меню и в самом уровне(первый параметр) 
    и который добавляет единственный префаб уровня в массив, который находится в самом уровне(первый параметр).
     */

    //public List<GameObject> PrefabQuestionList = new List<GameObject>(); //PrefabQuestionList == CloneQuestionsList

    //private void Awake()
    //{

    //}   

    public static GameObject prefabLevel;
    protected void Spawn(List<GameObject> PrefabQuestionList, List<GameObject> PullPrefabLevel)
    {
        //mainObject = GameObject.FindGameObjectWithTag("MainObject");
        
        int randomQuestion;

        //цикл ниже отработает 10 раз и он позволит заполнить список QuestionList уникальными элементами в рандомном порядке, отличающихся друг от друга.
        for (int i = 0; i < 1; i++)
        {
            do
            {
                randomQuestion = Random.Range(0, PullPrefabLevel.Count);//в переменную randomQuestion присваиваем рандомное значение от 0 до всей длины списка
            }
            while (PrefabQuestionList.Contains(PullPrefabLevel[randomQuestion]));//метод Contains() вернёт true в том случае, если список имеет определённый элемент (индекс которого равен значению переменной randomQuestion)
            {
                PrefabQuestionList.Add(PullPrefabLevel[randomQuestion]);
            }
            prefabLevel = PullPrefabLevel[randomQuestion];
            Debug.Log("PullPrefabLevel: " + prefabLevel);
        }

        for (int i = 0; i < 1; i++)
        {
            Instantiate(PrefabQuestionList[0]);//при помощи цикл создаём объект на сцене
        }



        Debug.Log("КОличество элементов в листе QuestionList: " + PrefabQuestionList.Count);
    }
}
