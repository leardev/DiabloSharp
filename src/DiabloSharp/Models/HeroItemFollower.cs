namespace DiabloSharp.Models
{
    public class HeroItemFollower : HeroItemCustomizable
    {
        public FollowerId Follower { get; internal set; }

        public ItemFollowerSlot Slot { get; internal set; }
    }
}