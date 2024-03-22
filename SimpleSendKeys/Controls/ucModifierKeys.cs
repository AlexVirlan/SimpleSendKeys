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
        #endregion

        #region Public
        [Description("The modifiers list"), Category("Data")]
        public List<ModifierKeys> Modifiers { get; private set; }

        [Description("Whether to sort the modifiers or not"), Category("Appearance")]
        public bool SortModifiers { get; set; } = true;
        #endregion
        #endregion

        public ucModifierKeys()
        {
            InitializeComponent();
            Modifiers = new List<ModifierKeys>();
        }

        private void ucModifierKeys_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "-";
            this.Height = 21;
        }

        private void CheckboxChanged(object sender, EventArgs e)
        {
            CheckBox? checkBox = sender as CheckBox;
            if (checkBox is null) { return; }
            if (checkBox.Tag is not null && Enum.IsDefined(typeof(ModifierKeys), checkBox.Tag))
            {
                bool parsed = Enum.TryParse(checkBox.Tag.ToString(), ignoreCase: true, out ModifierKeys modifierKeys);
                if (!parsed) { return; }
                if (checkBox.Checked) { Modifiers.Add(modifierKeys); }
                else { Modifiers.Remove(modifierKeys); }
                if (SortModifiers) { Modifiers.Sort(); }
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (Modifiers.Count == 0) { lblInfo.Text = "-"; }
            else { lblInfo.Text = string.Join(", ", Modifiers); }
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
    }
}
