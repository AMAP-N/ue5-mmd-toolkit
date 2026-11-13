using UnrealBuildTool;

public class UMT_Runtime : ModuleRules
{
    public UMT_Runtime(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.NoPCHs;
        PrecompileForTargets = PrecompileTargetsType.Any;

        PublicDependencyModuleNames.AddRange(
            new string[] { "Core", "CoreUObject", "Engine", "AnimGraphRuntime", "InterchangeCore", "IKRig", "ComputeFramework", "OptimusCore", "RenderCore", "RHI" }
        );

    }
}



