using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoonLibrary.Pool
{
	public class PoolManager : MonoBehaviour
	{
		//풀링
		public Dictionary<string, object> queueDictionary = new Dictionary<string, object>();
		

		/// <summary>
		/// 큐에서 오브젝트 가져오기
		/// </summary>
		public T GetObject<T>()
		{
			if (queueDictionary.TryGetValue(typeof(T).Name, out var something))
			{
				var queue = something as Queue<T>;
				if(queue.Count > 0)
				{
					return queue.Dequeue();
				}
			}
			return default(T);
		}

		/// <summary>
		/// 큐에 오브젝트 등록하기
		/// </summary>
		public void RegisterObject<T>(T obj)
		{
			if (queueDictionary.TryGetValue(typeof(T).Name, out var something))
			{
				var queue = something as Queue<T>;
				queue.Enqueue(obj);
			}
			else
			{
				AddQueue<T>();
				var queue = queueDictionary[typeof(T).Name] as Queue<T>;
				queue.Enqueue(obj);
			}
		}

		/// <summary>
		/// 큐 등록
		/// </summary>
		/// <typeparam name=""></typeparam>
		private void AddQueue<T>()
		{
			Queue<T> queue = new Queue<T>();
			if (!queueDictionary.TryGetValue(typeof(T).Name, out var something))
			{
				queueDictionary.Add(typeof(T).Name, queue);
			}
		}

	}
}
