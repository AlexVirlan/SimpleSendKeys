using SimpleSendKeys.Utils;
using SimpleSendKeys.Utils.KeyboardHook;
using System.ComponentModel;

namespace SimpleSendKeys.Controls
{
    public partial class ucModifierKeys : UserControl
    {
        #region Variables
        #region Private
        private bool _extended = false;
        private bool _configuring = false;
        #endregion

        #region Public
        [Description("The modifiers list."), Category("Data")]
        public List<ModifierKeys> Modifiers { get; private set; }

        [Description("The modifiers list as displayed (text)."), Category("Data")]
        public string ModifiersText { get; private set; }

        [Description("Whether to sort the modifiers or not."), Category("Appearance")]
        public bool SortModifiers { get; set; } = true;

        public event EventHandler<List<ModifierKeys>>? ModifiersUpdated;
        #endregion
        #endregion

        #region Constructor
        public ucModifierKeys()
        {
            InitializeComponent();
            Modifiers = new List<ModifierKeys>();
        }
        #endregion

        #region Public methods
        public void Reset(bool invokeEventHandler = true)
        {
            Modifiers = new List<ModifierKeys>();
            chkAlt.Checked = chkCtrl.Checked = chkShift.Checked = chkWin.Checked = false;
            UpdateUI();
            if (invokeEventHandler) { ModifiersUpdated?.Invoke(this, Modifiers); }
        }

        public bool SetKeys(List<ModifierKeys> modifierKeys, bool invokeEventHandler = true)
        {
            try
            {
                Modifiers = modifierKeys;
                if (SortModifiers) { Modifiers.Sort(); }

                _configuring = true;
                chkAlt.Checked = chkCtrl.Checked = chkShift.Checked = chkWin.Checked = false;
                foreach (ModifierKeys modifierKey in modifierKeys)
                {
                    Control[] controls = this.Controls.Find($"chk{modifierKey}", true);
                    if (controls.Count() == 1) { ((CheckBox)controls[0]).Checked = true; }
                }
                _configuring = false;

                UpdateUI();
                if (invokeEventHandler) { ModifiersUpdated?.Invoke(this, Modifiers); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Private methods
        private void ucModifierKeys_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "-";
            this.Height = 21;
        }

        private void CheckboxChanged(object sender, EventArgs e)
        {
            CheckBox? checkBox = sender as CheckBox;
            if (checkBox is null || _configuring) { return; }
            if (checkBox.Tag is not null && Enum.IsDefined(typeof(ModifierKeys), checkBox.Tag))
            {
                bool parsed = Enum.TryParse(checkBox.Tag.ToString(), ignoreCase: true, out ModifierKeys modifierKeys);
                if (!parsed) { return; }
                if (checkBox.Checked) { Modifiers.Add(modifierKeys); }
                else { Modifiers.Remove(modifierKeys); }
                if (SortModifiers) { Modifiers.Sort(); }
                UpdateUI();
                ModifiersUpdated?.Invoke(this, Modifiers);
            }
        }

        private void UpdateUI()
        {
            if (Modifiers.Count == 0)
            {
                lblInfo.Text = "-";
                ModifiersText = string.Empty;
            }
            else { ModifiersText = lblInfo.Text = string.Join(", ", Modifiers); }
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {
            ToggleExtend();
        }

        private void ucModifierKeys_Leave(object sender, EventArgs e)
        {
            this.Height = 21;
            _extended = false;
        }

        public void ToggleExtend()
        {
            if (_extended) { this.Height = 21; }
            else { this.Height = 75; this.Focus(); }
            _extended.Invert();
        }
        #endregion
    }
}
