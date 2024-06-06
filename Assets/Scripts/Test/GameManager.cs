using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject CardSlotPrefab;
    [SerializeField] private GameObject BoardPrefab;
    void Start()
    {
        CreateGameWorld();
    }

    void Update()
    {
        
    }

    public void CreateGameWorld()
    {
        var board = Instantiate(BoardPrefab, null);
        var cardSlots = new List<GameObject>();
        for(int i = 0; i < 64; i ++)
        {
            cardSlots.Add(Instantiate(CardSlotPrefab, null));
        }

        board.GetComponent<Board>().AssignCardSlots(cardSlots);
    }
}
