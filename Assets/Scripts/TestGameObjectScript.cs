using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameObjectScript : MonoBehaviour
{ 
    public class Wizard
    {
        public string name;
        public string theSpellUsed;//использованное заклинание
        public string theDesiredSpell;//желаемое заклинание
        public int birdHeads;//валюта
        public float expirience;//увеличивается при покупки товаров и использовании заклинания
        public int spellSlots;// количество слотов заклинания

        public Wizard(string name, int spellSlots, int birdHeads)// конструктор отвечающий за вывод данных о волшебнике
        {
            this.name = name;
            this.spellSlots = spellSlots;
            this.birdHeads = birdHeads;
        }

        public Wizard(int spellSlots, int birdHeads, float expirience)// конструктор отвечающий за вывод данных о покупке заклинаний 
        {
            this.spellSlots = spellSlots;
            this.birdHeads = birdHeads;
            this.expirience = expirience;
        }

        public Wizard(int spellSlots, float expirience)// конструктор отвечающий за вывод данных о использовании заклинаний 
        {
            this.spellSlots = spellSlots;
            this.expirience= expirience;
        }

        public void CastSpell()//вызвов заклинания 
        {
            if (spellSlots > 0)
            {
                spellSlots--;
                expirience += 0.3f;
            }

        }

        public void PurchaseOfProducts()//покупка товаров
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
