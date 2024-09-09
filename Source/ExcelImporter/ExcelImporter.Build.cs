// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;
using System.Data;
using UnrealBuildBase;
using UnrealBuildTool.Rules;

public class ExcelImporter : ModuleRules
{
	public ExcelImporter(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicIncludePaths.AddRange(
			new string[] {
                // ... add public include paths required here ...
				"ExcelImporter/Public"
            }
			);

        PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
				"ExcelImporter/Private"
            }
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				// ... add other public dependencies that you statically link with here ...
				"Core",
                "Slate",
				"SlateCore",
            }
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				"InputCore",
				"EditorFramework",
				"EditorStyle",
				"UnrealEd",
				"LevelEditor",
				"InteractiveToolsFramework",
				"EditorInteractiveToolsFramework",
                "ToolMenus",
                "AssetRegistry",
                "Projects",
				/*"Engine",
                "AssetRegistry", // Engine �ʿ�
				"CoreUObject"  // UObject ���� ������ �߰�*/

				"SlateEditorUtils",
                "EditorPackageUtils",
				// ... add private dependencies that you statically link with here ...	
			}
            );
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);

        // OpenXLSX ��� ����
        string OpenXLSXPath = Path.Combine(ModuleDirectory, "..", "..", "ThirdParty", "OpenXLSX");

        // ��� ���� ��� ����
        PublicIncludePaths.Add(Path.Combine(OpenXLSXPath, "Includes"));

        // ���̺귯�� ���� ��� ����
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            string OpenXLSXLibPath = Path.Combine(OpenXLSXPath, "Lib", "Win64", "OpenXLSX.lib");

            // ���̺귯�� ������ ���� �����ϴ��� Ȯ��
            if (File.Exists(OpenXLSXLibPath))
            {
                PublicAdditionalLibraries.Add(OpenXLSXLibPath);
                RuntimeDependencies.Add(OpenXLSXLibPath);
            }
            else
            {
                throw new BuildException("OpenXLSX.lib not found at " + OpenXLSXLibPath);
            }
        }
    }
}
