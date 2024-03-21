using SimpleSendKeys.Utils.KeyboardHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSendKeys.Controls
{
    public partial class ucModifierKeys : UserControl
    {
        public List<ModifierKeys> Modifiers { get; private set; }


        public ucModifierKeys()
        {
            InitializeComponent();
            Modifiers = new List<ModifierKeys>();
        }

        private void ucModifierKeys_Load(object sender, EventArgs e)
        {

        }

        private void CheckboxChanged(object sender, EventArgs e)
        {
            CheckBox? checkBox = sender as CheckBox;
            if (checkBox is null) { return; }
            if (checkBox.Tag is not null && Enum.IsDefined(typeof(ModifierKeys), checkBox.Tag))
            {
                ModifierKeys modifierKeys = (ModifierKeys)checkBox.Tag;
                if (checkBox.Checked) { Modifiers.Add(modifierKeys); }
                else { Modifiers.Remove(modifierKeys); }
            }
            UpdateUI();
        }

        private void UpdateUI()
        {

        }
    }
}
