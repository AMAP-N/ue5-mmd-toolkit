using System.IO;
using UnrealBuildTool;

public class AMAP5_MetaHumanMocap : ModuleRules
{
    public AMAP5_MetaHumanMocap(ReadOnlyTargetRules Target) : base(Target)
    {
        bUsePrecompiled = true;
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
        PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine" });
        PrivateDependencyModuleNames.AddRange(new string[] { "UnrealEd", "AssetRegistry", "AssetTools", "Projects", "Json", "EditorScriptingUtilities" });
        string MetaHumanPerf = Path.Combine(EngineDirectory, "Plugins", "MetaHuman", "MetaHumanAnimator", "Source", "MetaHumanPerformance", "MetaHumanPerformance.Build.cs");
        bool bForceNoMetaHuman = !string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("AMAP5_NO_METAHUMAN"));
        if (Target.bBuildEditor && File.Exists(MetaHumanPerf) && !bForceNoMetaHuman)
        {
            PrivateDependencyModuleNames.AddRange(new string[] { "MetaHumanPerformance", "CaptureDataCore", "ImgMedia" });
            PublicDefinitions.Add("AMAP5_WITH_METAHUMAN=1");
        }
        else { PublicDefinitions.Add("AMAP5_WITH_METAHUMAN=0"); }
    }
}


