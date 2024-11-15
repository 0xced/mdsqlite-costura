using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using SQLitePCL;

public class ModuleGetFunctionPointer : IGetFunctionPointer
{
    private readonly ProcessModule _module;

    private static ProcessModule GetModule(string moduleName)
    {
        var modules = Process.GetCurrentProcess().Modules.Cast<ProcessModule>().Where(e => Path.GetFileNameWithoutExtension(e.ModuleName) == moduleName).ToList();
        return modules.Count switch
        {
            0 => throw new ArgumentException($"Found no modules named '{moduleName}' in the current process.", nameof(moduleName)),
            > 1 => throw new ArgumentException($"Found several modules named '{moduleName}' in the current process.", nameof(moduleName)),
            _ => modules[0],
        };
    }

    private ModuleGetFunctionPointer(ProcessModule module) => _module = module ?? throw new ArgumentNullException(nameof(module));

    public ModuleGetFunctionPointer(string moduleName) : this(GetModule(moduleName))
    {
    }

    public IntPtr GetFunctionPointer(string name) => Kernel32.GetProcAddress(_module.BaseAddress, name);

    private static class Kernel32
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr module, string name);
    }
}