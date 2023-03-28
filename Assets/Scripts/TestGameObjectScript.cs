using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameObjectScript : MonoBehaviour
{ 
    public class Wizard
    {
        public string name;
        public string theSpellUsed;//�������������� ����������
        public string theDesiredSpell;//�������� ����������
        public int birdHeads;//������
        public float expirience;//������������� ��� ������� ������� � ������������� ����������
        public int spellSlots;// ���������� ������ ����������

        public Wizard(string name, int spellSlots, int birdHeads)// ����������� ���������� �� ����� ������ � ����������
        {
            this.name = name;
            this.spellSlots = spellSlots;
            this.birdHeads = birdHeads;
        }

        public Wizard(int spellSlots, int birdHeads, float expirience)// ����������� ���������� �� ����� ������ � ������� ���������� 
        {
            this.spellSlots = spellSlots;
            this.birdHeads = birdHeads;
            this.expirience = expirience;
        }

        public Wizard(int spellSlots, float expirience)// ����������� ���������� �� ����� ������ � ������������� ���������� 
        {
            this.spellSlots = spellSlots;
            this.expirience= expirience;
        }

        public void CastSpell()//������ ���������� 
        {
            if (spellSlots > 0)
            {
                spellSlots--;
                expirience += 0.3f;
            }

        }

        public void PurchaseOfProducts()//������� �������
        {
            if (birdHeads > 0)
            {
                birdHeads--;
                spellSlots--;
                expirience += 0.1f;              
            }
        }
    }

    public class SpellShop
    {
        public string firstProduct;
        public string secondProduct;
        public string thirdProduct;

        public float priceOnFirstProduct;
        public float priceOnSecondProduct;
        public float priceOnThirdProduct;


       
    }


    public Wizard wizard01 = new Wizard("Harry", 1, 1);

    private void Start()
    {
        
    }
   
    
}
