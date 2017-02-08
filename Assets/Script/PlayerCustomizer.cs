using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[Serializable]
public class ColorCustomizer
{
    [Header("Shirt")]
    public Color DefaultShirt;
    public Color RedShirt;
    public Color BlueShirt;
    public Color PinkShirt;
    public Color PurpleShirt;
    public Color GreenShirt;
    public Color BlackShirt;
    public Color GreyShirt;
    public Color WhiteShirt;

    [Header("Pants")]
    public Color DefaultPants;
    public Color BluePants;
    public Color BrownPants;
    public Color BlackPants;

    [Header("Hair")]
    public Color DefaultHair;
    public Color LightBrownHair;
    public Color BrownHair;
    public Color BlackHair;
    public Color BlondeHair;
    public Color RedHair;
    public Color SaltAndPepperHair;
    public Color GreyHair;

    [Header("Skin")]
    public Color DefaultSkin;
    public Color PaleSkin;
    public Color WhiteSkin;
    public Color LightTanSkin;
    public Color TanSkin;
    public Color DarkSkin;
    public Color BlackSkin;
    public Color DarkBlackSkin;

    [Header("ShoeColor")]
    public Color DefaultShoe;
    public Color WhiteShoe;
    public Color RedShoe;
    public Color BlueShoe;
    public Color BrownShoe;
    public Color BlackShoe;
    public Color GreyShoe;

}
[Serializable]
public class PlayerCustomizer
{
    public PlayerCustomizer()
    {

    }
    [Header("Colors")]
    public HairColors HairColor = HairColors.Default;
    public SkinColors SkinColor = SkinColors.Default;
    public ShirtColors ShirtColor = ShirtColors.Default;
    public PantColors PantsColor = PantColors.Default;
    
    public ShoeColors ShoeColor = ShoeColors.Default;
    public ColorCustomizer ColorValues = new ColorCustomizer();

    #region Color Enums
    public enum ShirtColors
    {
        None,
        Default,
        Red,
        Blue,
        Pink,
        Purple,
        Green,
        Black,
        Grey,
        White
    }
    public enum PantColors
    {
        None,
        Default,
        Blue,
        Brown,
        Black
    }
    public enum HairColors
    {
        None,
        Default,
        LightBrown,
        Brown,
        Black,
        Blonde,
        Red,
        SaltAndPepper,
        Grey

    }
    public enum SkinColors
    {
        None,
        Default,
        Pale,
        White,
        LightTan,
        Tan,
        Dark,
        Black,
        DarkBlack
    }
    public enum ShoeColors
    {
        None,
        Default,
        White,
        Blue,
        Red,
        Black,
        Grey
    }
    #endregion

    #region Get Color
    public Color GetColor(ShirtColors color)
    {
        switch (color)
        {
            case ShirtColors.Red:
                return ColorValues.RedShirt;
            case ShirtColors.Blue:
                return ColorValues.BlueShirt;
            case ShirtColors.Pink:
                return ColorValues.PinkShirt;
            case ShirtColors.Purple:
                return ColorValues.PurpleShirt;
            case ShirtColors.Green:
                return ColorValues.GreenShirt;
            case ShirtColors.Black:
                return ColorValues.BlackShirt;
            case ShirtColors.Grey:
                return ColorValues.GreyShirt;
            case ShirtColors.White:
                return ColorValues.WhiteShirt;
            default:
                return ColorValues.DefaultShirt;
        }
    }
    public Color GetColor(PantColors color)
    {
        switch (color)
        {
            case PantColors.Blue:
                return ColorValues.BluePants;
            case PantColors.Brown:
                return ColorValues.BrownPants;
            case PantColors.Black:
                return ColorValues.BlackPants;
            default:
                return ColorValues.DefaultPants;
        }
    }
    public Color GetColor(HairColors color)
    {
        switch (color)
        {
            case HairColors.LightBrown:
                return ColorValues.LightBrownHair;
            case HairColors.Brown:
                return ColorValues.BrownHair;
            case HairColors.Black:
                return ColorValues.BlackHair;
            case HairColors.Blonde:
                return ColorValues.BlondeHair;
            case HairColors.Red:
                return ColorValues.RedHair;
            case HairColors.SaltAndPepper:
                return ColorValues.SaltAndPepperHair;
            case HairColors.Grey:
                return ColorValues.GreyHair;
            default:
                return ColorValues.DefaultHair;
        }
    }
    public Color GetColor(SkinColors color)
    {
        switch (color)
        {
            case SkinColors.Pale:
                return ColorValues.PaleSkin;
            case SkinColors.White:
                return ColorValues.WhiteSkin;
            case SkinColors.LightTan:
                return ColorValues.LightTanSkin;
            case SkinColors.Tan:
                return ColorValues.TanSkin;
            case SkinColors.Dark:
                return ColorValues.DarkSkin;
            case SkinColors.Black:
                return ColorValues.BlackSkin;
            case SkinColors.DarkBlack:
                return ColorValues.DarkBlackSkin;
            default:
                return ColorValues.DefaultSkin;
        }
    }
    public Color GetColor(ShoeColors color)
    {
        switch (color)
        {
            case ShoeColors.White:
                return ColorValues.WhiteShoe;
            case ShoeColors.Blue:
                return ColorValues.BlueShoe;
            case ShoeColors.Red:
                return ColorValues.RedShoe;
            case ShoeColors.Black:
                return ColorValues.BlackShoe;
            case ShoeColors.Grey:
                return ColorValues.GreyShoe;
            default:
                return ColorValues.DefaultShoe;
        }
    }
    #endregion

    #region Name Getters and Setters
    public static ShoeColors GetShoeFromName(string name)
    {
        switch (name)
        {
            case "Default":
                return ShoeColors.Default;
            case "Black":
                return ShoeColors.Black;
            case "Blue":
                return ShoeColors.Blue;
            case "White":
                return ShoeColors.White;
            case "Grey":
                return ShoeColors.Grey;
            case "Red":
                return ShoeColors.Red;
            default:
                Debug.LogError("The given name, to PlayerCustomizer.GetShoeFromName(string name = " + name + "), was not recognized.");
                return default(ShoeColors);
        }
    }
    public static ShirtColors GetShirtFromName(string name)
    {
        switch (name)
        {
            case "Default":
                return ShirtColors.Default; 
            case "Red":
                return ShirtColors.Red; 
            case "Blue":
                return ShirtColors.Blue; 
            case "Pink":
                return ShirtColors.Pink; 
            case "Purple":
                return ShirtColors.Purple;
            case "Green":
                return ShirtColors.Green; 
            case "Black":
                return ShirtColors.Black; 
            case "Grey":
                return ShirtColors.Grey; 
            case "White":
                return ShirtColors.White; 
            default:
                Debug.LogError("The given name, to PlayerCustomizer.GetShirtFromName(string name = " + name + "), was not recognized.");
                return default(ShirtColors);
        }
    }
    public static PantColors GetPantsFromName(string name)
    {
        switch (name)
        {
            case "Default":
                return PantColors.Default;
            case "Blue":
                return PantColors.Blue; 
            case "Black":
                return PantColors.Black;
            case "Brown":
                return PantColors.Brown;
            default:
                Debug.LogError("The given name, to PlayerCustomizer.GetPantsFromName(string name = " + name + "), was not recognized.");
                return default(PantColors);
        }
    }
    public static HairColors GetHairFromName(string name)
    {
        switch (name)
        {
            case "Default":
                return HairColors.Default;
            case "Light Brown":
                return HairColors.LightBrown;
            case "Brown":
                return HairColors.Brown;
            case "Black":
                return HairColors.Black;
            case "Blonde":
                return HairColors.Blonde;
            case "Red":
                return HairColors.Red; 
            case "Salt and Pepper":
                return HairColors.SaltAndPepper;
            case "Grey":
                return HairColors.Grey;
            default:
                Debug.LogError("The given name, to PlayerCustomizer.GetHairFromName(string name = " + name + "), was not recognized.");
                return default(HairColors);
        }
    }
    public static SkinColors GetSkinFromName(string name)
    {
        switch (name)
        {
            case "Default":
                return SkinColors.Default;
            case "Pale":
                return SkinColors.Pale;
            case "White":
                return SkinColors.White;
            case "Light Tan":
                return SkinColors.LightTan;
            case "Tan":
                return SkinColors.Tan; 
            case "Dark Tan":
                return SkinColors.Dark;
            case "Black":
                return SkinColors.Black;
            case "Dark Black":
                return SkinColors.DarkBlack;
            default:
                Debug.LogError("The given name, to PlayerCustomizer.GetSkinFromName(string name = " + name + "), was not recognized.");
                return default(SkinColors);
        }
    }
    /// <summary>
    /// Sets the value of the given type, which is of one of the customizable enum types, to the value of the name given. Does nothing and loggs an error if it is not a supported enum type
    /// or the name is not recognized.
    /// </summary>
    /// <typeparam name="T">The customizable enum type to change</typeparam>
    public void SetFromName<T>(string name)
    {
        if (typeof(T) == typeof(ShoeColors))
        {
            switch (name)
            {
                case "Default":
                    ShoeColor = ShoeColors.Default; break;
                case "Black":
                    ShoeColor = ShoeColors.Black; break;
                case "Blue":
                    ShoeColor = ShoeColors.Blue; break;
                case "White":
                    ShoeColor = ShoeColors.White; break;
                case "Grey":
                    ShoeColor = ShoeColors.Grey; break;
                case "Red":
                    ShoeColor = ShoeColors.Red; break;
                default:
                    Debug.LogError("The given name, to PlayerCustomizer.SetFromName<" + typeof(T).Name + ">(string name), was not recognized.");
                    break;
            }
            return;
        }
        if (typeof(T) == typeof(ShirtColors))
        {
            switch (name)
            {
                case "Default":
                    ShirtColor = ShirtColors.Default; break;
                case "Red":
                    ShirtColor = ShirtColors.Red; break;
                case "Blue":
                    ShirtColor = ShirtColors.Blue; break;
                case "Pink":
                    ShirtColor = ShirtColors.Pink; break;
                case "Purple":
                    ShirtColor = ShirtColors.Purple; break;
                case "Green":
                    ShirtColor = ShirtColors.Green; break;
                case "Black":
                    ShirtColor = ShirtColors.Black; break;
                case "Grey":
                    ShirtColor = ShirtColors.Grey; break;
                case "White":
                    ShirtColor = ShirtColors.White; break;
                default:
                    Debug.LogError("The given name, to PlayerCustomizer.SetFromName<" + typeof(T).Name + ">(string name), was not recognized.");
                    break;
            }
            return;
        }
        if (typeof(T) == typeof(PantColors))
        {
            switch (name)
            {
                case "Default":
                    PantsColor = PantColors.Default; break;
                case "Blue":
                    PantsColor = PantColors.Blue; break;
                case "Black":
                    PantsColor = PantColors.Black; break;
                case "Brown":
                    PantsColor = PantColors.Brown; break;
                default:
                    Debug.LogError("The given name, to PlayerCustomizer.SetFromName<" + typeof(T).Name + ">(string name), was not recognized.");
                    break;
            }
            return;
        }
        if (typeof(T) == typeof(HairColors))
        {
            switch (name)
            {
                case "Default":
                    HairColor = HairColors.Default; break;
                case "Light Brown":
                    HairColor = HairColors.LightBrown; break;
                case "Brown":
                    HairColor = HairColors.Brown; break;
                case "Black":
                    HairColor = HairColors.Black; break;
                case "Blonde":
                    HairColor = HairColors.Blonde; break;
                case "Red":
                    HairColor = HairColors.Red; break;
                case "Salt and Pepper":
                    HairColor = HairColors.SaltAndPepper; break;
                case "Grey":
                    HairColor = HairColors.Grey; break;
                default:
                    Debug.LogError("The given name, to PlayerCustomizer.SetFromName<" + typeof(T).Name + ">(string name), was not recognized.");
                    break;
            }
            return;
        }
        if (typeof(T) == typeof(SkinColors))
        {
            switch (name)
            {
                case "Default":
                    SkinColor = SkinColors.Default; break;
                case "Pale":
                    SkinColor = SkinColors.Pale; break;
                case "White":
                    SkinColor = SkinColors.White; break;
                case "Light Tan":
                    SkinColor = SkinColors.LightTan; break;
                case "Tan":
                    SkinColor = SkinColors.Tan; break;
                case "Dark Tan":
                    SkinColor = SkinColors.Dark; break;
                case "Black":
                    SkinColor = SkinColors.Black; break;
                case "Dark Black":
                    SkinColor = SkinColors.DarkBlack; break;
                default:
                    Debug.LogError("The given name, to PlayerCustomizer.SetFromName<" + typeof(T).Name + ">(string name), was not recognized.");
                    break;
            }
            return;
        }

        Debug.LogError("The given type is not one of the customizable enum types in PlayerCustomizer.SetFromName<" + typeof(T).Name + ">(string name).");
        return;
    }
    /// <summary>
    /// Used to display for user selection, only has results when the type given is one of the customizable enum types
    /// </summary>
    /// <typeparam name="T">One of the customizable enum types</typeparam>
    /// <returns>All choice names, or an empty array if it is the wrong type</returns>
    public static string[] GetAllNames<T>()
    {
        List<string> names = new List<string>();
        names.Add("Default");
        if (typeof(T) == typeof(ShoeColors))
        {
            names.Add("Black");
            names.Add("Blue");
            names.Add("White");
            names.Add("Grey");
            names.Add("Red");
        }
        else if (typeof(T) == typeof(ShirtColors))
        {
            names.Add("Red");
            names.Add("Blue");
            names.Add("Pink");
            names.Add("Purple");
            names.Add("Green");
            names.Add("Black");
            names.Add("Grey");
            names.Add("White");
        }
        else if(typeof(T) == typeof(PantColors))
        {
            names.Add("Blue");
            names.Add("Black");
            names.Add("Brown");
        }
        else if(typeof(T) == typeof(HairColors))
        {
            names.Add("Light Brown");
            names.Add("Brown");
            names.Add("Black");
            names.Add("Blonde");
            names.Add("Red");
            names.Add("Salt and Pepper");
            names.Add("Grey");
        }
        else if(typeof(T) == typeof(SkinColors))
        {
            names.Add("Pale");
            names.Add("White");
            names.Add("Light Tan");
            names.Add("Tan");
            names.Add("Dark Tan");
            names.Add("Black");
            names.Add("Dark Black");
        }
        else
        {
            Debug.LogError("Wrong type was passed into PlayerCustomizer.GetAllNames<T>(). It must be of one of the customizable color enums otherwise it returns an empty array");
            return new string[0];
        }
        return names.ToArray();
    }
    #endregion

    /// <summary>
    /// Resets all colors to their default values
    /// </summary>
    public void ResetToDefault()
    {
        ShirtColor = ShirtColors.Default;
        PantsColor = PantColors.Default;
        HairColor = HairColors.Default;
        SkinColor = SkinColors.Default;
        ShoeColor = ShoeColors.Default;
    }
    /// <summary>
    /// Resets all colors to their default values, then applies them
    /// </summary>
    /// <param name="controller">The player controller</param>
    public void ResetToDefaultAndApply(PlayerController controller)
    {
        ShirtColor = ShirtColors.Default;
        PantsColor = PantColors.Default;
        HairColor = HairColors.Default;
        SkinColor = SkinColors.Default;
        ShoeColor = ShoeColors.Default;
        ApplyColors(controller);
    }
    /// <summary>
    /// Applys the selected colors to the given player, should only be used when changes are made
    /// </summary>
    /// <param name="controller">The player controller</param>
    public void ApplyColors(PlayerController controller)
    {
        //first find the player mesh to get the skin and shoe materials
        GameObject playerMesh = controller.GetComponentsInChildren<Transform>().FirstOrDefault(a => { return a.name == "Character_Mesh"; }).gameObject;
        if (playerMesh == default(GameObject))
        {
            Debug.LogError("Could not find player Character_Mesh. PlayerCustomizer.ApplyColors()");
            return;
        }
        //get the renderers to have access to the materials
        SkinnedMeshRenderer[] renderer = playerMesh.GetComponentsInChildren<SkinnedMeshRenderer>();
        List<Material> materials = new List<Material>();

        foreach (var r in renderer)
            materials.AddRange(r.materials);

        //get the renderers under the main player object and add those materials
        renderer = controller.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (var r in renderer)
            materials.AddRange(r.materials);

        //change the colors according to name
        foreach (Material m in materials)
        {
            switch (m.name)
            {
                case "Face (Instance)":
                    m.color = GetColor(SkinColor); break;
                case "Skin (Instance)":
                    m.color = GetColor(SkinColor); break;
                case "Shoes (Instance)":
                    m.color = GetColor(ShoeColor); break;
                case "Shirt (Instance)":
                    m.color = GetColor(ShirtColor); break;
                case "Pants (Instance)":
                    m.color = GetColor(PantsColor); break;
                case "Hair (Instance)":
                    m.color = GetColor(HairColor); break;
                default:
                    break;
            }
        }
    }
}
