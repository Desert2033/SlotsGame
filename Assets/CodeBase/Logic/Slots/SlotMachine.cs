using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

[Serializable]
public class SlotLine
{
    public Slot[] Slots = new Slot[Constants.MaxSlots];
}

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private List<SlotLine> _slotsView;
    [SerializeField] private ReelAnimator[] _reelAnimators;

    private Slot[][] _winSlots;

    public List<SlotLine> SlotsView => _slotsView;

    public void SpinAnimation(int[,] slots)
    {
        FillSlots(slots);
        Role();
    }

    public void FillSlots(int[,] slots)
    {
        for (int i = 0; i < Constants.MaxLines; i++)
        {
            for (int t = 0; t < Constants.MaxSlots; t++)
            {
                int slotId = slots[i, t];

                _slotsView[i].Slots[t].SetItem(slotId);
            }
        }
    }

    public void SetWinSlots(Slot[][] winSlots)
    {
        _winSlots = winSlots;
    }

    private void Role()
    {
        foreach (ReelAnimator reel in _reelAnimators)
        {
            reel.StartRole(ActiveWinSlots);
        }
    }

    private void ActiveWinSlots()
    {
        if (_winSlots == null)
            return;

        foreach (Slot[] slots in _winSlots)
        {
            if (slots != null)
            {
                foreach (Slot slot in slots)
                {
                    slot.ActiveWin();
                }
            }
        }

        _winSlots = null;
    }
}
