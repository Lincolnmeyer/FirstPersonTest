using Godot;
using System;

[Tool]
public partial class TonemapperCompositor : CompositorEffect
{
    public RenderingDevice rd;
    public Rid shader;
    public Rid pipeline;

    public void _init()
    {
        var initCompute = new Callable(this, "_InitializeCompute");
        RenderingServer.CallOnRenderThread(initCompute);
    }

    public override void _Notification(int what)
    {
        if (what == NotificationPredelete && shader.IsValid)
            RenderingServer.FreeRid(shader);
    }

    public void _InitializeCompute()
    {

    }
}
