using System;
using System.Collections.Generic;

public interface ICombinationService : IService
{
    Slot[][] CalculateWinSlots(List<SlotLine> _slotGrid);
}