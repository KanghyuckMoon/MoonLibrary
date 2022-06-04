using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace MoonLibrary.Dotween
{
	public class DotweenManager<T> : MonoBehaviour
	{
		public Dictionary<string, Func<T, Sequence>> funcDictionary = new Dictionary<string, Func<T, Sequence>>();

		/// <summary>
		/// 타입과 관련된 시퀀스를 반환한다
		/// </summary>
		/// <param name="dotweenName">닷트윈의 이름</param>
		/// <param name="factor">닷트윈에 사용할 트랜스폼</param>
		/// <returns></returns>
		public Sequence GetSequence(string dotweenName, T factor)
		{
			if(funcDictionary.ContainsKey(dotweenName))
			{
				return funcDictionary[dotweenName].Invoke(factor);
			}
			else
			{
				Debug.LogError("닷트윈이 등록되지 않음");
				return null;
			}
		}

		/// <summary>
		/// 타입을 사용하는 닷트윈 함수 등록
		/// </summary>
		/// <param name="dotweenName"></param>
		/// <param name="method"></param>
		public void RegisterSequence(string dotweenName, Func<T, Sequence> method)
		{
			funcDictionary.Add(dotweenName, method);
		}

	}
}
