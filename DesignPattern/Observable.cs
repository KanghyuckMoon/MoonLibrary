using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoonLibrary.DesignPattern
{
	public class ObservableObj : MonoBehaviour, IObservable
	{
		private List<IObserver> observers = new List<IObserver>();

		public void AddObserver(IObserver observer)
		{
			//관찰자 리스트에 해당 관찰자 추가
			observers.Add(observer);
		}

		public void PostNotify()
		{
			//모든 관찰자들에게 메시지 전달
			foreach(var observer in observers)
			{
				observer.GetNotify();
			}
		}
	}
}
