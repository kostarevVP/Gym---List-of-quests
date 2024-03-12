using System.Collections.Generic;
using WKosArch.Domain.Features;

public class Quest_Feature : IFeature
{
    public bool IsReady => _isReady;


    private bool _isReady;

    private List<ICountQuest> _countQuests;
    private List<IPointQuest> _pointQuests;

}
