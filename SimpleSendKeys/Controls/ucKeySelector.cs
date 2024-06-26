﻿using SimpleSendKeys.Utils;
using System.ComponentModel;

namespace SimpleSendKeys.Controls
{
    public partial class ucKeySelector : UserControl
    {
        #region Variables
        #region Public
        [Description("The virtual key code of the selected key."), Category("Data")]
        public int VirtualKeyCode { get; private set; }

        public event EventHandler<int>? KeyUpdated;
        #endregion

        #region Private
        private bool _waitingForKey = false;
        #endregion
        #endregion

        #region Constructor
        public ucKeySelector()
        {
            InitializeComponent();
            VirtualKeyCode = 45;
        }
        #endregion

        #region Public methods
        public void Reset(bool invokeEventHandler = true)
        {
            VirtualKeyCode = 45;
            UpdateUI();
            if (invokeEventHandler) { KeyUpdated?.Invoke(this, VirtualKeyCode); }
        }

        public bool SetKey(int keyCode, bool invokeEventHandler = true)
        {
            try
            {
                if (!Enum.IsDefined(typeof(Keys), keyCode)) { return false; }
                VirtualKeyCode = keyCode;
                UpdateUI();
                if (invokeEventHandler) { KeyUpdated?.Invoke(this, VirtualKeyCode); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Private methods
        private void ucKeySelector_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "-";
            _waitingForKey = false;
            VirtualKeyCode = 45;
            UpdateUI();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {
            this.Focus();
            _waitingForKey.Invert();
            UpdateUI();
        }

        private void lblInfo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (_waitingForKey)
            {
                if (e.KeyValue == 27)
                {
                    MessageBox.Show(this, "The 'Escape' key is reserved for stopping the data sending.", "SimpleSendKeys", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VirtualKeyCode = e.KeyValue;
                _waitingForKey.Invert();
                UpdateUI();
                KeyUpdated?.Invoke(this, VirtualKeyCode);
            }
        }

        private void UpdateUI()
        {
            if (_waitingForKey)
            {
                lblInfo.Focus();
                lblInfo.BackColor = Color.FromArgb(64, 64, 64);
                lblInfo.Text = "Press a key...";
            }
            else
            {
                lblInfo.BackColor = Color.FromArgb(26, 26, 26);
                lblInfo.Text = ((Keys)VirtualKeyCode).ToString();
            }
        }

        private void ucKeySelector_Leave(object sender, EventArgs e)
        {
            _waitingForKey = false;
            UpdateUI();
        }
        #endregion
    }
}
