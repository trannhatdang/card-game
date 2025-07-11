using System;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] List<GameObject> _cardsInHand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCard(int CardToPlay)
    {
        _cardsInHand.RemoveAt(CardToPlay);
    }

   public GameObject GetCard(int CardToGet) 
   {
    return _cardsInHand[CardToGet];
   }
   public void RemoveAt(int CardToRemvove)
   {
     _cardsInHand.RemoveAt(CardToRemvove);
   }
   public void AddCard(GameObject Card)
   {
    _cardsInHand.Add(Card);
   }
}
