using UnityEngine;

public class iTweenTest : MonoBehaviour {

    [HideInInspector]
    public AudioSource testSource;
    [HideInInspector]
    public AudioClip testClip;
    bool pause;

    private void Start()
    {
        //Scale(Размер)
        //iTween.ScaleTo(gameObject, iTween.Hash("x", 2, "time", 10)); // задаем размер обьекту.
        //iTween.ScaleFrom(gameObject, iTween.Hash("x", 2, "delay", 1)); // задаем размер и возвращаем ему стандартный размер
        //iTween.ScaleAdd(gameObject, iTween.Hash("x", 0.5f, "y", 0.4, "time", 4)); // задаем размер обьекту с теченим времени.

        //Punches (Удары, не может быть циклом)
        //iTween.PunchPosition(gameObject,iTween.Hash ("y", -1, "time", 2)); // "Ударяем" обьект после чего он возвращается на стартовую позицию.
        //iTween.PunchRotation(gameObject, iTween.Hash("z", 44, "time", 4)); // Раскачиваем обьект по оси z и возвращаем в текущее положение.
        //iTween.PunchScale(gameObject, iTween.Hash("x", 0.3f, "y", 0.2f, "time", 3));  

        //Shake (Встряска)
        //iTween.ShakePosition(gameObject, iTween.Hash("x", -2, "time", 1.5f)); //Встряхивает обьект по оси x и возвращает текущий Transform
        //iTween.ShakePosition(gameObject, iTween.Hash("y", -2, "time", 1.5f)); //Встряхивает обьект по оси y и возвращает текущий Transform
        //iTween.ShakeRotation(gameObject, iTween.Hash("z", -10, "time", 1.0f));// Встряхиват обьект rotation z и возвращает текущий Transform
        //iTween.ShakeScale(gameObject, iTween.Hash("x", 0.2, "y", 0.3, "time", 2.0f));// Втряхирает в зависимости от размера и возвращает текущий Transform

        //Stab (Автоматически добавляет AudioSource)
        //iTween.Stab(gameObject, iTween.Hash("delay", 1.0f, "audioclip", testClip, "pitch", Random.Range(0.3f, 1.0f)));

        //Audio
        //testSource.Play();
        //iTween.AudioTo(gameObject, iTween.Hash("pitch", 0.0f, "delay", 9.38, "time", 3, "onComplete", "audioStopped"));// когда проходит значение "delay", мы передаем значение функции audioStopped на значение "time" послечего продолжаем проигрывать AudioSource.
        //iTween.AudioFrom(gameObject, iTween.Hash("volume", 0.5f, "pitch", 0.7f, "time", 3.0f, "onComplete", "audioComplete")); // передаем временные параметры audioSourc'у.

        //Rotate 
        //iTween.RotateTo(gameObject, iTween.Hash("z", 45, "time", 2.0f, "loopType", "pingPong")); // поворачивает объект по оси z затем возвращает текущую позицию, и повторяется вновь(loop Pingpong - то есть обратная анимация). 
        //iTween.RotateFrom(gameObject, iTween.Hash("z", 45, "loopType", "loop")); // с какой позиции возвращается в исходную.
        //iTween.RotateBy(gameObject, iTween.Hash("z", 2, "time", 10, "transition", "easeInOutBack"));
        //iTween.RotateAdd(gameObject, iTween.Hash("z", -90.0f, "delay", 2.0f, "time", 3.0f)); // Переворачиваем обьект на 90 градусов.

        //Fade (Материал должен вычеслять альфа канал)
        //iTween.FadeTo(gameObject, iTween.Hash("alpha", 0.0f, "time", 2.0f)); // Делает рендер прозрачным через 2.0 секунды.
        //iTween.FadeFrom(gameObject, iTween.Hash("alpha", 0.0f, "delay", 2.0f)); // Обратное действие FadeTo.

        //Color (Цвет)
        //iTween.ColorTo(gameObject, iTween.Hash("r", 1.0f, "g", 0.0f, "b", 0.0f, "time", 3.0f)); // Делаем обьект с течением времени красным.
        //iTween.ColorFrom(gameObject, iTween.Hash("r", 1.0f, "g", 0.0f, "b", 0.0f, "time", 3.0f, "loopType", "pingPong")); // return default color.

        //Movement
        //iTween.MoveTo(gameObject, iTween.Hash("x", 2, "y", 4, "time", 2, "loopType", "pingPong"));
        //iTween.MoveFrom(gameObject, iTween.Hash("x", 2, "y", 4, "time", 2));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PathTest"), "time", 15.0f,"easetype", iTween.EaseType.easeInOutSine, "loopType", "pingPong"));
        //iTween.MoveBy(gameObject, targetVec, 2.0f);
        //Look
        //iTween.LookFrom(gameObject, iTween.Hash("z", 90,"looktarget", target));
       
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pause = !pause;
            if (pause)
            {
                iTween.Pause(gameObject);
            }
            else
            {
                iTween.Resume(gameObject);
            }
        }
    }
    
    /*
    void audioStopped()
    {
        iTween.AudioTo(gameObject, iTween.Hash("pitch", 1, "time", 1.6f, "delay", 0.5f));
    }
    
    void audioComplete()
    {
        iTween.AudioTo(gameObject, iTween.Hash("pitch", 1.3f, "volume", 0.1f));
    }
    */
}
