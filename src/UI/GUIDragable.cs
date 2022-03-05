using System;
using System.Drawing;
using System.Numerics;
using System.Windows;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImGuiNET;

public static class GUIDragable
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT lpPoint);

    public static Point GetCursorPosition()
    {
        POINT lpPoint;
        GetCursorPos(out lpPoint);
        // NOTE: If you need error handling
        // bool success = GetCursorPos(out lpPoint);
        // if (!success)
            
        return lpPoint;
    }

    private static Vector2 relativeDragPosition = new Vector2(0, 0);


    public static void MakeWindowDraggable()
    {
        if (ImGui.IsMouseDown(ImGuiMouseButton.Left) && relativeDragPosition == Vector2.Zero)
        {
            relativeDragPosition = ImGui.GetMousePos();
        }

        if (ImGui.IsMouseDown(ImGuiMouseButton.Left))
        {
            var posX = (int)GetCursorPosition().X - (int)relativeDragPosition.X;
            var posY = (int)GetCursorPosition().Y - (int)relativeDragPosition.Y;
            const short SWP_NOSIZE = 1;
            const short SWP_NOZORDER = 0X4;
            const int SWP_SHOWWINDOW = 0x0040;
            IntPtr HWND_TOPMOST = new IntPtr(-1);
            WindowsNativeMethods.SetWindowPos(GuiController._window!.Handle, 0, posX, posY, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        if (ImGui.IsMouseReleased(ImGuiMouseButton.Left) && relativeDragPosition != Vector2.Zero)
        {
            relativeDragPosition = Vector2.Zero;
        }

    }
}