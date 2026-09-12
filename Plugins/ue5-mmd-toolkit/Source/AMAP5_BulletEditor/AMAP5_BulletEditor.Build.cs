using UnrealBuildTool;

public class AMAP5_BulletEditor : ModuleRules
{
    public AMAP5_BulletEditor(ReadOnlyTargetRules Target) : base(Target)
    {
        bUsePrecompiled = true;
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PrivateDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine",
            "AMAP5_BulletRuntime",
            "AMAP5_Runtime",
            "AnimGraph",
            "AnimGraphRuntime",
            "AnimationEditMode",
            "BlueprintGraph",
            "EditorFramework",
            "UnrealEd",
            "Slate",
            "SlateCore",
            "PropertyEditor",
            "EditorStyle",
            "AnimationBlueprintLibrary",
            "Kismet",
            "KismetCompiler",
            "ToolMenus",
            "AssetTools",
            "RenderCore",
            "RHI",
            "InterchangeCore"
        });
    }
}


