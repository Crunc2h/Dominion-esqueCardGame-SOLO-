using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<CardSlot> CardSlots = new List<CardSlot>();
    private List<(int X, int Z)> SlotPositions = new List<(int X, int Z)>();

    public void Awake()
    {
        CreateSlotPositions((8, 8), 5);
    }

    public void AssignCardSlots(List<GameObject> cardSlots)
    {
        for (int i = 0; i < cardSlots.Count; i++)
        {
            cardSlots[i].transform.SetParent(transform, false);
            cardSlots[i].transform.position = new Vector3(SlotPositions[i].X, cardSlots[i].transform.position.y, SlotPositions[i].Z);
            
            cardSlots[i].GetComponent<CardSlot>().Id = i;
            cardSlots[i].GetComponent<CardSlot>().CoordX = SlotPositions[i].X;
            cardSlots[i].GetComponent<CardSlot>().CoordX = SlotPositions[i].Z;
        }
    }

    public void CreateSlotPositions((int boardLengthX, int boardLengthZ) boardInfo, int stepLength)
    {
        int currentZ = 0;
        
        for (int i = 0; i < boardInfo.boardLengthZ; i++)
        {
            int currentX = 0;
            
            for (int j = 0; j < boardInfo.boardLengthX; j++)
            {
                SlotPositions.Add((currentX, currentZ));
                currentX += stepLength;
            }
            
            currentZ += stepLength;
        }
    }
}
