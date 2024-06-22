/*
 *  �T�E���h�}�l�[�W���[(�V���O���g��)
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
    /// ���ʉ� enum
    /// </summary>
    public enum SE_Type
    {
        CLICK = 0,
        EAT,
        GUEST_STANDBY,
        TIME_UP,
    }

    public class SR_SoundManager : MonoBehaviour
    {
        ///<summary> �V���O���g�� </summary>
        public static SR_SoundManager instance;

        ///<summary> BGM </summary>
        private AudioSource bgmSource;

        ///<summary> �����ɗ�����SE �����10</summary>
        private AudioSource[] seSources = new AudioSource[30];

        ///<summary> BGM </summary>
        [SerializeField] [Header("BGM TITLE �� GAME �� FEVER �� RESULT")] private AudioClip[] bgmClips;

        ///<summary> SE </summary>
        [SerializeField] [Header("SE")] private AudioClip[] seClips;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                DontDestroyOnLoad(gameObject);//Scene�ړ��ŏ�����Ȃ��悤�ɂ���
            }
            else
            {
                Destroy(this);//���ɐ�������Ă���̂ł���Ώ���
            }

            // AudioSource�ǉ�
            bgmSource = gameObject.AddComponent<AudioSource>();

            for (int i = 0; i < seSources.Length; i++)
            {
                seSources[i] = gameObject.AddComponent<AudioSource>();
            }
        }

        /// <summary>
        /// BGM�v���C�֐�
        /// </summary>
        /// <param BGM�̎�� ="bgmType"></param>
        /// <param ���[�v���邩 ="loopFlg"></param>
        public void PlayBGM(BGM_Type bgmType, bool loopFlg = true)
        {
            int index = (int)bgmType;
            if (index < 0 || bgmClips.Length <= index)//�o�^�͈͊O�̏ꍇ�͏������Ȃ�
            {
                return;
            }

            bgmSource.loop = loopFlg;
            bgmSource.clip = bgmClips[index];
            bgmSource.Play();
        }

        /// <summary>
        /// SE�v���C�֐�
        /// </summary>
        /// <param SE�̎�� ="seType"></param>
        /// <param �{�����[�� ="vol"></param>
        public void PlaySE(SE_Type seType, float vol = 1.0f)
        {
            int index = (int)seType;
            if (index < 0 || seClips.Length <= index)//�o�^�͈͊O�̏ꍇ�͏������Ȃ�
            {
                return;
            }

            // �Đ����ł͂Ȃ�AudioSource��������SE��炷
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
        /// BGM��~�֐�
        /// </summary>
        public void StopBGM()
        {
            bgmSource.Stop();
            bgmSource.clip = null;
        }


        /// <summary>
        /// BGM�{�����[���ύX�֐�
        /// </summary>
        /// <param volume ="vol"></param>
        public void SetVolumeBGM(float vol)
        {
            vol = Mathf.Clamp(vol, 0.0f, 1.0f);
            bgmSource.volume = vol;
        }
    }


}