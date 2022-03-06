using System;
using System.Drawing;
using System.Numerics;
using System.Windows;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImGuiNET;

public static class IoFlags
{
    public static void SetIoFlags()
    {
        ImGuiIOPtr io = ImGui.GetIO();
        io.BackendFlags |= ImGuiBackendFlags.PlatformHasViewports;

        io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;
        io.ConfigWindowsMoveFromTitleBarOnly = true;

        GuiController.io = io;
    }
}