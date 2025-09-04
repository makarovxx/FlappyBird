using UnityEngine.Events;

public class StartPanelScreen : PanelScreen
{
    public event UnityAction PlayButtonClick;

    protected override void OnButtonClick() => PlayButtonClick?.Invoke();

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    public override void Exit()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }
}