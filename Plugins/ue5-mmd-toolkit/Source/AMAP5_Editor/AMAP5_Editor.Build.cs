using UnrealBuildTool;

public class AMAP5_Editor : ModuleRules
{
    public AMAP5_Editor(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicDependencyModuleNames.AddRange(
            new string[] { "Core", "CoreUObject", "Engine", "AMAP5_Runtime", "AnimGraphRuntime" }
        );

        PrivateDependencyModuleNames.AddRange(
            new string[] { "AnimGraph", "BlueprintGraph", "KismetCompiler", "Slate", "SlateCore", "Projects", "UnrealEd", "Kismet", "Json", "JsonUtilities", "InterchangeCore", "AssetRegistry" }
        );
    }
}
