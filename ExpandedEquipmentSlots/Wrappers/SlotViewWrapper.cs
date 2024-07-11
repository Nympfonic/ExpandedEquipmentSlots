using Arys.EES.Helpers;
using EFT.UI.DragAndDrop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arys.EES.Wrappers;

public class SlotViewWrapper : ReflectionWrapper<SlotView>
{
    public RectTransform SlotPlace { get; private set; }
    public Image SlotBackground { get; private set; }
    public Image EmptyBorder { get; private set; }
    public Image SelectedBorder { get; private set; }
    public Image SelectedCorner { get; private set; }
    public TextMeshProUGUI HeaderText { get; private set; }
    public SlotViewHeader SlotHeader { get; private set; }

    public SlotViewWrapper(SlotView slotView) : base(slotView)
    {
        SlotPlace = Value.GetField<RectTransform>("_slotPlace");
        SlotBackground = Value.GetField<Image>("_slotBackground");
        EmptyBorder = Value.GetField<Image>("_emptyBorder");
        SelectedBorder = Value.GetField<Image>("_selectedBorder");
        SelectedCorner = Value.GetField<Image>("_selectedCorner");
        HeaderText = Value.GetField<TextMeshProUGUI>("_headerText");
        SlotHeader = Value.GetField<SlotViewHeader>("_slotHeader");
    }
}
