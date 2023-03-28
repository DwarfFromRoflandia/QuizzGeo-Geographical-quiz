using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchQuestion : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;

    public List<GameObject> QuestionsList = new List<GameObject>(); //массив, элементы которого инициализируем в инспекторе, хранит префабы вопросов 

    private List<GameObject> CloneQuestionsList = new List<GameObject>(); //массив, хранящий элементы рандомного порядка определённого количества префабов вопросов

    public List<GameObject> RandomCloneQuestionsList = new List<GameObject>(); //массив, хранящий клонов префабов вопросов в том же порядке и того же количесвта, что и массив CloneQuestionsList

    public static GameObject TestGameObject;

    public GameObject mainGameObject;

    public int countQuestion;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            RandomCloneQuestionsList.Add(Instantiate(CloneQuestionsList[i], mainGameObject.transform));
        }


        resultPanel.SetActive(false);
    }

    private void Awake()
    {
        int randomQuestion;

        for (int i = 0; i < 10; i++)
        {
            do
            {
                randomQuestion = Random.Range(0, QuestionsList.Count);
            }
            while (CloneQuestionsList.Contains(QuestionsList[randomQuestion]));
            {           
                CloneQuestionsList.Add(QuestionsList[randomQuestion]);
            }
           
        }
    }
    private void Update()
    {
        SwitchQuestions(countQuestion);
    }

    private void SwitchQuestions(int _countQuestion)
    {
        for (int i = 0; i < 10; i++)
        {
            switch (_countQuestion)
            {
                case 0:
                    RandomCloneQuestionsList[0].SetActive(true);
                    break;
                case 1:
                    RandomCloneQuestionsList[0].SetActive(false);
                    RandomCloneQuestionsList[1].SetActive(true);
                    break;
                case 2:
                    RandomCloneQuestionsList[1].SetActive(false);
                    RandomCloneQuestionsList[2].SetActive(true);
                    break;
                case 3:
                    RandomCloneQuestionsList[2].SetActive(false);
                    RandomCloneQuestionsList[3].SetActive(true);
                    break;
                case 4:
                    RandomCloneQuestionsList[3].SetActive(false);
                    RandomCloneQuestionsList[4].SetActive(true);
                    break;
                case 5:
                    RandomCloneQuestionsList[4].SetActive(false);
                    RandomCloneQuestionsList[5].SetActive(true);
                    break;
                case 6:
                    RandomCloneQuestionsList[5].SetActive(false);
                    RandomCloneQuestionsList[6].SetActive(true);
                    break;
                case 7:
                    RandomCloneQuestionsList[6].SetActive(false);
                    RandomCloneQuestionsList[7].SetActive(true);
                    break;
                case 8:
                    RandomCloneQuestionsList[7].SetActive(false);
                    RandomCloneQuestionsList[8].SetActive(true);
                    break;
                case 9:
                    RandomCloneQuestionsList[8].SetActive(false);
                    RandomCloneQuestionsList[9].SetActive(true);
                    break;
                case 10:
                    RandomCloneQuestionsList[9].SetActive(true);
                    resultPanel.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
