using System.Collections.Generic;

public class QuestFeature : IQuestFeature
{
    public List<IQuest> Quests => _quests;

    private List<IQuest> _quests;

    public QuestFeature()
    {
    }

    public void SaveProgress(GameProgress progress)
    {
        progress.Quests = _quests;
    }

    public void LoadProgress(GameProgress progress)
    {
        if (progress.Quests != null)
            _quests = progress.Quests;
    }
}
