using UnrealBuildTool;

public class UMT_BulletEditor : ModuleRules
{
    public UMT_BulletEditor(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PrivateDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine",
            "InputCore",
            "UMT_BulletRuntime",
            "UMT_Runtime",
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
