
using WKosArch.Extentions;

public static class AssetPath 
{
    private const string MainCameraPath = "";
    private const string PlayerFollowCameraPath = "PlayerFollowCamera";
    private const string PlayerPath = "ToonBear Root";

    public static string GetPath(this PathID iD)
    {
        string result = null;

        switch (iD)
        {
            case PathID.Unknown:
                break;
            case PathID.MainCamera:
                result = MainCameraPath;
                break;
            case PathID.PlayerFollowCamera:
                result = PlayerFollowCameraPath;
                break;
            case PathID.Player:
                result = PlayerPath;
                break;
            default:
                break;
        }

        if (result == null)
        {
            Log.PrintWarning($"Cant find AssetPath for {iD}");
        }

        return result;
    }
}

public enum PathID
{
    Unknown = 0,
    MainCamera = 1,
    PlayerFollowCamera = 2,
    Player = 3,
}
