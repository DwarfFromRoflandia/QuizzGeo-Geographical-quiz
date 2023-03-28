using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�����, ������� ������� �����������, ��� ����������� ������ ������� � ��������: https://www.youtube.com/watch?v=tCr_i5CVv_w&t=4s � https://www.youtube.com/watch?v=rjFgThTjLso


//������ �� ������ MonoBehaviour, �� ����� �������������� ��� �� ���� �������: IDragHandler � IEndDragHandler
public class PageSwaperLevelSelected : MonoBehaviour, IDragHandler, IEndDragHandler //��� ��� ������ ��������� ������������ ������, ������� ����� ��� ����������� ����, ����� �������������� ������(�����) ���������� � ����� ��� �������������
{
    private Vector3 panelLocation;//����������, ������� ����� �������������� ��� ���������� �������� ��������� ��������(��������� Idle) ����� ������
    public float precentThreshold = 0.2f;//��� ���������� ����� ��� ����, ����� ���������� ��������� ������ � ������ ��� ����� ��������� �� ������, ����� ��� ��������� �������
    public float easing = 0.5f;//�� ����� ������������ ��� ���������� ��� ����, ����� ����������, ��� ����� � �������� ������ ����� ������������ � ������ �����

    public int totalPages = 1;//����������, ���������� �� ��, ������� ����� ������� � �������� � ��� �����.
    private int currentPage = 1;//����������, ������� ��������� ������� ������, �� ������� ��������� �����

    public GameObject[] _Pointers;

    private void Start()
    {
        panelLocation = transform.position;//���������� ������� ���� ������������� � ����������, ������� �������� �� �������������� ������ � ��������, ������� �������� �������
    }

    //���� ���������� �����, ������� ���������� ������ �������� � ������ IDragHandler
    public void OnDrag(PointerEventData data) //����� ���������� data �������� ������ ���������� � ����� ��������������
    {
        float difference = data.pressPosition.x - data.position.x; //���������� ������� ����� ���������� ������� ������� �������������� � ������ ������ ��������������

        transform.position = panelLocation - new Vector3(difference, 0, 0); //���� �������� �� �������� �������������� ������ � ������ ��������(��������� Idle) �� ����������, ������� �� �������������
    }

    //���� ���������� �����, ������� ���������� ������ �������� � ������ IEndDragHandler
    public void OnEndDrag(PointerEventData data)
    {
        //�������� ���� �� ������������ �������, ������� �� ������� �� ��������� � ������ ������(�.�. �� ���� ������� ����� ���������� ������� ������� �������������� � ������ ������ �������������� � ����� � �� ������ ������)
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;//������, ���� �� ������� ������� ������ ������, �� �������� ����� �������������, � ���� ������� ������� ����� �������, �� �������� ����� �������������

        //���� �������� ���������, ���� ���������� ������� ������ ��� ����� ������������ ��������, �� �� ����� ������� ��� ��������� ��������(������). � ������� �� ���������� �������������� �������, ����� �������� ���������� ��������, ������� ��� �� ����� ������ ��������� ���������� if 
        if (Mathf.Abs(percentage) >= precentThreshold)//���� ���� ���������� �������� �������������, �� �� ����� ��������� ����� �������������� ��� ����������� ����� ������
        {
            Vector3 newLocation = panelLocation;//���������� ����� ��������� �������������� � ������������� ��� ������ ������ ��������� ��������, ������� ������������, ��� �������������� ������
            if (percentage > 0 && currentPage < totalPages)//���� �������� ����������, ��� ���� �� ������� ������� ������ �����������, �� ����������� ������ ��������, � ��� �������� �������� currentPage < totalPages ��� �����������, ��� �� �� �������� ������ ������� �������, ���� �� ��������� �� ��������� �������� ��������
            {
                newLocation += new Vector3(-Screen.width, 0,0);//���� ������� �����������, �� �� ������������� ��� ������ ������ �������������� �������� + � ������ ������ ������� 3 � ��������� ������������� ������ ����� ������ ��� �������� x, � ����� ������� ��� �������� 
                currentPage++;//��������� ����� ���������� �� ����� ����������� �� ����� �������� �� ���������
            }
            else if(percentage < 0 && currentPage > 1)//���� �������� ����������, ��� ���� �� ������� ������� ������� �����������, �� ����������� ���������� ��������, � ��� �������� currentPage > 1 �� �������� ������ ��� ��������� ������� �������, ���� �� ��������� �� ������ ��������
            {
                newLocation += new Vector3(Screen.width, 0, 0);
                currentPage--;//��������� ����� ���������� �� ����� ����������� �� ����� �������� �� ���������
            }

            StartCoroutine(SmoothMove(transform.position, newLocation, easing));//��� ������� ��������� �������� � ��� �������� �� ��������� ����������� ������ � ������ ��� �����. ����� ��� ������� ��������� ������� �������� ���� �������
            panelLocation = newLocation;//��������� ��������� ��������(��������� Idle) �� ����� ������ ��������������. 


            for (int i = 0; i < _Pointers.Length; i++)//���������� ���������� ������˨���� �������� �� ������� ��������� �����
            {
                if (currentPage == 1)
                {
                    _Pointers[3].SetActive(true);
                    _Pointers[4].SetActive(false);
                    _Pointers[5].SetActive(false);
                }
                else if (currentPage == 2)
                {
                    _Pointers[3].SetActive(false);
                    _Pointers[4].SetActive(true);
                    _Pointers[5].SetActive(false);
                }
                else if(currentPage == 3)
                {
                    _Pointers[3].SetActive(false);
                    _Pointers[4].SetActive(false);
                    _Pointers[5].SetActive(true);
                }
            }
        
        
        }
        else//��� ������� ����� ��� ����, ����� ���� ������ � �������� ��������� � �������� ���������, ���� �� �� ������� ������� ���� ������ ������ ������� 
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));//��� ������� ��������� �������� � ��� �������� �� ��������� ����������� ������ � ������ ��� �����. ����� ��� ������� ��������� ������� �������� �������������� ������, ��� �������� �������� ���������� ��������(��������� Idle)
        }

    }
  
    //���� ����� ��� ����� ��� ����, ����� � ��� ��� ������� � ������ ������� ����� ��������. ���� ����� �������� ����������� ������� ������ �� ����������� ������� � n-������� �� ����������� ���������� ������, ������� �� ���������� � ���� ������
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)//������� � ����� ��� ���������
    {
        float t = 0f;
        while (t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            //����� �� ���������� ��������, ������� ������������ �� ���� �������, ������� ����� ��������� � ���������� �������(������) ����. ��� ����� �������, ������ ��� �� ����� ����������� ������� �������� �� ����� A � ����� B
            yield return null;//�.�. ���� �������� �� �������, ��� �� �����, ����� ��� ����� �������� ���������� �����(������), ������ ��� ���������
        }
    }
}