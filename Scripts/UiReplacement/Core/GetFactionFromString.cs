using BaseCustomFactions.Scripts.Logging;
using HoldfastSharedMethods;

namespace BaseCustomFactions.Core
{
    public static class GetFactionFromString
    {
        private static readonly ILog Logger = LogFactory.GetLogger(typeof(GetFactionFromString), LogLevelsEnum.All);

        public static FactionCountry GetFactionForEmblem(string name)
        {
            switch (name)
            {
                case "British-No-Ribbon-No-Header" : return FactionCountry.British;
                case "French-No-Ribbon-No-Header" : return FactionCountry.French;
                case "Prussian-No-Ribbon-No-Header" : return FactionCountry.Prussian;
                case "Italian-No-Ribbon-No-Header" : return FactionCountry.Italian;
                case "Russian-No-Ribbon-No-Header-Russia" : return FactionCountry.Russian;
                case "Central-No-Ribbon-No-Header" : return FactionCountry.Central;
                case "Allied-No-Ribbon-No-Header" : return FactionCountry.Allied;
                default:
                    Logger.LogError($"Emlem sprite is called {name}. Please contact {StaticValues.MOD_AUTHOR} on discord with this log");
                    return FactionCountry.None;
            }
        }


		public static FactionCountry GetFactionBasedOnContainingName(string spriteName)
		{
			string textLower = spriteName.ToLower();

			if (textLower.Contains("british") || textLower.Contains("britain"))
			{
				return FactionCountry.British;
			}
			else if (textLower.Contains("french") || textLower.Contains("france"))
			{
				return FactionCountry.French;
			}
			else if (textLower.Contains("russian") || textLower.Contains("russia"))
			{
				return FactionCountry.Russian;
			}
			else if (textLower.Contains("italian") || textLower.Contains("italy"))
			{
				return FactionCountry.Italian;
			}
			else if (textLower.Contains("austrian") || textLower.Contains("austria"))
			{
				return FactionCountry.Internal_Frontline_Austria;
			}
			else if (textLower.Contains("prussian") || textLower.Contains("prussia"))
			{
				return FactionCountry.Prussian;
			}
			Logger.LogError($"Not sure what to replace for map voting. Input sprite was {spriteName}");
			return FactionCountry.None;
		}
	}
}