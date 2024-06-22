/*
 *  サウンドマネージャー(シングルトン)
 *  Abe.K
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    /// <summary>
    /// BGM enmu
    /// </summary>
    public enum BGM_Type
    {
        TITLE = 0,
        GAME,
        FEVER,
        RESULT,
    }

    /// <summary>
    /// 効果音 enum
    /// </summary>
    public enum SE_Type
    {
        CLICK = 0,
        EAT,
        GUEST_STANDBY,
        TIME_UP,
        DELICIOUS,
    }

    public class SR_SoundManager : MonoBehaviour
    {
        ///<summary> シングルトン </summary>
        public static SR_SoundManager instance;

        ///<summary> BGM </summary>
        private AudioSource bgmSource;

        ///<summary> 同時に流せるSE 今回は10</summary>
        private AudioSource[] seSources = new AudioSource[30];

        ///<summary> BGM </summary>
        [SerializeField] [Header("BGM TITLE → GAME → FEVER → RESULT")] private AudioClip[] bgmClips;

        ///<summary> SE </summary>
        [SerializeField] [Header("SE")] private AudioClip[] seClips;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                DontDestroyOnLoad(gameObject);//Scene移動で消されないようにする
            }
            else
            {
                Destroy(this);//既に生成されているのであれば消す
            }

            // AudioSource追加
            bgmSource = gameObject.AddComponent<AudioSource>();

            for (int i = 0; i < seSources.Length; i++)
            {
                seSources[i] = gameObject.AddComponent<AudioSource>();
            }
        }

        /// <summary>
        /// BGMプレイ関数
        /// </summary>
        /// <param BGMの種類 ="bgmType"></param>
        /// <param ループするか ="loopFlg"></param>
        public void PlayBGM(BGM_Type bgmType, bool loopFlg = true)
        {
            int index = (int)bgmType;
            if (index < 0 || bgmClips.Length <= index)//登録範囲外の場合は処理しない
            {
                return;
            }

            bgmSource.loop = loopFlg;
            bgmSource.clip = bgmClips[index];
            bgmSource.Play();
        }

        /// <summary>
        /// SEプレイ関数
        /// </summary>
        /// <param SEの種類 ="seType"></param>
        /// <param ボリューム ="vol"></param>
        public void PlaySE(SE_Type seType, float vol = 1.0f)
        {
            int index = (int)seType;
            if (index < 0 || seClips.Length <= index)//登録範囲外の場合は処理しない
            {
                return;
            }

            // 再生中ではないAudioSourceをつかってSEを鳴らす
            foreach (AudioSource s in seSources)
            {
                if (s.isPlaying) { continue; }

                s.clip = seClips[index];
                s.loop = false;
                s.volume = vol;
                s.Play();
                break;
            }

        }

        /// <summary>
        /// BGM停止関数
        /// </summary>
        public void StopBGM()
        {
            bgmSource.Stop();
            bgmSource.clip = null;
        }


        /// <summary>
        /// BGMボリューム変更関数
        /// </summary>
        /// <param volume ="vol"></param>
        public void SetVolumeBGM(float vol)
        {
            vol = Mathf.Clamp(vol, 0.0f, 1.0f);
            bgmSource.volume = vol;
        }
    }


}
