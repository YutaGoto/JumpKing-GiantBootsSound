using JumpKing.PauseMenu.BT.Actions;
using JumpKing_GiantBootsSound.Model;

namespace JumpKing_GiantBootsSound.Menu
{
    public class ToggleEnabled: ITextToggle
    {
        public ToggleEnabled() : base(Preference.Preferences.IsEnabled) { }

        protected override string GetName() => "Giant Boots Sound";

        protected override void OnToggle() => Preference.Preferences.IsEnabled = toggle;
    }
}
