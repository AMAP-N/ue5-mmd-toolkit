using UnrealBuildTool;

public class UMT_Deform : ModuleRules
{
    public UMT_Deform(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine"
        });

        PrivateDependencyModuleNames.AddRange(new string[]
        {
			"AssetRegistry",
            "ComputeFramework",
            "OptimusCore",
            "UnrealEd"
        });
    }
}
