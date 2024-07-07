using BaseManagerUI.Commands;
using BaseManagerUI.Managers;
using BaseManagerUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseManagerUI
{
    public partial class frmMain : Form
    {
        internal string[,] _displayMap;
        Thread _mainBackgroundThread;
        Dictionary<int, Thread> _commandThreadLine = new Dictionary<int, Thread>();
        private bool _currentlyUpdatingScreen;

        public frmMain()
        {
            InitializeComponent();
            InitializeManagers();

            _mainBackgroundThread = new Thread(MainGameLoop);
            _mainBackgroundThread.Start();
        }

        /// <summary>
        /// This will maintain the main loop of the game
        /// This should run every x seconds and perform the following actions:
        /// - Update load times of waiting items
        /// - Update positions of on-screen elements
        /// - Re-draw screen
        /// </summary>
        private void MainGameLoop()
        {
            _currentlyUpdatingScreen = false;

            while (!GameManager.IsGameOver())
            {
                ResourceManager.ManageResources().ForEach(x => WriteToLog_CPU(x.Message));
                if (!_currentlyUpdatingScreen)
                {
                    _currentlyUpdatingScreen = true;
                    _ = UpdateScreen();
                    _currentlyUpdatingScreen = false;
                }

                // Thread.Sleep(1000);
            }

            _mainBackgroundThread.Join();
        }

        private async Task UpdateScreen()
        {
            await Task.Run(() =>
            {
                var arrMap = MapManager.GetDisplayMap();
                //if(arrMap != null)
                //{
                //    if(arrMap != _displayMap)
                //    {
                _displayMap = arrMap;

                txtMap.Invoke((Action)(() =>
                {
                    txtMap.Text = MapManager.Draw();
                }));

                //    }
                //}
            });
        }

        private void InitializeManagers()
        {
            BuildingManager.Initialize();
            MapManager.Initialize(10, 10);
            CommandManager.Initialize();
            ResourceManager.Initialize();
            GameManager.Initialize();
        }

        private void txtInput_Input(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                ProcessInput();
        }

        private void ProcessInput()
        {
            _ = ProcessUserInputAsync(DisplayUserText());
        }

        private async Task ProcessUserInputAsync(string v)
        {

            txtLog.Invoke((Action)(async () =>
            {
                txtLog.AppendText(await CommandManager.ProcessUserInput(v) + "\r\n");
            }));
        }

        private string DisplayUserText()
        {
            var inputText = txtInput.Text;
            txtInput.Text = string.Empty;

            WriteToLog_User(inputText);

            return inputText;
        }


        private void WriteToLog_User(string msg) => txtLog.AppendText($"> {msg} \r\n");

        private void WriteToLog_CPU(string msg)
        {
            if (msg != null)
                txtLog.AppendText($"{msg} \r\n");
        }
    }
}
