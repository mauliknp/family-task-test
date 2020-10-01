using System;

public class MenuItem
{
    public bool isActive {get; set;}
    public string iconColor { get; set; }
    public string label { get; set; }
    public Guid referenceId { get; set; }
    
    protected virtual void OnClickCallback(object e)
    {
        EventHandler<object> handler = ClickCallback;
        if (handler != null)
        {
            handler(this, e);
        }
    }
    protected virtual void OnDropCallback(object e)
    {
        EventHandler<object> dropHandler = DropCallback;
        if (dropHandler != null)
        {
            dropHandler(this, e);
        }
    }
    public event EventHandler<object> ClickCallback;
    public event EventHandler<object> DropCallback;

    public void InvokClickCallback(object e) {
        OnClickCallback(e);
    }
    public void InvokDropCallback(object e)
    {
        OnDropCallback(e);
    }
}
