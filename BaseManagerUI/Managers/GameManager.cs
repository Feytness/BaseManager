using BaseManager.Models;
using BaseManagerUI.Models;
using BaseManagerUI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseManagerUI.Managers
{
    internal static class GameManager
    {
        private static GameState _state;

        public static void Initialize()
        {
            _state = GameState.InProgress;
        }

        internal static bool IsGameOver() => _state != GameState.InProgress;
    }
}
