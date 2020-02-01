namespace GGJ2020 {
	/// <summary>
	/// Represents a very basic system that can take you to different game levels.
	/// </summary>
	public interface ILevelSystem {
		int CurrentLevel { get; }
		GameEvent OnLevelChanged { get; }
		void GoToLevel(int level);
	}
}