using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ImojiManager : MonoBehaviour
{
    // مدیریت ایموجی ها
    public LevelData levelData; 

    [FormerlySerializedAs("tapObjectPrefab")]
    public ImojiObject imojiObjectPrefab;

    public List<ImojiObject> activeTaps;

    [SerializeField] private CameraController _camera;

    public static ImojiManager Instance;

    public List<Sprite> imojies;

    [SerializeField] private TimerPresenter timerPresenter;
    [SerializeField] private ScorePresenter scorePresenter;

    [SerializeField] private Image randomImage;

    private int randomIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timerPresenter.onTimerReached += () =>
        {
            //وقتی زمان تمام شد بازیکن میبازد
            LevelManager.Instance.GameOver();
            timerPresenter.StopCounting();
        };
        timerPresenter.onTimerChanged += () =>
        {
// گذر بمان بازیکن امتیاز میگیرد            
            scorePresenter.AddScore(Time.deltaTime * timerPresenter.GetFillAmount() * 6f);
        };
    }


    //تولید ایموجی
    public void SpwanImoji()
    {
        timerPresenter.ResetTime();
        // انتخاب ایموجی با مختصات تصادفی
        Vector2 ranomP = new Vector2(Random.Range(0, levelData.resolution.x), Random.Range(0, levelData.resolution.y));


        // انتخاب عکس بین لیست
        randomIndex = Random.Range(1, imojies.Count);

        var resolution = (Vector2)levelData.resolution * 1f;
        for (int x = 0; x < resolution.x; x++)
        {
            for (int y = 0; y < resolution.y; y++)
            {
                ImojiObject t = Instantiate(imojiObjectPrefab, new Vector3(x, y), quaternion.identity);

                activeTaps.Add(t);
                t.transform.name = $" {x} : {y}";

                // قرار دادن مقدار تصادفی بودن به ایموجی ها
                if (new Vector2(x, y) == ranomP)
                {
                    // قرار دادن عکس ایموجی حدف
                    t._renderer.sprite = imojies[randomIndex];
                   
                    randomImage.sprite = imojies[randomIndex];
                    
                    t.isHadaff = true;
                }
                else
                {
                    //قرار دادن ایموجی رندوم برای بقیه 
                    var imojiRandom = Random.Range(1, imojies.Count);

                    do
                    {
                        
                        //اگر مقدار رندمش برابر با ایموجی هدف بود دوباره رندم رو انتخاب کنه
                        imojiRandom = Random.Range(1, imojies.Count);
                    } while (imojiRandom == randomIndex);

                    t._renderer.sprite = imojies[imojiRandom];
                }
            }
        }

        // انازه کردن دوربین
        _camera.UpdateCamera(activeTaps);
    }

    // هنگام کلیک شدن توسط ایموجی صدا زده میشود
    public void KelikMe(ImojiObject imojiObject)
    {
        // اگر روی ایموجی درست انتخاب کرد برنده میشود
        if (imojiObject.isHadaff)
        {
            // پخش صدا
            SoundManager.Instance.PlayWin();
            scorePresenter.AddScore(10f);
            // حذف ایموجی های قبلی
            foreach (var activeTap in activeTaps)
            {
                Destroy(activeTap.gameObject);
            }

            activeTaps.Clear();
            // رفتن به لول بعدی
            LevelManager.Instance.NextLevel();
        }
        else
        {
            // انتخاب اشتباه و باختن
            
            SoundManager.Instance.PlayWrong();

            timerPresenter.AddCurrentTime(2);
            imojiObject.transform.DOShakePosition(.1f, .1f);
        }
    }

    public void ResetIMojies()
    {
        // حدف ایموجی های قبلی
        foreach (var activeTap in activeTaps)
        {
            Destroy(activeTap.gameObject);
        }

        activeTaps.Clear();
        scorePresenter.ResetScore();
        timerPresenter.ResetTime();
    }

    public void MeRandom(ImojiObject imojiObject)
    {
        randomImage.sprite = imojiObject._renderer.sprite;
    }
}