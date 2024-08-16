using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private GameObject _lightImage;

    private SlotStaticData _slotData;
    private IStaticDataService _staticDataService;

    public SlotStaticData SlotData => _slotData;

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }

    public void SetItem(int slotId)
    {
        _slotData = _staticDataService.GetSlotDataById(slotId);

        ChangeData();
    }

    public void ActiveWin() => 
        _lightImage.SetActive(true);

    public void DisactiveWin() => 
        _lightImage.SetActive(false);

    private void ChangeData()
    {
        _itemImage.sprite = _slotData.Icon;

        _lightImage.SetActive(false);
    }
}
