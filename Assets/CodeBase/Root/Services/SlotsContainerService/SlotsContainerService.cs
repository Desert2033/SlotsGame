using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlotsContainerService : ISlotsContainerService
{
    private int[,] _slotsGrid = new int[Constants.MaxLines, Constants.MaxSlots];

    public int[,] SlotsRespin()
    {
        for (int lineIndex = 0; lineIndex < Constants.MaxLines; lineIndex++)
        {
            for (int slotIndex = 0; slotIndex < Constants.MaxSlots; slotIndex++)
            {
                int slotId = Random.Range(Constants.MinSlotIndex, Constants.MaxSlotIndex + 1);

                _slotsGrid[lineIndex, slotIndex] = slotId;
            }
        }

        return _slotsGrid;
    }
}
