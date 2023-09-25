
public sealed class UIEventHandler : GeneralEventHandler
{
    private GeneralEvent _eventChangeSFXVolume;
    private GeneralEvent _eventChangeMusicVolume;
    private GeneralEvent _eventMuteMusic;
    private GeneralEvent _eventMuteSFX;
    private GeneralEvent _eventExitGame;
    private GeneralEvent _eventPressBtnPlay;

    public GeneralEvent EventChangeSFXVolume { get => _eventChangeSFXVolume; }
    public GeneralEvent EventChangeMusicVolume { get => _eventChangeMusicVolume; }
    public GeneralEvent EventMuteMusic { get => _eventMuteMusic; }
    public GeneralEvent EventMuteSFX { get => _eventMuteSFX; }
    public GeneralEvent EventExitGame { get => _eventExitGame; }
    public GeneralEvent EventPressBtnPlay { get => _eventPressBtnPlay; }

    protected override void GenerateEvents()
    {
        _eventChangeSFXVolume = new GeneralEvent();
        _eventChangeMusicVolume = new GeneralEvent();
        _eventMuteMusic = new GeneralEvent();
        _eventMuteSFX = new GeneralEvent();
        _eventExitGame = new GeneralEvent();
        _eventPressBtnPlay = new GeneralEvent();
    }
    protected override void SetEventsList()
    {
        base.SetEventsList();
        _events.Add(_eventChangeSFXVolume);
        _events.Add(_eventChangeMusicVolume);
        _events.Add(_eventMuteMusic);
        _events.Add(_eventMuteSFX);
        _events.Add(_eventExitGame);
        _events.Add(_eventPressBtnPlay);
    }
}
