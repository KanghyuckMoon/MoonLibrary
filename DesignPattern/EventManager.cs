﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoonLibrary.DesignPattern
{
	public class EventManager : Singleton<EventManager>
	{

		private Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();
		private Dictionary<string, Action<object>> eventParamDictionary = new Dictionary<string, Action<object>>();

		/// <summary>
		/// 이벤트 초기화
		/// </summary>
		public static void ClearEvents()
		{
			Instance.eventDictionary.Clear();
			Instance.eventParamDictionary.Clear();
		}

		/// <summary>
		/// 이벤트 함수 등록하기 
		/// </summary>
		/// <param name="eventName"></param>
		/// <param name="listener"></param>
		public static void StartListening(string eventName, Action listener)
		{
			Action thisEvent;
			if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
			{
				//기존 이벤트에 더 많은 이벤트 추가 
				thisEvent += listener;

				//딕셔너리 업데이트
				Instance.eventDictionary[eventName] = thisEvent;
			}
			else
			{
				//처음으로 딕셔너리에 이벤트 추가 
				thisEvent += listener;
				Instance.eventDictionary.Add(eventName, thisEvent);
			}
		}
		public static void StartListening(string eventName, Action<object> listener)
		{
			Action<object> thisEvent;

			if (Instance.eventParamDictionary.TryGetValue(eventName, out thisEvent))
			{
				thisEvent += listener;
				Instance.eventParamDictionary[eventName] = thisEvent;
			}
			else
			{
				thisEvent += listener;
				Instance.eventParamDictionary.Add(eventName, listener);
			}
		}

		/// <summary>
		/// 이벤트 함수 해제하기 
		/// </summary>
		/// <param name="eventName"></param>
		/// <param name="listener"></param>
		public static void StopListening(string eventName, Action listener)
		{
			if (Instance == null)
			{
				return;
			}
			Action thisEvent;
			if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
			{
				//기존 이벤트에서 이벤트 제거
				thisEvent -= listener;

				//이벤트 업데이트 
				Instance.eventDictionary[eventName] = thisEvent;
			}

		}

		public static void StopListening(string eventName, Action<object> listener)
		{
			if (Instance == null)
			{
				return;
			}
			Action<object> thisEvent;
			if (Instance.eventParamDictionary.TryGetValue(eventName, out thisEvent))
			{
				thisEvent -= listener;

				Instance.eventParamDictionary[eventName] = thisEvent;
			}
		}
		/// <summary>
		/// 이벤트 함수 실행 
		/// </summary>
		/// <param name="eventName"></param>
		public static void TriggerEvent(string eventName)
		{
			Action thisEvent = null;
			if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
			{
				Debug.Log("이벤트 실행!");
				thisEvent?.Invoke();
			}
			else
			{
				Debug.LogError("빈 이벤트입니다");
			}
		}

		public static void TriggerEvent(string eventName, object param)
		{
			Action<object> thisEvent = null;
			if (Instance.eventParamDictionary.TryGetValue(eventName, out thisEvent))
			{
				thisEvent?.Invoke(param);
			}
			else
			{
				Debug.LogError("빈 이벤트입니다");
			}
		}
	}
}
