using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //СОЗДАНИЕ СИНГЛТОНА
    //Синглтон(вообще все, которые мы можем создать, а не только этот) должен быть всего один и он не должен больше повторяться. Т.е. он должен быть всего один
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        
        //данная проверка нужна для того, что если мы создали два синглтона с наименованием GameManager, то первый(т.е. этот) GameManager будет оставаться, т.к. он  DontDestroy, а второй удалиться и работа программы не нарушится
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);//данная строчка позволяет не уничтожать GAmeManager, когда мы переходим на другие сцены
            return;
        }

        Destroy(this.gameObject);
    
    
    
    }

}
