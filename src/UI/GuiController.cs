using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

public static class GuiController
{
    #region Variables
    public static Sdl2Window? _window { get; private set; }
    private static GraphicsDevice? _gd;
    private static CommandList? _cl;
    private static ImGuiHelper? _helper;
    public static bool _debug { get; private set; } = false;
    #endregion

    public static void Update(string[]? args = null)
    {
        #region Initialize
        //Determine if we in debug mode
        if (args?.Length >= 1 && args[0] == "--debug")
        {
            _debug = true;
        }

        // Create window, GraphicsDevice, and all resources necessary for the demo.
        VeldridStartup.CreateWindowAndGraphicsDevice(
            new WindowCreateInfo(50, 50, 1280, 720, WindowState.Normal, "ImGui.NET Sample Program"),
            new GraphicsDeviceOptions(true, null, true, ResourceBindingModel.Improved, true, true),
            out Sdl2Window _windowOut,
            out GraphicsDevice _gdOut);
        
        //Assign window and graphics device to class variables as they are private and cannot be set with 'out' keyword
        _window = _windowOut;
        _gd = _gdOut;

        //Make window resizable
        _window.Resized += () =>
        {
            _gd.MainSwapchain.Resize((uint)_window.Width, (uint)_window.Height);
            _helper!.WindowResized(_window.Width, _window.Height);
        };

        _cl = _gd.ResourceFactory.CreateCommandList();
        _helper = new ImGuiHelper(_gd, _gd.MainSwapchain.Framebuffer.OutputDescription, _window.Width, _window.Height);
        #endregion

        #region Main Loop
        //Main loop of the running application
        while (_window!.Exists)
        {
            //Ensure window exists, otherwise we end the loop and stop the application
            if (!_window.Exists) { break; }

            //Set the framerate 1/fps where fps is the desired framerate
            int fps = 60;
            _helper.Update(1f / fps, _window.PumpEvents()!);

            //Main frontend layout renderer 
            GuiLayouts.Render();
            
            //Render the ImGui based on the rules above for this frame
            _cl.Begin();
            _cl.SetFramebuffer(_gd.MainSwapchain.Framebuffer);
            _cl.ClearColorTarget(0, new RgbaFloat(0.45f, 0.55f, 0.6f, 1f));
            _helper.Render(_gd, _cl);
            _cl.End();
            _gd.SubmitCommands(_cl);
            _gd.SwapBuffers(_gd.MainSwapchain);
        }
        #endregion

        #region Quit
        //On quit we need to dispose of all resources
        _gd.WaitForIdle();
        _helper.Dispose();
        _cl.Dispose();
        _gd.Dispose();
        #endregion
    }
}