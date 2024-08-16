using System;
using System.Collections.Generic;
using UnityEngine;

public class CombinationService : ICombinationService
{
    private const int CountSlotsToWin = 3;

    public Slot[][] CalculateWinSlots(List<SlotLine> _slotGrid)
    {
        Slot[][] winSlots = new Slot[Constants.MaxLines][];

        for (int i = 0; i < Constants.MaxLines; i++)
        {
            winSlots[i] = CalculateWinSlots(_slotGrid[i].Slots);
        }

        return winSlots;
    }

    private Slot[] CalculateWinSlots(Slot[] slots)
    {
        int combinationCount = 0;
        Slot[] winSlots = new Slot[CountSlotsToWin];

        if (IsAllSlotsWild(slots))
        {
            winSlots[0] = slots[0];
            winSlots[1] = slots[1];
            winSlots[2] = slots[2];

            return winSlots;
        }

        foreach (Slot currentSlot in slots)
        {
            foreach (Slot slot in slots)
            {
                if (IsEqualTwoSlots(currentSlot, slot))
                {
                    if (combinationCount < CountSlotsToWin)
                        winSlots[combinationCount] = slot;

                    combinationCount++;
                }
            }

            if (combinationCount >= CountSlotsToWin)
                return winSlots;
            else
                combinationCount = 0;
        }

        return null;
    }

    private bool IsAllSlotsWild(Slot[] slots)
    {
        int countWildSlots = 0;

        foreach (Slot slot in slots)
        {
            if (slot.SlotData.SlotType == SlotType.Wild)
            {
                countWildSlots++;
            }
        }

        if (countWildSlots == Constants.MaxSlots)
            return true;
        else
            return false;
    }

    private bool IsEqualTwoSlots(Slot currentSlot, Slot slot)
    {
        if (currentSlot.SlotData.SlotType != SlotType.Wild)
        {
            switch (slot.SlotData.SlotType)
            {
                case SlotType.Default:
                    if (currentSlot.SlotData.Id == slot.SlotData.Id)
                    {
                        return true;
                    }
                    break;
                case SlotType.Wild:
                    return true;
            }
        }

        return false;
    }
}
