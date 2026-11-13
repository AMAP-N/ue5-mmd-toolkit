using UnrealBuildTool;

public class UMT_Importer : ModuleRules
{
    public UMT_Importer(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine",
            "DeveloperSettings",
            "InterchangeCore",
            "PhysicsCore",
            "UMT_Runtime",
            "MeshDescription",
        });

        PrivateDependencyModuleNames.AddRange(new string[]
        {
            "UnrealEd",
            "RenderCore",
            "RHI",
            "StaticMeshDescription",
            "SkeletalMeshDescription",
            "AnimationCore",
            "AssetRegistry",
            "ImageCore",
            "ImageWrapper",
            "AnimGraph",
            "KismetCompiler",
            "MaterialEditor",
            "BlueprintGraph",
            "SkeletalMeshModifiers",
            "Slate",
            "SlateCore",
            "InputCore",
            "AssetTools",
            "UMT_Deform",
            "UMT_Editor",
            "UMT_BulletRuntime",
            "SkeletalMeshEditor",
            "ContentBrowser",
            "ContentBrowserData",
            "PropertyEditor",
            "IKRig",
            "IKRigEditor",
            "ControlRig",
            "ControlRigDeveloper",
            "ControlRigEditor",
            "RigVM",
            "RigVMDeveloper",
            "ToolMenus",
            "Projects",
            "Json",
            "EditorScriptingUtilities",
        });
    }
}
