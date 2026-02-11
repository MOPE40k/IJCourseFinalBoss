using System.Collections;
using Runtime.Gameplay;
using Runtime.Gameplay.Infrastucture;
using UnityEngine;
using Utils;
using Utils.CoroutinesManagement;
using Utils.InputManagement;
using Utils.SceneManagement;

public class GameResultService : IService
{
    // References
    private readonly PhraseCompareService _phraseCompareService = null;
    private readonly SceneSwitcherService _sceneSwitcherService = null;
    private readonly ICoroutinePerformer _coroutinePerformer = null;

    public GameResultService(
        PhraseCompareService phraseCompareService,
        SceneSwitcherService sceneSwitcherService,
        ICoroutinePerformer coroutinePerformer)
    {
        _phraseCompareService = phraseCompareService;
        _sceneSwitcherService = sceneSwitcherService;
        _coroutinePerformer = coroutinePerformer;
    }

    public IEnumerator DetermineResult(string userInput, string codePhrase, GameplayInputArgs inputArgs)
    {
        IEnumerator nextSceneRoutine = null;

        if (_phraseCompareService.Compare(userInput, codePhrase))
        {
            Debug.Log("WIN!");

            nextSceneRoutine = _sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu, null);
        }
        else
        {
            Debug.Log("DEFEAT");

            nextSceneRoutine = _sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, inputArgs);
        }

        Debug.Log("PRESS SPACE TO CONTINUE!");

        yield return WaitConfirm(InputKeys.RestartKey);

        _coroutinePerformer.StartPerform(nextSceneRoutine);
    }

    private IEnumerator WaitConfirm(KeyCode key)
    {
        yield return new WaitWhile(() => Input.GetKeyDown(key) == false);
    }
}
