using JumpKing;
using JumpKing.API;
using JumpKing.BodyCompBehaviours;
using JumpKing.Player;
using JumpKing_GiantBootsSound.Model;

namespace JumpKing_GiantBootsSound.Bahaviours
{
    public class BootsSound: IBodyCompBehaviour
    {
        private bool isLanded = true;
        public bool ExecuteBehaviour(BehaviourContext behaviourContext)
        {
            if (!Preference.Preferences.IsEnabled) return true;

            BodyComp bodyComp = behaviourContext.BodyComp;
            PlayIronLand(bodyComp);

            return true;
        }

        private void PlayIronLand(BodyComp bodyComp)
        {
            if (bodyComp.IsOnGround)
            {
                if (isLanded)
                {
                    Game1.instance?.contentManager?.audio?.player?.IronLand?.PlayOneShot();
                    isLanded = false;
                }
            }
            else
            {
                isLanded = true;
            }
        }
    }
}
