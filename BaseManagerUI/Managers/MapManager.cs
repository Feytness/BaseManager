using BaseManager.Models;
using BaseManagerUI.Models.Enums;

namespace BaseManagerUI.Managers
{
    internal static class MapManager
    {
        private static string[,] Map;
        private static string DisplayMap;

        internal static void Initialize(int rowAmount, int colAmount)
        {
            Map = new string[rowAmount, colAmount];
        }

        internal static int[] GetCoordinates(string sp)
        {
            return GetCoordinates(sp.ToCharArray());
        }

        internal static int[] GetCoordinates(char[] chars)
        {
            try
            {
                return new int[]
                {
                (int)(MapRows)Enum.Parse(typeof(MapRows), chars[0].ToString().ToUpper()),
                int.Parse(chars[1].ToString()) - 1
                };
            }
            catch (Exception e)
            {
                return new int[0];
            }
        }

        internal static bool CheckIfSpaceAvailable(string sp)
        {
            try
            {
                var space = GetCoordinates(sp);
                var row = (int)(MapRows)Enum.Parse(typeof(MapRows), space[0].ToString());
                var col = int.Parse(space[1].ToString());

                if (Map == null) return false;
                if (Map.GetLength(0) < row) return false;
                if (Map.GetLength(1) < col) return false;
                if (Map[row, col] != null) return false;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal static void AddItem(Building item, int[] pos)
        {
            Map[pos[0], pos[1]] = item.DisplayCharacter.ToString() ?? "   ";
        }

        internal static string Draw()
        {
            int rowCount = Map.GetLength(0);
            int colCount = Map.GetLength(1);
            var DisplayMap = "  ";

            for (int i = 1; i <= colCount; i++) DisplayMap += $"  {i}  ";

            // Loop through the array using nested loops
            for (int i = 0; i < rowCount; i++)
            {
                DisplayMap += "\r\n \r\n";
                DisplayMap += (MapRows)i + " ";
                for (int j = 0; j < colCount; j++)
                {
                    if (Map[i, j] == null)
                        DisplayMap += "     ";

                    DisplayMap += Map[i, j];
                }
            }

            return DisplayMap;
        }

        internal static string[,] GetDisplayMap() => Map;
    }
}
